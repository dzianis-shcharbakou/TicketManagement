msbuild SqlProject\SqlProject.sln /t:Rebuild
msbuild /t:Publish /p:SqlPublishProfilePath="SqlProject.publish.xml" SqlProject\SqlProject.sqlproj
msbuild /t:Publish /p:SqlPublishProfilePath="SqlProjectTest.publish.xml" SqlProject\SqlProject.sqlproj
powershell -noexit