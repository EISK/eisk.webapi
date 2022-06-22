echo "############################# Passed Params (before) 1 - $1, 2 - $2, 3 - $3, 4 - $4, 5 - $5 6 - $6"

ContentTargetGitAddress=${1:-https://github.com/EISK/eisk.webapi.git}
echo "############################# ContentTargetGitAddress ContentTargetGitAddress"

ContentTargetGitUserName=${2:-AshrafAlam}
echo "############################# ContentTargetGitUserName $ContentTargetGitUserName"

ContentTargetGitUserEmail=${3:-joycsc@gmail.com}
echo "############################# ContentTargetGitUserEmail $ContentTargetGitUserEmail"

ContentSrc=${4:-content}
echo "############################# ContentSrc $ContentSrc"

ContentTargetGitBranch=${5:-content-branch}
echo "############################# ContentTargetGitBranch $ContentTargetGitBranch"

ContentTargetGitRepoDownloadFolder="content-repo"
echo "############################# ContentTargetGitRepoDownloadFolder (where content will be pushed) $ContentTargetGitRepoDownloadFolder"

echo "############################# PWD $PWD"

SOURCE_DIR=$PWD
echo "############################# SOURCE_DIR $SOURCE_DIR"

TEMP_REPO_DIR=$PWD/$ContentTargetGitRepoDownloadFolder
echo "############################# TEMP_REPO_DIR $TEMP_REPO_DIR"

echo "############################# Passed Params (after) 1 - $1, 2 - $2, 3 - $3, 4 - $4, 5 - $5 6 - $6"