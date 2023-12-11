/*
Create ‘EmployeeInfo’ view to show data with the following structure that is sorted by ‘CompanyName, City’ ASC:

EmployeeId,
EmployeeFullName (EmployeeName (if not null) or ‘{FirstName} {LastName}’),
EmployeeFullAddress(‘{ZipCode}_{State}, {City}-{Street}’)
EmployeeCompanyInfo(‘{CompanyName}({Position})’)
*/

CREATE VIEW view_EmployeeInfo AS
SELECT 
    E.Id AS EmployeeId,
    COALESCE(E.EmployeeName, P.FirstName + ' ' + P.LastName) AS EmployeeFullName,
    CONCAT(A.ZipCode, '_', A.State, ', ', A.City, '-', A.Street) AS EmployeeFullAddress,
    CONCAT(C.Name, '(', E.Position, ')') AS EmployeeCompanyInfo
FROM 
    Employee E
LEFT JOIN 
    Company C ON E.CompanyId = C.Id
LEFT JOIN 
    Person P ON E.PersonId = P.Id
LEFT JOIN 
    Address A ON E.AddressId = A.Id
ORDER BY 
    C.Name ASC, A.City ASC
OFFSET 0 ROWS
FETCH NEXT 1000000 ROWS ONLY;