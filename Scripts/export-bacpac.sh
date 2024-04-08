#!/bin/bash

# Global variable to store the BACPAC file path
declare -g bacpacFile=""

# Function to generate the backup file name
generateBackupFileName() {
    echo "bkp_$(date +"%Y%m%d_%H%M").bacpac"
}

# Function to increment file path if it already exists
incrementFilePath() {
    local filePath=$1
    local extension="${filePath##*.}"
    local base="${filePath%.*}"
    local index=1

    while [ -e "$base-$index.$extension" ]; do
        index=$((index + 1))
    done

    echo "$base-$index.$extension"
}

# Function to check if a BACPAC file exists in the directory
checkForExistingBacpac() {
    local directory=$1

    bacpacFile=$(find "$directory" -maxdepth 1 -type f -name "*.bacpac")

    if [ -n "$bacpacFile" ]; then
        echo "Found an existing BACPAC file in the directory:"
        echo "$bacpacFile"
        return 0
    else
        return 1
    fi
}

# Function to generate the default database name
generateDefaultDatabaseName() {
    echo "dev$(date +"%m%d")"
}

# Function to import the BACPAC file
importBacpac() {
    local targetFilePath=$1
    local newDatabaseName=$2

    # Build the absolute path for the BACPAC file
    local absolutePath="$(cd "$(dirname "$targetFilePath")" && pwd)/$(basename "$targetFilePath")"

    # Build the sqlpackage import command
    # sqlPackageImportCommand="sqlpackage /a:Import /tt:1 /tsn:\"(localdb)\mssqllocaldb\" /tdn:\"$newDatabaseName\" /sf:\"$absolutePath\""
    sqlPackageImportCommand="sqlpackage /a:Import /sf:\"$absolutePath\" /TargetConnectionString:\"Data Source=localhost;Initial Catalog=$newDatabaseName;Integrated Security=true;\""

    # Inform the user about the import operation
    echo "Initiating BACPAC import into database: $newDatabaseName"

    # Execute the sqlpackage import command
    eval $sqlPackageImportCommand

    # Inform the user about the import completion
    echo "BACPAC import into database $newDatabaseName completed."
}

# Check if sqlpackage command exists
if ! command -v sqlpackage &>/dev/null; then
    echo "Error: sqlpackage command not found. Aborting."
    exit 1
fi

# Check if DBCONN environment variable is set
if [ -z "$DBCONN" ]; then
    # Prompt the user for the connection string
    read -p "Enter the database connection string: " DBCONN
fi

# Check if a BACPAC file exists in the result directory
if checkForExistingBacpac "$(dirname "$targetFilePath")"; then
    # Ask the user if they want to import the existing BACPAC file
    read -p "Do you want to import the existing BACPAC file into a new database? (y/n): " importExistingChoice

    if [[ $importExistingChoice =~ ^[Yy]$ ]]; then
        # Prompt the user for the new database name
        read -p "Enter the name of the new database (Leave blank for default): " newDatabaseName

        if [ -z "$newDatabaseName" ]; then
            newDatabaseName=$(generateDefaultDatabaseName)
        fi

        importBacpac "$bacpacFile" "$newDatabaseName"
        exit 0
    else
        echo "No import operation performed for the existing BACPAC file. Exiting..."
    fi
fi

# Prompt the user for the target file path
echo "Enter the target file path for the BACPAC export."
read -p "Leave blank to use the default backup file name: $(generateBackupFileName): " targetFilePath

# Check if the target file path is empty
if [ -z "$targetFilePath" ]; then
    # Generate the default target file path
    defaultFileName="$(generateBackupFileName)"
    targetFilePath="$HOME/$defaultFileName"
else
    # Check if the file path contains a file extension
    if ! [[ $targetFilePath == *.* ]]; then
        # Append .bacpac extension if missing
        targetFilePath="$targetFilePath.bacpac"
    fi
fi

# Build the sqlpackage export command
sqlPackageExportCommand="sqlpackage /a:Export /tf:\"$targetFilePath\" /scs:\"$DBCONN\""

# Inform the user about the export operation
echo "Initiating BACPAC export to directory: $(dirname "$targetFilePath")"

# Execute the sqlpackage export command
eval $sqlPackageExportCommand

# Inform the user about the export completion
echo "BACPAC export completed."

# Ask the user if they want to proceed with the import
read -p "Do you want to import the BACPAC into a new database? (y/n): " importChoice

# Check the user's choice
if [[ $importChoice =~ ^[Yy]$ ]]; then
    # Prompt the user for the new database name
    read -p "Enter the name of the new database (Leave blank for default): " newDatabaseName

    if [ -z "$newDatabaseName" ]; then
        newDatabaseName=$(generateDefaultDatabaseName)
    fi

    importBacpac "$targetFilePath" "$newDatabaseName"
else
    echo "No import operation performed. Exiting..."
fi
