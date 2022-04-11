CREATE TABLE Developer (
Id int IDENTITY(100, 1) PRIMARY KEY,
FirstName varchar(20),
Lastname varchar(20),
ProjectId int FOREIGN KEY REFERENCES Project(Id),
Salary int,
);


CREATE TABLE Project (
Id int IDENTITY (1, 1) PRIMARY KEY,
Name varchar(20),
ClientName varchar(20),
Budget int
);




SELECT * FROM Developer;

SELECT * FROM Project




CREATE INDEX Index1 ON Developer (LastName DESC);

DROP INDEX Index1 ON Project;

DROP TABLE Developer;

DROP TABLE Project;