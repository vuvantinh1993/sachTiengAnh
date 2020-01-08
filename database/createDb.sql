USE TLNEnglish;  
GO  
ALTER DATABASE TLNEnglish  
COLLATE Latin1_general_CI_AI ;  
GO

CREATE TABLE categoryfilm(
	id INT PRIMARY KEY IDENTITY(1,1),
	[level] INT NOT NULL,
	[name] nvarchar(50) NOT NULL,
	dataDb varchar(100),
);
GO

CREATE TABLE easy(
	id INT PRIMARY KEY IDENTITY(1,1),
	audioquestion varchar(50) NOT NULL,
	textquestion nvarchar(100) NOT NULL,
	audioanswer varchar(50) NOT NULL,
	textanswer nvarchar(100) NOT NULL,
	categoryfilmid int NOT NULL,
	doubtid varchar(70),
	unselectid varchar(70),
	dataDb varchar(100),
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
	dataDb varchar(100)
);
GO