create database railwayDB;

create table Railwaytbl(

RID int primary key identity(100,1),
PassengerName varchar(25) not null,
PhoneNo int unique  not null,
Railway varchar(25) not null,
FromCity varchar(25) not null,
ToCity varchar(25) not null,
TravelDate varchar(25) not null,
TicketPrice int not null,
NoSeats int not null,
Total int not null
);

select *from Railwaytbl;



create database railwayDB;


create table logintbl( UID int identity(100,1) primary key, Email varchar(25) not null unique, pass varchar(25) not null , role varchar(22) not null);

insert into logintbl values('Ahmed','123','Admin');
insert into logintbl values('Abdullah','123','Admin');
insert into logintbl values('Sabih','123','Admin');
insert into logintbl values('Sufiyan','123','Admin');