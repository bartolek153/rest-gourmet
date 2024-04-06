module.exports = {
    brancher: 'main',
    verifyConditions: [
        '@semantic-release/changelog',
        '@semantic-release/git',
        '@semantic-release/github',
    ],
    publish: [
        '@semantic-release/commit-analyzer',
        '@semantic-release/release-notes-generator',
        '@semantic-release/changelog',
        '@semantic-release/git',
    ],
}
