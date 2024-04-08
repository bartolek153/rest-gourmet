# Global variable to store the BACPAC file path
$bacpacFile = ""

# Function to generate the backup file name
function GenerateBackupFileName {
    "bkp_$((Get-Date).ToString("yyyyMMdd_HHmm")).bacpac"
}

# Function to increment file path if it already exists
function IncrementFilePath($filePath) {
    $extension = $filePath.Extension
    $base = $filePath.FullName.Replace($extension, "")
    $index = 1

    while (Test-Path "$base-$index$extension") {
        $index++
    }

    "$base-$index$extension"
}

# Function to check if a BACPAC file exists in the directory
function CheckForExistingBacpac($directory) {
    $bacpacFile = Get-ChildItem -Path $directory -Filter "*.bacpac" | Select-Object -First 1 -ExpandProperty FullName

    if ($bacpacFile) {
        Write-Output "Found an existing BACPAC file in the directory:"
        Write-Output "$bacpacFile"
        return $true
    } else {
        return $false
    }
}

# Function to generate the default database name
function GenerateDefaultDatabaseName {
    "dev$((Get-Date).ToString("MMdd"))"
}

# Function to import the BACPAC file
function ImportBacpac($targetFilePath, $newDatabaseName) {
    $absolutePath = (Resolve-Path $targetFilePath).Path
    $sqlPackageImportCommand = "sqlpackage /a:Import /sf:`"$absolutePath`" /TargetConnectionString:`"Data Source=(localdb)\mssqllocaldb;Initial Catalog=$newDatabaseName;Integrated Security=true;`""

    Write-Output "Initiating BACPAC import into database: $newDatabaseName"
    Invoke-Expression $sqlPackageImportCommand
    Write-Output "BACPAC import into database $newDatabaseName completed."
}

# Check if DBCONN environment variable is set
if (-not $env:DBCONN) {
    $env:DBCONN = Read-Host "Enter the database connection string"
}

# Check if a BACPAC file exists in the result directory
$targetFilePath = Read-Host "Enter the target file path for the BACPAC export (Leave blank for default)"
if (CheckForExistingBacpac (Split-Path $targetFilePath -Parent)) {
    $importExistingChoice = Read-Host "Do you want to import the existing BACPAC file into a new database? (y/n)"
    if ($importExistingChoice -eq 'y' -or $importExistingChoice -eq 'Y') {
        $newDatabaseName = Read-Host "Enter the name of the new database (Leave blank for default)"
        if (-not $newDatabaseName) {
            $newDatabaseName = GenerateDefaultDatabaseName
        }
        ImportBacpac $bacpacFile $newDatabaseName
        exit 0
    } else {
        Write-Output "No import operation performed for the existing BACPAC file. Exiting..."
    }
}

# Check if the target file path is empty
if (-not $targetFilePath) {
    $defaultFileName = GenerateBackupFileName
    $targetFilePath = Join-Path $env:HOME $defaultFileName
} else {
    if (-not $targetFilePath.Contains(".")) {
        $targetFilePath += ".bacpac"
    }
}

# Build the sqlpackage export command
$sqlPackageExportCommand = "sqlpackage /a:Export /tf:`"$targetFilePath`" /scs:`"$env:DBCONN`""

# Inform the user about the export operation
Write-Output "Initiating BACPAC export to directory: $(Split-Path $targetFilePath -Parent)"

# Execute the sqlpackage export command
Invoke-Expression $sqlPackageExportCommand

# Inform the user about the export completion
Write-Output "BACPAC export completed."

# Ask the user if they want to proceed with the import
$importChoice = Read-Host "Do you want to import the BACPAC into a new database? (y/n)"
if ($importChoice -eq 'y' -or $importChoice -eq 'Y') {
    $newDatabaseName = Read-Host "Enter the name of the new database (Leave blank for default)"
    if (-not $newDatabaseName) {
        $newDatabaseName = GenerateDefaultDatabaseName
    }
    ImportBacpac $targetFilePath $newDatabaseName
} else {
    Write-Output "No import operation performed. Exiting..."
}
