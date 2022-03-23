-- Create two tables
CREATE TABLE Developer (
	DeveloperID int IDENTITY(100, 1) PRIMARY KEY,
	FirstName varchar(20),
	LastName varchar(20),
	WorkingOnProjectID int
);

CREATE TABLE Project (
	ProjectID int IDENTITY(1, 1) PRIMARY KEY,
	ProjectName varchar(20),
	ClientName varchar(20),
	StartDate date
);


ALTER TABLE Developer
ADD FOREIGN KEY(WorkingOnProjectID)
REFERENCES Project(ProjectID)
ON DELETE SET NULL;



--Insert values
INSERT INTO Developer (FirstName, LastName, WorkingOnProjectID) VALUES
('John', 'Doe', '1'),
('Oliver', 'Wilson', '1'),
('Alma', 'Gomez', '2'),
('Paula', 'Terry', '2'),
('Jon', 'Joseph', '2');

INSERT INTO Project(ProjectName, ClientName, StartDate) VALUES
('BookInventory', 'GISKO', '2022-03-23'),
('WebApp', 'GISKO', '2022-01-06'),
('FitnessApp', 'PolleoSport', '2022-06-21');





--Select
SELECT * FROM Developer;
DROP TABLE Developer;

SELECT * FROM Project;
DROP TABLE Project;

--Select names of devs working on some project
SELECT FirstName, LastName
FROM Developer
WHERE WorkingOnProjectID=1;



DELETE FROM Project
WHERE ProjectID=2;


--Add new column (Salary)
ALTER TABLE Developer
ADD Salary int;

--Update
UPDATE Developer
SET Salary=7000
WHERE WorkingOnProjectID=1;

UPDATE Developer
SET Salary=5500
WHERE WorkingOnProjectID=2;

UPDATE Developer
SET Salary=6000
WHERE Salary<=5500;