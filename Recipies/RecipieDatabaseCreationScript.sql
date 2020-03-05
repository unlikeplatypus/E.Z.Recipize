use Recipies
go

/****** Object:  Table [dbo].[RecipieStep]    Script Date: 2/21/2020 7:06:22 PM ******/
DROP TABLE [dbo].[RecipieStep]
GO
/****** Object:  Table [dbo].[Recipie]    Script Date: 2/21/2020 7:06:09 PM ******/
DROP TABLE [dbo].[Recipie]
GO


create table Recipie(
	RecipieId int IDENTITY(1,1) primary key,
	RecipieName varchar not null,
	RecipieDescription varchar not null
	
)

create table RecipieStep(
	RecipieId int not null references Recipie(RecipieId),
	StepNum int not null,
	primary key(RecipieId, StepNum),
	IsTimer bit not null,
	Timer float not null,
	Ingredients varchar null,--[name, amount, unit, specialinstrucions]
	RequiredCookware varchar null,--name, name, name
	SuggestedCookware varchar null --name, name, name

)