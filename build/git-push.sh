GitTargetRepo=${1:-.}
GitUserName=${2}
GitUserEmail=${3}

ContentSrc=${4:-content-src}

GitTargetBranch=${5:-content}
GitTargetRepoDownloadFolder=${6:-content-repo}

git config --global user.name $GitUserName
git config --global user.email $GitUserEmail

SOURCE_DIR=$PWD
TEMP_REPO_DIR=$PWD/$GitTargetRepoDownloadFolder

echo "############################# Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_REPO_DIR
mkdir $TEMP_REPO_DIR

echo "############################# Cloning the repo with the content branch"
git clone $GitTargetRepo --branch $GitTargetBranch $TEMP_REPO_DIR

echo "############################# Clear repo directory"
cd $TEMP_REPO_DIR
git rm -r *

echo "Copy documentation into the repo"
cp -r $SOURCE_DIR/$ContentSrc/* .

echo "############################# Push contents to the remote branch"
git add . -A
git commit -m "Update content"
git push origin $GitTargetBranch
