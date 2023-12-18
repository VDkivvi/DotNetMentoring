/*
Create a trigger for Employee table on insert new Row that will create a new Company with an Address 
(The address should be copied from the employee’s address).
*/

CREATE TRIGGER [dbo].[trg_CreateCompany]
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Company] ([dbo].[Company].[Name], [dbo].[Company].[AddressId])
    SELECT
        i.CompanyId,
        i.AddressId
    FROM
        inserted i;

    UPDATE e
    SET e.CompanyId = c.Id
        FROM [dbo].[Employee] e
            INNER JOIN [dbo].[Company] c ON e.AddressId = c.AddressId
            WHERE e.Id IN (SELECT [inserted].[Id] FROM inserted);
END;
