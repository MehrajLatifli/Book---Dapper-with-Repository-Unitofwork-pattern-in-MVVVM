create database BookDapper


use BookDapper


create table Books
(
IdBook int primary key IDENTITY (1,1) NOT NULL,
BookName nvarchar(max) NOT NULL,
BookPrice money NOT NULL,
BookQuantity bigint NOT NULL,

Constraint CK_BookName Check(BookName <>' '),
)


insert into BookDapper.dbo.Books(BookDapper.dbo.Books.BookName, BookDapper.dbo.Books.BookPrice, BookDapper.dbo.Books.BookQuantity)
values
(N'BookName_1', 5, 5),
(N'BookName_2', 15, 15),
(N'BookName_3', 25, 5),
(N'BookName_4', 45, 15),
(N'BookName_5', 50, 10),
(N'BookName_6', 5, 15),
(N'BookName_7', 10, 15),
(N'BookName_8', 15, 20),
(N'BookName_9', 20, 25),
(N'BookName_10',25, 10)




select IdBook, BookName, BookPrice, BookQuantity from Books


