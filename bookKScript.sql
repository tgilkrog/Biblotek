use master;
if exists (select * from sys.databases where name='bookK')
	drop database bookK;
go
create database bookK;
go

use bookK;

CREATE TABLE bookKUser(
	id int primary key identity(1,1),
	userName varchar(50) NOT NULL
);

CREATE TABLE Book(
	id int primary key identity(1,1),
	title varchar(50) NOT NULL,
	author varchar(50) NOT NULL,
	isbn int NOT NULL,
	available bit NOT NULL
);

CREATE TABLE Booking(
	id int primary key identity(1,1),
	userId int NOT NULL foreign key references bookKUser(id),
	bookId int NOT NULL foreign key references Book(id),
	returned bit NOT NULL
);


INSERT INTO bookKUser values('Thais Gilkrog');
INSERT INTO bookKUser values('Peter Petersen');
INSERT INTO bookKUser values('Jens Jensen');

INSERT INTO Book values('Necronomicon', 'Lovecraft', 1234, 1);
INSERT INTO Book values('IT', 'Stephen King', 1235, 1);
INSERT INTO Book values('Animal Farm', 'George Orwell', 1236, 1);
INSERT INTO Book values('Food', 'Gordon', 1236, 1);
INSERT INTO Book values('Drinks', 'Marie', 1236, 1);