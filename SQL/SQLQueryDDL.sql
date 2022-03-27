CREATE TABLE Developer (
DeveloperID int IDENTITY(100, 1),
FirstName varchar(20),
Lastname varchar(20),
ProjectID int,
Salary int,
CONSTRAINT PK_DevloperID PRIMARY KEY (DeveloperID),
CONSTRAINT FK_ProjectDeveloper FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID) ON DELETE CASCADE
);


CREATE TABLE Project (
ProjectID int PRIMARY KEY,
ProjectName varchar(20),
ClientName varchar(20),
Budget int
);

-- Add foreign key (after creating Project table because
-- it has to have a reference)
--ALTER TABLE Developer
--ADD FOREIGN KEY(ProjectID)
--REFERENCES Project(ProjectID)
--ON DELETE SET NULL;

--ALTER TABLE Developer
--ADD Salary int;

CREATE INDEX Index1 ON Developer (LastName DESC);

DROP INDEX Index1 ON Project;

DROP TABLE Developer;

DROP TABLE Project;