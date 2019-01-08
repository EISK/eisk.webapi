SOURCE_DIR=$PWD
TEMP_REPO_DIR=$PWD/rendered-templated-content-repo

echo "Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_REPO_DIR
mkdir $TEMP_REPO_DIR

echo "Cloning the repo with the b102332 branch"
git clone https://github.com/EISK/eisk.webapi.git --branch b102332 $TEMP_REPO_DIR

echo "Clear repo directory"
cd $TEMP_REPO_DIR
git rm -r *

echo "Copy documentation into the repo"
cp -r $SOURCE_DIR/dnn-local-template-render/* .

echo "Push the new docs to the remote branch"
git add . -A
git commit -m "Update generated documentation"
git push origin b102332