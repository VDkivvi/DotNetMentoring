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

INSERT INTO Person (Id, FirstName, LastName)
	VALUES (1, 'John', 'Doe'), (2, 'Jane', 'Doe'), (3, 'Vasya', 'Chorny'), (4, 'Oleg', 'ProstoOleg');

INSERT INTO Address (Id, Street, City, State, ZipCode)
	VALUES (1, 'Prakhovyh', 'Kyiv', 'AA', '03022'), (2, 'Zhylyanska', 'Cherkasy', 'CA', '03023');

INSERT INTO Employee (Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
	VALUES (1, 1, 1, 'EAE', 'Layer', 'Fantastic Mr.Fox'), 
			(2, 1, 2, 'EAE', 'Janitor', 'Hey,come here'),
			(3, 2, 2, 'EAE2', 'Supply Manager', 'Can I have another pen'),
			(4, 1, 2, 'EAE', 'Courier', 'Nobody');

INSERT INTO Company (Id, Name, AddressId)
	VALUES  (1, 'EAE', 1), 
			(2, 'EAE2', 2);