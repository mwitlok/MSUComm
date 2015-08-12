set /p cont=Overwrite any and all data on GitHub with your local files?(y/n)
IF [%cont%]==[n] goto e
git push -f origin master
:e