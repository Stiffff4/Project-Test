CREATE PROCEDURE GetAllProducts
AS
BEGIN
	SELECT * FROM Products
END

GO

CREATE PROCEDURE CreateProduct
@ProductName NCHAR(20),
@ProductDescription NCHAR(50),
@ProductCost INT,
@CategoryId INT,
@CategoryName NCHAR(25)
AS
BEGIN
	INSERT INTO Products (ProductName, ProductDescription, ProductCost, CategoryId, CategoryName)
	VALUES (@ProductName, @ProductDescription, @ProductCost, @CategoryId, @CategoryName)
END

GO

CREATE PROCEDURE EditProduct
@ProductID INT,
@ProductName NCHAR(20),
@ProductDescription NCHAR(50),
@ProductCost INT
AS
BEGIN
	UPDATE Products
	SET 
	ProductName = @ProductName,
	ProductDescription = @ProductDescription,
	ProductCost = @ProductCost
	WHERE ProductID = @ProductID
END

GO

CREATE PROCEDURE DeleteProduct
@ProductID INT
AS
BEGIN
	DELETE FROM Products
	WHERE ProductID = @ProductID
END