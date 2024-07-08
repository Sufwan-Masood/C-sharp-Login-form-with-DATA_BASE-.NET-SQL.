Create Database WINFORM_DB;

Create Table LOGIN_TABLE(
USERNAME varchar (255) not null,
PASS	varchar (255) not null
);

Insert into LOGIN_TABLE (USERNAME,PASS)
Values ('Qasim','123'),
		('saim','456');

Select * from LOGIN_TABLE;
select * from BIO_DATA;