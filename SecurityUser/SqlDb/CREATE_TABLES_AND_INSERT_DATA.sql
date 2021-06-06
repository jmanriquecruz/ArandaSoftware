/*
Por comodida se genero un solo script para todas las tablas , lo correcto es que la data y cada tabla este en un script aparte
*/
if not exists(SELECT * FROM sys.databases WHERE name = 'ArandaSoftDB')
begin 
    create database [ArandaSoftDB]
end 

use [ArandaSoftDB]

if Object_id('dbo.User') is not null
begin
	drop table dbo.[User]
end
GO

if Object_id('dbo.Role_Permission') is not null
begin
	drop table dbo.Role_Permission
end

GO

if Object_id('dbo.Role') is not null
begin
	drop table dbo.Role
end
GO

if Object_id('dbo.Permission') is not null
begin
	drop table dbo.Permission
end
GO


create table Role(
	[IdRole] [int] IDENTITY(1,1)  not null,
	[Name] [varchar](50) not null,
	constraint PK_Role primary key (IdRole)

)
set identity_insert [dbo].[Role] ON
insert  into [dbo].[Role] ([IdRole], [Name] ) values(1,'Administrador')
insert  into [dbo].[Role] ([IdRole], [Name] ) values(2,'Visitante')
insert  into [dbo].[Role] ([IdRole], [Name] ) values(3,'Asistente')
insert  into [dbo].[Role] ([IdRole], [Name] ) values(4,'Editor')
set identity_insert [dbo].[Role] OFF

create table [User](
	[IdUser] [int] identity (1,1) not null,
	[LoginName] [varchar](50) not null,
	[Password] [varchar](50) not null,
	[Names] [varchar](100) not null,
	[Address] [varchar](50) not null,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](30) not null,
	[Age] [int]  null,
	[IdRole] [int] not null,
	constraint PK_User primary key (IdUser),
	constraint FK_Role_User foreign key ([IdRole]) references Role([IdRole])
)

set identity_insert [dbo].[User] ON
insert  into [dbo].[User] ([IdUser], [LoginName], [Password], [Names], [Address], [PhoneNumber], [Email], [Age],[IdRole] ) 
values (1, N'admon', N'123', N'jose manrique', N'Avenida carrera 19', N'3108720506', N'jmanrique@gmail.com', 35, 1)
set identity_insert [dbo].[User] OFF


create table Permission(
	[IdPermission] [int] identity(1,1) not null,
	[PermissionType] [varchar](100) not null,
	constraint PK_Permission primary key (IdPermission),
)

set identity_insert [dbo].[Permission] ON
insert  into [dbo].[Permission] ([IdPermission], [PermissionType]) values(1,'canAccessListUser')
insert  into [dbo].[Permission] ([IdPermission], [PermissionType]) values(2,'canAddUser')
insert  into [dbo].[Permission] ([IdPermission], [PermissionType]) values(3,'canEditUser')
insert  into [dbo].[Permission] ([IdPermission], [PermissionType]) values(4,'canDeleteUser')
insert  into [dbo].[Permission] ([IdPermission], [PermissionType]) values(5,'canAccessNews')
set identity_insert [dbo].[Permission] OFF

create table Role_Permission(
	[IdRole] [int]  not null,
	[IdPermission] [int]  not null,
	[Value] bit not null ,
	constraint PK_Role_Permission primary key (IdRole,IdPermission),
	constraint FK_Role_Permision foreign key (IdRole) references Role(IdRole),
	constraint FK_Permission_P foreign key (IdPermission) references Permission(IdPermission),
)


insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(1,1,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(1,2,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(1,3,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(1,4,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(1,5,1)

insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(2,1,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(2,2,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(2,3,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(2,4,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(2,5,1)

insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(3,1,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(3,2,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(3,3,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(3,4,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(3,5,1)

insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(4,1,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(4,2,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(4,3,1)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(4,4,0)
insert  into [dbo].[Role_Permission] ([IdRole], [IdPermission],[Value]) values(4,5,1)



