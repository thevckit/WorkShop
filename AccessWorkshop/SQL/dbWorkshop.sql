-- database dbWorkshop

create database [dbWorkshop]

use [master]
use [dbWorkshop]


create table [Gender](
	
	[GenderCode]	nchar(1)	 not null,
	[Title]			nvarchar(20) not null
	constraint pk_Gender_GenderCode primary key ([GenderCode])
)
go

insert [Gender] ([GenderCode], [Title]) values ('F', 'Female')
insert [Gender] ([GenderCode], [Title]) values ('M', 'Male')

create table [Course](
	
	[ID]			int				not null,
	[CourseID]		int				not null,
	constraint pk_Course_ID	primary key ([ID])
)
go

create table [Department] (
	
	[ID]		nchar(5)		not null,
	[Title]		nvarchar(50)	not null,
	constraint pk_Department_ID primary key ([ID])
)
go


create table [Group](
	
	[ID]			int not null,
	[GroupID]		int not null,
	[IDCourse]		int constraint fk_Group_IDCourse_Course_ID foreign key references [Course]([ID]) on delete cascade not null,
	[IDDepartment]	nchar(5) constraint fk_Group_IDDepartment_Department_ID foreign key references [Department]([ID]) on delete cascade not null
	constraint pk_Group_ID primary key ([ID])
)
go


create table [WorkShop](
	
	[ID]			int identity,
	[Number]		int				not null,
	[Compitation]	nvarchar(max)	not null
	constraint pk_WorkShop_ID primary key ([ID])
)
go



create table [Student] (

	[ID]			int identity,
	[FirstName]		nvarchar(max)	not null,
	[LastName]		nvarchar(max)	not null,
	[Patronymic]	nvarchar(max)	not null,
	[IDGender]		nchar(1) constraint fk_Student_IDGender_Gender_GenderCode foreign key references [Gender]([GenderCode]) on delete cascade,
	[Phone]			nvarchar(max)	not null,
	[Email]			nvarchar(40)	constraint Student_Email_Unique unique not null,
	[IDGroup]		int constraint fk_Student_IDGroup_Group_ID	foreign key references [Group]([ID]) on delete cascade not null,
	[IDWorkShop]	int	constraint fk_Student_IDWorkShop_WorkShop_ID foreign key references [WorkShop]([ID]) on delete cascade
	constraint pk_ID_Student primary key ([ID])
)
go


create table [Role] (
	
	[RoleID]	nchar(1)		not null,
	[Title]		nvarchar(40)	not null,
	constraint pk_Role_RoleID	primary key ([RoleID])
)
go

insert [Role] ([RoleID], [Title]) values ('A', 'Admin')
insert [Role] ([RoleID], [Title]) values ('S', 'Security')
insert [Role] ([RoleID], [Title]) values ('H', 'Head')

create table [User] (

	[ID]			int identity	not null,
	[Email]			varchar(40)	constraint Unique_User_Email unique not null,
	[Password]		nvarchar(40)	not null,
	[FirstName]		nvarchar(40)	not null,
	[LastName]		nvarchar(40)	not null,
	[Phone]			nchar(20)		not null,
	[IDRole]		nchar(1)	constraint fk_User_IDRole_Role_RoleID foreign key references [Role]([RoleID]) on delete cascade not null,
	[IDWorkShop]	int	constraint fk_User_IDWorkShop_WorkShop_ID foreign key references [WorkShop]([ID]) on delete cascade not null
	constraint pk_User_ID primary key ([ID])
)
go

create table [TimeWorkShop](
	
	[ID]	int identity,
	[IDWorkShop] int constraint fk_IDWorkShop_Time_Workshop_ID foreign key references [WorkShop]([ID]) on delete cascade not null,
	[Time]	time	not null,
	[Date]	date	not null,
	constraint pk_TimeWorkShop_ID	primary key ([ID])
)
go