cd ../
mkdir tmp
cd tmp
git clone https://tobiah:3gxtjtmsts2nusi75jbrpnzg5dlmpbhdhecs7ilv7d6nlcmgo5oa@usdxhackathon-devops.visualstudio.com/_git/JenkinsBuildPipeline repo
cd repo
git rm -r .
cp -R ../../BouncyBallGame/Builds/WSA/* ./
git add . -f
git commit -m "New version!"
git push