create schema Monster; -- A group of tables; like a namespace.
go

create table Monster.Monster
(
    MonsterId int not null identity(1, 1), -- Identity is MS SQL's auto increment.
    GenderId int null,
    TitleId int null, -- nvarchar is the UTF-8 version of varchar (which is ASCII)
    TypeId int not null,
    Name nvarchar(250) not null,
    PicturePath nvarchar(256) null,
    Active bit not null
);
GO

create index ix_monster_name
    on Monster.Monster (Name);
GO

create table Monster.MonsterType
(
    MonsterTypeId int not null identity(1, 1) primary key,
    TypeName nvarchar(250) not null,
    Active bit not null
);
GO

create table Monster.Gender
(
    GenderId int not null identity(1, 1) primary key,
    GenderName nvarchar(250) not null,
    Active bit not null
);
GO

create table Monster.Title
(
    TitleId int not null identity(1, 1) primary key,
    TitleName nvarchar(25) not null,
    Active bit not null
);
GO

alter table Monster.Monster
    add constraint pk_monster_monsterid primary key clustered (MonsterId); -- Clustered index is ordered (like dictionary). Non-clustered is like the index page.
GO

alter table Monster.Monster
    add constraint fk_monster_genderid foreign key (GenderId) references Monster.Gender (GenderId);
GO

alter table Monster.Monster
    add constraint fk_monster_titleid foreign key (TitleId) references Monster.Title (TitleId);
GO

alter table Monster.Monster
    add constraint fk_monster_typeid foreign key (TypeId) references Monster.MonsterType (MonsterTypeId);
GO