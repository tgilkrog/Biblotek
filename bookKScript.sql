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
	picture varchar(max),
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

INSERT INTO Book values('Necronomicon', 'Lovecraft', 1234, 'https://plusbog-v2-dk.s3.amazonaws.com/covers/variations/000237/000237068_necronomicon_h_p_lovecraft-9780575081567_1_0.jpg', 1);
INSERT INTO Book values('IT', 'Stephen King', 6235, 'https://prodimage.images-bn.com/pimages/9781982127794_p0_v3_s550x406.jpg', 1);
INSERT INTO Book values('Animal Farm', 'George Orwell', 1236, 'https://fewdaybook.com/wp-content/uploads/2019/05/Animal-Farm.jpg', 1);
INSERT INTO Book values('Metro 2033', 'Dmitrij Gluchovskij', 0987, 'https://cdn.waterstones.com/bookjackets/large/9780/5750/9780575086258.jpg', 1);
INSERT INTO Book values('Home Cooking', 'Gordon Ramsay',  8732, 'https://images-na.ssl-images-amazon.com/images/I/91%2BwwPKKfpL.jpg', 1);