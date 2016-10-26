/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

USE MonsterDB;
GO

INSERT INTO Monster.Gender(GenderName, Active) VALUES
    (N'Female', 1),
    (N'Male', 1),
    (N'Alien', 1);
GO

INSERT INTO Monster.MonsterType(TypeName, Active) VALUES
    (N'Vampire', 1),
    (N'Werewolf', 1),
    (N'Zombie', 1);
GO

INSERT INTO Monster.Title(TitleName, Active) VALUES
    (N'Sir', 1),
    (N'Lady', 1),
    (N'Count', 1);
GO