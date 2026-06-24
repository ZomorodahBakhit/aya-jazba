USE University;
GO

CREATE TABLE Users(
UserId int primary key,
UserName varchar(64) not null,
FirstName varchar(64) not null,
LastName varchar(64) not null,
EmailAddress varchar(128) not null,
PhoneNumber varchar(16) not null,
Role varchar(32) not null);

CREATE TABLE Courses(
CourseId int primary key,
CourseName Varchar(100) not null,
TeacherId int null,
SatrtDate datetime not null,
EndDate datetime not null,
SyllabusId int null);

CREATE TABLE Assignments(
AssignmentId int primary key,
CourseId int not null,
AssignmentTitle varchar(128) not null,
Description text not null,
Weight float not null,
MaxGrade int not null,
DueDate date not null);


CREATE TABLE Comments(
CommentId int primary key,
AssignmentId int not null,
CreatedByUserId int not null,
CreatedDate datetime not null,
CommentContent text null);

CREATE TABLE Grades(
GradeId int primary key,
AssignmentId int not null,
StudentId int not null,
Grade int null);

CREATE TABLE Syllabus(
SyllabusId int primary key,
Description text null);


ALTER TABLE [Users] 
ADD constraint UQ_Users_EmailAddress
unique (EmailAddress);


ALTER TABLE dbo.Courses
ADD CONSTRAINT FK_Courses_Users_Teacher
FOREIGN KEY (TeacherId)
REFERENCES dbo.[Users](UserId);



ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Syllabus
FOREIGN KEY (SyllabusId)
REFERENCES Syllabus(SyllabusId);

ALTER TABLE Assignments
ADD CONSTRAINT FK_Assignments_Courses
FOREIGN KEY (CourseId)
REFERENCES Courses(CourseId);


ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Assignments
FOREIGN KEY (AssignmentId)
REFERENCES Assignments(AssignmentId);



ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Users
FOREIGN KEY (CreatedByUserId)
REFERENCES [Users](UserId);


ALTER TABLE Grades
ADD CONSTRAINT FK_Grades_Assignments
FOREIGN KEY (AssignmentId)
REFERENCES Assignments(AssignmentId);


ALTER TABLE Grades
ADD CONSTRAINT FK_Grades_Users_Student
FOREIGN KEY (StudentId)
REFERENCES [Users](UserId);





insert into Users
values 
(1,'aya.jazba','Aya','Jazba','student1@gmail.com', '0000000001','Student'),
(2,'fawzy.sukkar','Fawzy','Sukkar','student2@university.com','0000000002','Student'),
(3,'hiba.jazba','Hiba','Jazba','student3@university.com','0000000003','Student'),
(4,'marah.aljumaat','Marah','Aljumaat','student4@university.com','0000000004','Student'),
(5,'masa.hammoud','Masa','Hammoud','student5@university.com','0000000005','Student'),
(6,'mehyar.khuder','Mehyar','Khuder','student6@university.com','0000000006','Student'),
(7,'moaz.zakaria','Moaz','Zakaria','student7@university.com','0000000007','Student'),
(8,'motaz.almasri','Motaz','Al Masri','student8@university.com','0000000008','Student'),
(9,'nawar.altibi','Nawar','Al Tibi','student9@university.com','0000000009','Student'),
(10,'ayman.durra','Ayman','Durra','student10@university.com','0000000010','Student');

insert into Users
values
(11,'Sami.Hijazi', 'Sami', 'Hijazi','Teacher1@university.com','0000000011','Teacher'),
(12,'Feryal','Feryal','F.','Teacher2@university.com','0000000012','Teacher');

insert into Courses
values
(1,'SQL',11,'20260623','20260923',NULL),
(2,'C#',11,'20260825','20261015',NULL),
(3,'Entity Framework',12,'20260630','20260730',NULL),
(4,'Web API',12,'20260707','20260930',NULL),
(5,'React',11,'20260629','20260828',NULL);

INSERT INTO Assignments
VALUES

(1, 1, 'SQL Tables', 'Create tables.', 15, 100, '20260410'),
(2, 1, 'SQL Insert ', 'Insert into tables.', 20, 100, '20260505'),
(3, 1, 'SQL Select', ' select queries ', 20, 100, '20260615'),
(4, 1, 'SQL Join', 'join queries', 20, 100, '20260715'),
(5, 1, 'SQL Stored Procedure', 'Create a stored procedure.', 25, 100, '20260820'),


