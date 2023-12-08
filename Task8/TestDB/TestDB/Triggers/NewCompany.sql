/*
Create a trigger for Employee table on insert new Row that will create a new Company with an Address 
(The address should be copied from the employee’s address).
*/

CREATE TRIGGER trg_CreateCompany
ON Employee
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Company (Name, AddressId)
    SELECT
        i.CompanyId,
        i.AddressId
    FROM
        inserted i;

    UPDATE e
    SET e.CompanyId = c.Id
    FROM Employee e
    INNER JOIN Company c ON e.AddressId = c.AddressId
    WHERE e.Id IN (SELECT Id FROM inserted);
END;
