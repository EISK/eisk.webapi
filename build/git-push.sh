ContentTargetGitAddress=${1:-https://github.com/EISK/eisk.webapi.git}
ContentTargetGitUserName=${2:-AshrafAlam}
ContentTargetGitUserEmail=${3:-joycsc@gmail.com}

ContentSrc=${4:-content}

ContentTargetGitBranch=${5:-content-branch}
ContentTargetGitRepoDownloadFolder="content-repo"

SOURCE_DIR=$PWD
TEMP_REPO_DIR=$PWD/$ContentTargetGitRepoDownloadFolder

echo "############################# Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_REPO_DIR
mkdir $TEMP_REPO_DIR

echo "############################# Cloning the repo with the content branch"
git clone $ContentTargetGitAddress --branch $ContentTargetGitBranch $TEMP_REPO_DIR

echo "############################# Clear repo directory"
cd $TEMP_REPO_DIR
git rm -r *

echo "Copy documentation into the repo"
cp -r $SOURCE_DIR/$ContentSrc/* .

echo $PWD

echo "Copy gitignore"
cp ./../../.gitignore .

echo "############################# Setting git identity"
if [ "$2" != "" ]; then
	git config user.name $ContentTargetGitUserName
fi

if [ "$3" != "" ]; then
	git config user.email $ContentTargetGitUserEmail
fi

echo "############################# Push contents to the remote branch"
git add . -A
git commit -m "Updated with minor changes."
git push origin $ContentTargetGitBranch
