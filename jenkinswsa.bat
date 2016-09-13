cd Builds
mkdir tmp
cd tmp
git clone tobiah:3gxtjtmsts2nusi75jbrpnzg5dlmpbhdhecs7ilv7d6nlcmgo5oa@https://usdxhackathon-devops.visualstudio.com/_git/JenkinsBuildPipeline 
git rm -r *
cp -R ../WSA/*
git add .
git commit -m "New version!"
git push