(6, 2, 'C# Variables', 'variables and data types', 15, 100, '20260412'),
(7, 2, 'C# Conditions', 'if else and switch ', 20, 100, '20260510'),
(8, 2, 'C# Loops', 'for, while and foreach loops.', 20, 100, '20260618'),
(9, 2, 'C# Methods', 'Create and use methods.', 20, 100, '20260720'),
(10, 2, 'C# OOP', 'Create classes and objects.', 25, 100, '20260825'),

(11, 3, 'EF Core Setup', 'Create an Entity Framework Core project.', 15, 100, '20260415'),
(12, 3, 'EF Models', 'Create entity models.', 20, 100, '20260515'),
(13, 3, 'EF DbContext', 'Create DbContext class.', 20, 100, '20260620'),
(14, 3, 'EF Migration', 'Create and apply migrations.', 20, 100, '20260725'),
(15, 3, 'EF CRUD', 'Perform CRUD operations.', 25, 100, '20260830'),


(16, 4, 'Web API Setup', 'Create a Web API project.', 15, 100, '20260418'),
(17, 4, 'Web API GET', 'Create GET endpoints.', 20, 100, '20260520'),
(18, 4, 'Web API POST', 'Create POST endpoints.', 20, 100, '20260622'),
(19, 4, 'Web API PUT DELETE', 'Create PUT and DELETE endpoints.', 20, 100, '20260730'),
(20, 4, 'Web API Swagger', 'Test endpoints using Swagger.', 25, 100, '20260905'),


(21, 5, 'React Setup', 'Create a React project.', 15, 100, '20260420'),
(22, 5, 'React Components', 'Create components.', 20, 100, '20260525'),
(23, 5, 'React Props and State', ' props , state', 20, 100, '20260621'),
(24, 5, 'React Hooks', 'useState, useEffect', 20, 100, '20260805'),
(25, 5, 'React Final Project', 'Build a simple React application.', 25, 100, '20260910');

INSERT INTO Comments
VALUES
    (1, 2,  1, '20260412', 'The SQL insert exercise was clear.'),
    (2, 5,  3, '20260420', 'I need more practice with stored procedures.'),
    (3, 7,  2, '20260512', 'The C# conditions assignment was useful.'),
    (4, 10, 4, '20260518', 'Object oriented programming was challenging.'),
    (5, 13, 5, '20260605', 'DbContext structure is now clearer.'),
    (6, 16, 6, '20260610', 'Web API project setup was completed.'),
    (7, 19, 7, '20260615', 'PUT and DELETE endpoints need more testing.'),
    (8, 21, 8, '20260620', 'React installation was successful.'),
    (9, 23, 9, '20260621', 'Props and state topic was interesting.'),
    (10, 25, 1, '20260701', 'The final React project requirements are clear.');

   INSERT INTO Grades
SELECT
    ROW_NUMBER() OVER (ORDER BY a.AssignmentId, u.UserId),
    a.AssignmentId,
    u.UserId,
    ABS(CHECKSUM(NEWID())) % 101
FROM dbo.Assignments AS a
CROSS JOIN dbo.[Users] AS u
WHERE u.[Role] = 'Student';

INSERT INTO Syllabus 
VALUES
(1,'SQL: Tables, INSERT, SELECT, JOIN, Stored Procedures and Functions.'),
(2,'C#: Variables, Conditions, Loops, Methods and Object Oriented Programming.'),
(3,'Entity Framework: EF Core, Models, DbContext, Migrations and CRUD.'),
(4,'Web API: GET, POST, PUT, DELETE endpoints and Swagger.'),
(5,'React: Components, Props, State, Hooks and Final Project.');

UPDATE dbo.Courses
SET SyllabusId = 1
WHERE CourseId = 1;  

UPDATE dbo.Courses
SET SyllabusId = 2
WHERE CourseId = 2;  

UPDATE dbo.Courses
SET SyllabusId = 3
WHERE CourseId = 3;   

UPDATE dbo.Courses
SET SyllabusId = 4
WHERE CourseId = 4;  

UPDATE dbo.Courses
SET SyllabusId = 5
WHERE CourseId = 5;  


SELECT * FROM Courses;

SELECT * FROM Assignments
WHERE CourseId=1;

SELECT * FROM Users
WHERE Role='Student';

UPDATE Users
SET Role ='Teacher'
WHERE UserId = 1;

DELETE FROM Comments
WHERE CommentId=5;


SELECT u.FirstName,u.LastName,c.CourseName,g.Grade
FROM [Users] AS u
INNER JOIN Grades AS g
    ON u.UserId = g.StudentId
