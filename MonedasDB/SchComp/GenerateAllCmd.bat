SET DriveSpec=D:
SET BasePath=tfs\mae-ordenes\trunk\Datos\mae.ordenes.DB
SET DacPath=bin\Debug
SET PreDeployPath=PreDeploymentScripts
SET PostDeployPath=PostDeploymentScripts
SET SourceDB=SORFIX_Limpia
SET DBServer=.\SQL2016
SET User=MAE\llezama
SET Password=luciano6
SET TargetDB=SORFIX_Limpia
SET SourceCodeDacPac=mae.ordenes.DB

sqlcmd.exe -S %DBServer% -d SORFIX_Limpia -i %DriveSpec%\%BasePath%\%PreDeployPath%\DMA.pre.deploy.sql
sqlpackage.exe /a:Extract /ssn:%DBServer% /sdn:%SourceDB% /su:%User% /sp:%Password% /tf:%DriveSpec%\%BasePath%\%DacPath%\%SourceDB%_baseline.dacpac
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild /p:VisualStudioVersion=14.0
sqlpackage.exe /a:Script /sf:%DriveSpec%\%BasePath%\%DacPath%\%SourceDB%_baseline.dacpac /tf:%DriveSpec%\%BasePath%\%DacPath%\%SourceCodeDacPac%.dacpac /tdn:%TargetDB% /p:DropObjectsNotInSource=true /op:%DriveSpec%\%BasePath%\%DacPath%\SorFixDbUpdate.sql
sqlcmd.exe -S %DBServer% -d SORFIX_Limpia -i %DriveSpec%\%BasePath%\%DacPath%\SorFixDbUpdate.sql
sqlcmd.exe -S %DBServer% -d SORFIX_Limpia -i %DriveSpec%\%BasePath%\%PostDeployPath%\DMA.post.deploy.sql
