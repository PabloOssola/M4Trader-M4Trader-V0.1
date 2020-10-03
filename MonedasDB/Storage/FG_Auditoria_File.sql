ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [FG_Auditoria_File], FILENAME = 'C:\SQL\Log\MONEDAS_Auditoria_File.ndf', SIZE = 1048576 KB, FILEGROWTH = 25 %) TO FILEGROUP [FG_Auditoria_001];

