INSERT INTO Developer (FirstName, LastName, ProjectID, Salary) VALUES
('John', 'Doe', 1, 7500),
('Oliver', 'Wilson', 1, 6000),
('Alma', 'Gomez', 2, 10000),
('Paula', 'Terry', 2, 12000),
('Jon', 'Joseph', 3, 5500);

INSERT INTO Project (Name, ClientName, Budget) VALUES
('BookInventory', 'GISKO', 55000),
('WebApp', 'GISKO', 32500),
('FitnessApp', 'PolleoSport', 88200);



SELECT * FROM Developer;
SELECT * FROM Project;

--filtering, select all devs (their names) working on a project
SELECT FirstName, LastName
FROM Developer
WHERE ProjectID=1;

--sorting
SELECT * FROM Developer
ORDER BY LastName DESC;

--paging
SELECT * FROM Developer
ORDER BY LastName DESC
OFFSET 0 ROWS
FETCH NEXT 2 ROWS ONLY;


DELETE FROM Project
WHERE ProjectID=2;



--UPDATE Developer
--SET Salary=7000
--WHERE ProjectID=1;

--UPDATE Developer
--SET Salary=5500
--WHERE ProjectID=2;

--UPDATE Developer
--SET Salary=6000
--WHERE Salary<=5500;


-- inner join, joins devs (their names) with respective project and client names
SELECT Developer.Firstname, Developer.Lastname, Project.ProjectName, Project.ClientName
FROM Developer
INNER JOIN Project ON Developer.ProjectID=Project.ProjectID;

--left join
SELECT Developer.FirstName, Developer.LastName, Project.ProjectName
FROM Developer
LEFT JOIN Project
ON Developer.ProjectID=Project.ProjectID;

--right join
SELECT Developer.FirstName, Developer.LastName, Project.ProjectName
FROM Developer
RIGHT JOIN Project
ON Developer.ProjectID=Project.ProjectID;


SELECT * FROM Developer
WHERE LastName = 'Joseph';

