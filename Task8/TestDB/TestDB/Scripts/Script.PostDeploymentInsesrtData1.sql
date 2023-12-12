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

INSERT INTO Address (Street, City, State, ZipCode)
	VALUES 
		('Prakhovyh', 'Kyiv', 'AA', '02022'), 
		('Zhylyanska', 'Cherkasy', 'CA', '03023'),
		('Fizkultury', 'Vinnytsya', 'KB', '04024');


INSERT INTO Person (FirstName, LastName)
	VALUES 
		('John', 'Doe'), 
		('Jane', 'Doe'), 
		('Vasya', 'Chorny'), 
		('Oleg', 'ProstoOleg');


INSERT INTO Company (Name, AddressId)
	VALUES  
		('EAE', 1), 
		('EAE2', 2);

INSERT INTO Employee (AddressId, PersonId, CompanyId, Position, EmployeeName)
	VALUES 
		(1, 1, 1, 'Lawyer', 'Fantastic Mr.Fox'), 
		(2, 2, 1, 'Janitor', 'Hey,come here'),
		(3, 3, 2, 'Supply Manager', 'Can I have another pen1'),
		(3, 4, 2, 'Supply Manager', 'Can I have another pen2');