INNER JOIN dbo.Assignments AS a
    ON g.AssignmentId = a.AssignmentId
INNER JOIN dbo.Courses AS c
    ON a.CourseId = c.CourseId
WHERE u.[Role] = 'Student'
  AND c.CourseName = 'SQL';






  SELECT c.CourseName,s.SyllabusId,s.Description
  FROM Syllabus as s 
  INNER JOIN Courses as c
  ON s.SyllabusId=c.SyllabusId;

  

SELECT c.CourseName,cm.CommentContent
FROM dbo.Comments AS cm
INNER JOIN Assignments AS a
    ON cm.AssignmentId = a.AssignmentId
INNER JOIN Courses AS c
    ON a.CourseId = c.CourseId
WHERE c.CourseName = 'React'


SELECT c.CourseName,AVG(g.Grade) AS AverageGrade
FROM Courses AS c
INNER JOIN Assignments AS a
    ON c.CourseId = a.CourseId
INNER JOIN Grades AS g
    ON a.AssignmentId = g.AssignmentId
GROUP BY c.CourseName
ORDER BY c.CourseName;
GO

CREATE PROCEDURE AddNewStudent
    @UserId INT,
    @UserName VARCHAR(64),
    @FirstName VARCHAR(64),
    @LastName VARCHAR(64),
    @EmailAddress VARCHAR(128),
    @PhoneNumber VARCHAR(16)
AS
BEGIN
    INSERT INTO [Users]
        (UserId, UserName, FirstName, LastName, EmailAddress, PhoneNumber, [Role])
    VALUES
        (@UserId, @UserName, @FirstName, @LastName, @EmailAddress, @PhoneNumber, 'Student');
END;
GO



CREATE OR ALTER PROCEDURE AddNewAssignment
    @AssignmentId INT,
    @CourseId INT,
    @AssignmentTitle VARCHAR(128),
    @Description VARCHAR(MAX),
    @Weight FLOAT,
    @MaxGrade INT,
    @DueDate DATE
AS
BEGIN
    DECLARE @CurrentTotalWeight FLOAT;

    SELECT @CurrentTotalWeight = ISNULL(SUM(Weight), 0)
    FROM dbo.Assignments
    WHERE CourseId = @CourseId;

    IF @CurrentTotalWeight + @Weight > 100
    BEGIN;
        THROW 50001, 'The total assignment weight for this course cannot exceed 100.', 1;
    END;

    INSERT INTO dbo.Assignments
        (AssignmentId, CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate)
    VALUES
        (@AssignmentId, @CourseId, @AssignmentTitle, @Description, @Weight, @MaxGrade, @DueDate);
END;
GO





CREATE OR ALTER FUNCTION StudentLetterGrade
(
    @StudentId INT,
    @CourseId INT
)
RETURNS CHAR(1)
AS
BEGIN
    DECLARE @AverageGrade DECIMAL(5,2);

    SELECT
        @AverageGrade =
            SUM(g.Grade * a.Weight) / SUM(a.Weight)
    FROM dbo.Grades AS g
    INNER JOIN dbo.Assignments AS a
        ON g.AssignmentId = a.AssignmentId
    where g.StudentId = @StudentId
      and a.CourseId = @CourseId;

    RETURN
        CASE
            when @AverageGrade >= 90 then 'A'
            when @AverageGrade >= 80 then 'B'
            when @AverageGrade >= 70 then 'C'
            when @AverageGrade >= 60 then 'D'
            ELSE 'F'
        END;
END;
GO



CREATE OR ALTER FUNCTION CalculateGPA
(
    @StudentId INT
)
RETURNS DECIMAL(4,2)
AS
BEGIN
    DECLARE @GPA DECIMAL(4,2);

    SELECT @GPA = AVG(CourseGrade / 25.0)
    FROM
    (
        SELECT
            a.CourseId,

            SUM(
                (
                    CAST(g.Grade AS DECIMAL(10,2))
                    / NULLIF(a.MaxGrade, 0)
                ) * 100 * CAST(a.Weight AS DECIMAL(10,2))
            )
            / NULLIF(SUM(CAST(a.Weight AS DECIMAL(10,2))), 0) AS CourseGrade

        FROM dbo.Grades AS g
        INNER JOIN dbo.Assignments AS a
            ON g.AssignmentId = a.AssignmentId

        WHERE g.StudentId = @StudentId
          AND g.Grade IS NOT NULL

        GROUP BY a.CourseId
    ) AS CourseGrades;

    RETURN ISNULL(@GPA, 0);
END;
GO