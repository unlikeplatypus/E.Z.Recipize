create table Person(
	PersonId int not null primary key,
	FistName varchar(50) not null,
	LastName varchar(50) not null,
	Occupation varchar(100) null
)
go

create table Bulldogs(
	BulldogId int not null primary key,
	[Name] varchar(50) not null,
	Nickname varchar(50) null,
	DoB date not null check(DoB <= getdate()),
	Age int not null check(Age >= 0),
	PrimaryPersonId int not null references Person(PersonId) --refers to valid PersonId
)
go

create table Colors(
	ColorId int not null primary key,
	[Name] varchar(50) not null
)
go
