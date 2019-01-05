SOURCE_DIR=$PWD
TEMP_REPO_DIR=$PWD/rendered-templated-content-repo

echo "Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_REPO_DIR
mkdir $TEMP_REPO_DIR

echo "Cloning the repo with the gh-pages branch"
git clone https://ashrafalam@dev.azure.com/starter-ops/starter/_git/template-experiment --branch rendered-templated-content $TEMP_REPO_DIR

echo "Clear repo directory"
cd $TEMP_REPO_DIR
git rm -r *

echo "Copy documentation into the repo"
cp -r $SOURCE_DIR/dnn-template-render/* .

echo "Push the new docs to the remote branch"
git add . -A
git commit -m "Update generated documentation"
git push origin rendered-templated-content