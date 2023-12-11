/*
Create a stored procedure to insert Employee info into DB with the following params:

EmployeeName(optional)
FirstName(optional)
LastName(optional)
CompanyName(required)
Position(optional)
Street(required)
City(optional)
State(optional)
ZipCode(optional)

And the following conditions:

1. At least one field (either EmployeeName  or FirstName or LastName) should not be:
    - NULL
    - empty string
    - contains only ‘space’ symbols
2. CompanyName should be truncated if length is more than 20 symbols
*/

CREATE PROCEDURE sp_InsertEmployeeInfo
    @EmployeeName NVARCHAR(50) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @CompanyName NVARCHAR(50),
    @Position NVARCHAR(50) = NULL,
    @Street NVARCHAR(50),
    @City NVARCHAR(50) = NULL,
    @State NVARCHAR(50) = NULL,
    @ZipCode NVARCHAR(10) = NULL
AS
BEGIN
    DECLARE @AddressId INT;
    DECLARE @PersonId INT;
    DECLARE @CompanyId INT;

    IF COALESCE(NULLIF(TRIM(@EmployeeName), ''), NULLIF(TRIM(@FirstName), ''), NULLIF(TRIM(@LastName), '')) IS NULL
    BEGIN
        PRINT('At least one of the name fields should not be NULL, empty, or contain only spaces.')
        RETURN;
    END
    SET @CompanyName = LEFT(@CompanyName, 20)

    IF EXISTS (SELECT Id FROM Address WHERE (Street = @Street AND City = @City AND State = @State))
        BEGIN
            SELECT @AddressId AS Id;
        END
    ELSE
        BEGIN
            INSERT INTO Address (Street, City, State, ZipCode) VALUES (@Street, @City, @State, @ZipCode);
            SET @AddressId = SCOPE_IDENTITY();
            SELECT @AddressId AS Id;
        END

    IF EXISTS (SELECT Id FROM Company WHERE (Name = @CompanyName))
        BEGIN
            SET @CompanyId = Id;
        END
    ELSE
        BEGIN
            INSERT INTO Company (Name) VALUES (@CompanyName);
            SET @CompanyId = SCOPE_IDENTITY();
            SELECT @CompanyId AS Id;
        END


    IF EXISTS (SELECT Id FROM Person WHERE (FirstName = @FirstName AND LastName = @LastName))
        BEGIN
            SET @PersonId = Id;
        END
    ELSE
        BEGIN
            INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName);
            SET @PersonId = SCOPE_IDENTITY();
            SELECT @PersonId AS Id;
        END

    INSERT INTO Employee 
    (EmployeeName, AddressId, PersonId, CompanyId, Position, EmployeeName)
        VALUES (@EmployeeName, @AddressId, @PersonId, @CompanyId, @Position, @EmployeeName)
    PRINT 'Employee information inserted successfully.'
END