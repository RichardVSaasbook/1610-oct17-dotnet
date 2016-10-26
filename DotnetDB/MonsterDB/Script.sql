--CREATE SCHEMA Monster; -- A group of tables; like a namespace.
--GO

--CREATE TABLE Monster.Monster (
--    MonsterId INT NOT NULL IDENTITY(1, 1), -- Identity is MS SQL's auto increment.
--    GenderId INT NULL,
--    TitleId INT NULL, -- nvarchar is the UTF-8 version of varchar (which is ASCII)
--    TypeId INT NOT NULL,
--    Name NVARCHAR(250) NOT NULL,
--    PicturePath NVARCHAR(256) NULL,
--    Active BIT NOT NULL
--);
--GO

--CREATE INDEX ix_monster_name
--    ON Monster.Monster (Name);
--GO

--CREATE TABLE Monster.MonsterType (
--    MonsterTypeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    TypeName NVARCHAR(250) NOT NULL,
--    Active BIT NOT NULL
--);
--GO

--CREATE TABLE Monster.Gender (
--    GenderId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    GenderName NVARCHAR(250) NOT NULL,
--    Active BIT NOT NULL
--);
--GO

--CREATE TABLE Monster.Title (
--    TitleId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    TitleName NVARCHAR(25) NOT NULL,
--    Active BIT NOT NULL
--);
--GO

--ALTER TABLE Monster.Monster
--    ADD CONSTRAINT pk_monster_monsterid PRIMARY KEY CLUSTERED (MonsterId); -- Clustered index is ordered (like dictionary). Non-clustered is like the index page.
--GO

--ALTER TABLE Monster.Monster
--    ADD CONSTRAINT fk_monster_genderid FOREIGN KEY (GenderId) REFERENCES Monster.Gender (GenderId);
--GO

--ALTER TABLE Monster.Monster
--    ADD CONSTRAINT fk_monster_titleid FOREIGN KEY (TitleId) REFERENCES Monster.Title (TitleId);
--GO

--ALTER TABLE Monster.Monster
--    ADD CONSTRAINT fk_monster_typeid FOREIGN KEY (TypeId) REFERENCES Monster.MonsterType (MonsterTypeId);
--GO

--CREATE SCHEMA Media;
--GO

--CREATE TABLE Media.Media (
--    MediaId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    Title NVARCHAR(250) NOT NULL,
--    ScareFactorId INT NOT NULL,
--    MonsterId INT NOT NULL,
--    GenreId INT NOT NULL,
--    MediaTypeId INT NOT NULL
--);
--GO

--CREATE TABLE Media.ScareFactor (
--    ScareFactorId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    "Description" NVARCHAR(250) NOT NULL
--);
--GO

--CREATE TABLE Media.Genre (
--    GenreId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    "Description" NVARCHAR(250) NOT NULL
--);
--GO

--CREATE TABLE Media.MediaType (
--    MediaTypeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--    Name NVARCHAR(100) NOT NULL
--);
--GO

--ALTER TABLE Media.Media
--    ADD CONSTRAINT fk_media_scarefactorid FOREIGN KEY (ScareFactorId) REFERENCES Media.ScareFactor(ScareFactorId);
--GO

--ALTER TABLE Media.Media
--    ADD CONSTRAINT fk_media_monsterid FOREIGN KEY (MonsterId) REFERENCES Monster.Monster(MonsterId);
--GO

--ALTER TABLE Media.Media
--    ADD CONSTRAINT fk_media_genreid FOREIGN KEY (GenreId) REFERENCES Media.Genre(GenreId);
--GO

--ALTER TABLE Media.Media
--    ADD CONSTRAINT fk_media_mediatypeid FOREIGN KEY (MediaTypeId) REFERENCES Media.MediaType(MediaTypeId);
--GO