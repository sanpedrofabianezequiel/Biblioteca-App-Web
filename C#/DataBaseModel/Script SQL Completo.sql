/* CREACION DE LA BASE DE DATOS */
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'BOOKS')
CREATE DATABASE [BOOKS]
GO


/*CREACION DE ESTRUCTURA DE TABLAS*/
/**************************************************************************************/
/*
AUTHOR
PUBLISHER
CATEGORY
BOOK
*/

USE BOOKS
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[AUTHOR]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [AUTHOR]
(
	[AuthorId] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[AuthorName] [varchar](50) NOT NULL UNIQUE,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[PostCode] [varchar](50) NULL,
	[PostAddress] [varchar](50) NULL,
) 
GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[PUBLISHER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [PUBLISHER]
(
	[PublisherId] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[PublisherName] [varchar](50) NOT NULL UNIQUE,
	[Description] [varchar](1000) NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[PostCode] [varchar](50) NULL,
	[PostAddress] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,	
) 
GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[CATEGORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [CATEGORY]
(
	[CategoryId] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[CategoryName] [varchar](50) NOT NULL UNIQUE,
	[Description] [varchar](1000) NULL,
) 
GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[BOOK]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [BOOK]
(
	[BookId] [int] IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Title] [varchar](50) NOT NULL UNIQUE,
	[ISBN] [varchar](20) NOT NULL,
	[PublisherId] [int] NOT NULL FOREIGN KEY REFERENCES [PUBLISHER] ([PublisherId]),
	[AuthorId] [int] NOT NULL FOREIGN KEY REFERENCES [AUTHOR] ([AuthorId]),
	[CategoryId] [int] NOT NULL FOREIGN KEY REFERENCES [CATEGORY] ([CategoryId]),
	[Description] [varchar](1000) NULL,
	[Year] [date] NULL,
	[Edition] [int] NULL,
	[AverageRating] [float] NULL,
) 
GO



/**********************************************************************************************/
/*GetBookData.view.sql*/
/**********************************************************************************************/
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = 'GetBookData' 
	   AND 	  type = 'V')
	DROP VIEW GetBookData
GO

CREATE VIEW GetBookData
AS

SELECT
BOOK.BookId, 
BOOK.Title, 
BOOK.ISBN, 
PUBLISHER.PublisherName, 
AUTHOR.AuthorName, 
CATEGORY.CategoryName

FROM BOOK 
INNER JOIN AUTHOR ON BOOK.AuthorId = AUTHOR.AuthorId 
INNER JOIN PUBLISHER ON BOOK.PublisherId = PUBLISHER.PublisherId 
INNER JOIN CATEGORY ON BOOK.CategoryId = CATEGORY.CategoryId

GO
	
/**********************************************************************************************/
/*CreateBook.sp.sql*/
/**********************************************************************************************/
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = 'CreateBook' 
	   AND 	  type = 'P')
	DROP PROCEDURE CreateBook
GO

CREATE PROCEDURE CreateBook
@Title varchar(50),
@Isbn varchar(20),
@PublisherName varchar(50),
@AuthorName varchar(50),
@CategoryName varchar(50)
AS

if not exists (select * from CATEGORY where CategoryName = @CategoryName)
	INSERT INTO CATEGORY (CategoryName) VALUES (@CategoryName)

if not exists (select * from AUTHOR where AuthorName = @AuthorName)
	INSERT INTO AUTHOR (AuthorName) VALUES (@AuthorName)

if not exists (select * from PUBLISHER where PublisherName = @PublisherName)
	INSERT INTO PUBLISHER (PublisherName) VALUES (@PublisherName)


if not exists (select * from BOOK where Title = @Title)
	INSERT INTO BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId) 
	VALUES 
	(
	@Title,
	@ISBN, 
	(select PublisherId from PUBLISHER where PublisherName=@PublisherName),
	(select AuthorId from AUTHOR where AuthorName=@AuthorName),
	(select CategoryId from CATEGORY where CategoryName=@CategoryName)
	)


