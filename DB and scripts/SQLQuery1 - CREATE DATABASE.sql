CREATE DATABASE DB_Smart_Fitness_1
ON
(
NAME = DB_Smart_Fitness_1,
FILENAME = 'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_Smart_Fitness_1.mdf',
SIZE = 8 MB,
MAXSIZE = 500 MB,
FILEGROWTH = 8 MB
)
LOG ON
(
NAME = DB_Smart_Fitness_1_Log,
FILENAME = 'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_Smart_Fitness_1.ldf',
SIZE = 8 MB,
MAXSIZE = 500 MB,
FILEGROWTH = 8 MB
);