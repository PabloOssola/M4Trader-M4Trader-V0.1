﻿ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [FG_Precios_File], FILENAME = 'C:\SQL\Log\MONEDAS_File.ndf', SIZE = 1048576 KB, FILEGROWTH = 25 %) TO FILEGROUP [FG_Precios_001];

