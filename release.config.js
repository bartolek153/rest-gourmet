module.exports = {
    branches: 'main',  // TODO: Change to 'main' when ready to release
    plugins: [
        '@semantic-release/commit-analyzer', 
        '@semantic-release/release-notes-generator', 
        '@semantic-release/github'
    ]
}
