
CREATE DATABASE TLNEnglish
GO

USE TLNEnglish;  
GO  
ALTER DATABASE TLNEnglish  
COLLATE Latin1_general_CI_AI ;  
GO

CREATE TABLE categoryfilm(
	id INT PRIMARY KEY IDENTITY(1,1),
	[level] INT NOT NULL,
	[name] nvarchar(50) NOT NULL,
	pointword tinyint NOT NULL,
	dataDb varchar(200),
);
GO

CREATE TABLE extraone(
	id INT PRIMARY KEY IDENTITY(1,1),
	audioquestion varchar(50) NOT NULL,
	textquestion nvarchar(100) NOT NULL,
	audioanswer varchar(50) NOT NULL,
	textanswer nvarchar(100) NOT NULL,
	categoryfilmid int NOT NULL,
	doubtid varchar(70),
	unselectid varchar(70),
	dataDb varchar(200),
);
GO 

CREATE TABLE [user](
	id INT PRIMARY KEY IDENTITY(100000,1),
	[name] nvarchar(50) NOT NULL,
	[email] varchar(50) NOT NULL,
	[phone] varchar(20),
	[password] varchar(50) NOT NULL,
	filmleanning varchar(max),
	point INT,
	listfrendid varchar(max),
	dataDb varchar(200)
);
GO

CREATE TABLE tips(
	id INT PRIMARY KEY IDENTITY(1,1),
	content nvarchar(100) NOT NULL,
	dataDb varchar(200)
)

CREATE TABLE [files](
	id INT PRIMARY KEY IDENTITY(1,1),
	audioquestion varbinary NOT NULL,
	audioanswer varbinary NOT NULL,
	data varchar(300),
	dataDb varchar(200)
);
GO


alter table [dbo].[tips] add  dataDb varchar(100);
GO