GO


	
/**********************************************************************************************/
/*DeleteBook.sp.sql*/
/**********************************************************************************************/
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = 'DeleteBook' 
	   AND 	  type = 'P')
	DROP PROCEDURE DeleteBook
GO

CREATE PROCEDURE DeleteBook
@BookId int
AS


delete from BOOK where BookId=@BookId


GO


	
/**********************************************************************************************/
/*UpdateBook.sp.sql*/
/**********************************************************************************************/
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = 'UpdateBook' 
	   AND 	  type = 'P')
	DROP PROCEDURE UpdateBook
GO

CREATE PROCEDURE UpdateBook
@BookId int,
@Title varchar(50),
@ISBN varchar(20),
@PublisherName varchar(50),
@AuthorName varchar(50),
@CategoryName varchar(50)
AS



--execute UpdateeBook BookId, 'Title', 'Author', 'Publisher', 'ISBN', 'Category'

if not exists (select * from CATEGORY where CategoryName = @CategoryName)
	INSERT INTO CATEGORY (CategoryName) VALUES (@CategoryName)

if not exists (select * from AUTHOR where AuthorName = @AuthorName)
	INSERT INTO AUTHOR (AuthorName) VALUES (@AuthorName)

if not exists (select * from PUBLISHER where PublisherName = @PublisherName)
	INSERT INTO PUBLISHER (PublisherName) VALUES (@PublisherName)



UPDATE BOOK SET
Title = @Title, 
ISBN = @ISBN, 
PublisherId = (select PublisherId from PUBLISHER where PublisherName=@PublisherName), 
AuthorId = (select AuthorId from AUTHOR where AuthorName=@AuthorName), 
CategoryId = (select CategoryId from CATEGORY where CategoryName=@CategoryName) 
	 
WHERE BookId = @BookId

GO


	
/**********************************************************************************************/
/*Insert Data into Tables.sql*/
/**************************************************************************************/
/*
CATEGORY
AUTHOR
PUBLISHER
BOOK
*/


--CATEGORY ----------------------------------
INSERT INTO CATEGORY (CategoryName) 
VALUES ('Science')
GO
INSERT INTO CATEGORY (CategoryName) 
VALUES ('Programming')
GO
INSERT INTO CATEGORY (CategoryName) 
VALUES ('Novel')
GO

--AUTHOR ----------------------------------
INSERT INTO AUTHOR (AuthorName) 
VALUES ('Knut Hamsun')
GO
INSERT INTO AUTHOR (AuthorName) 
VALUES ('Gilbert Strang')
GO
INSERT INTO AUTHOR (AuthorName) 
VALUES ('J.R.R Tolkien')
GO
INSERT INTO AUTHOR (AuthorName) 
VALUES ('Dorf Bishop')
GO

--PUBLISHER ----------------------------------
INSERT INTO PUBLISHER (PublisherName) 
VALUES ('Prentice Hall')
GO
INSERT INTO PUBLISHER (PublisherName) 
VALUES ('Wiley')
GO
INSERT INTO PUBLISHER (PublisherName) 
VALUES ('McGraw-Hill')
GO

--BOOK ----------------------------------
INSERT INTO BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId) 
VALUES 
(
'Introduction to Linear Algebra',
'0-07-066781-0', 
(select PublisherId from PUBLISHER where PublisherName='Prentice Hall'),
(select AuthorId from AUTHOR where AuthorName='Gilbert Strang'),
(select CategoryId from CATEGORY where CategoryName='Science')
)
GO

INSERT INTO BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId) 
VALUES 
(
'Modern Control System',
'1-08-890781-0',  
(select PublisherId from PUBLISHER where PublisherName='Wiley'),
(select AuthorId from AUTHOR where AuthorName='Dorf Bishop'),
(select CategoryId from CATEGORY where CategoryName='Programming')
)
GO

INSERT INTO BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId) 
VALUES 
(
'The Lord of the Rings',
'2-09-066556-2',  
(select PublisherId from PUBLISHER where PublisherName='McGraw-Hill'),
(select AuthorId from AUTHOR where AuthorName='J.R.R Tolkien'),
(select CategoryId from CATEGORY where CategoryName='Novel')
)
GO

