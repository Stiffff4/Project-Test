CREATE PROCEDURE GetAllCategories
AS
BEGIN
	SELECT * FROM Categories ORDER BY CategoryName
END

GO

CREATE PROCEDURE CreateCategory
@CategoryName VARCHAR(50)
AS
BEGIN
	INSERT INTO Categories (CategoryName)
	VALUES (@CategoryName)
END

GO

CREATE PROCEDURE EditCategory
@CategoryID INT,
@CategoryName VARCHAR(50)
AS
BEGIN
	UPDATE Categories
	SET 
	CategoryName = @CategoryName
	WHERE CategoryID = @CategoryID
END

GO

CREATE PROCEDURE DeleteCategory
@CategoryID INT
AS
BEGIN
	DELETE FROM Categories
	WHERE CategoryID = @CategoryID
END

