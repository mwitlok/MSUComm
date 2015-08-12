set /p cont=Overwrite any and all local changes?(y/n)
IF [%cont%]==[n] goto e
git fetch --all
git reset --hard origin/master
:e