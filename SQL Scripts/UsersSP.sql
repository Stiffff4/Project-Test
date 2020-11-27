CREATE PROCEDURE CreateUser
@UserName VARCHAR(20),
@UserFirstName VARCHAR(30),
@UserLastName VARCHAR(30),
@UserEmail VARCHAR(40),
@UserPassword VARCHAR(100)
AS
BEGIN
	INSERT INTO Users (UserName, UserFirstName, UserLastName, UserEmail, UserPassword)
	VALUES (@UserName, @UserFirstName, @UserLastName, @UserEmail, @UserPassword)
END

GO

CREATE PROCEDURE GetUsersFromUser
@UserName VARCHAR(30)
AS
BEGIN
	SELECT * FROM Users
	WHERE @UserName = UserName
END

GO

CREATE PROCEDURE EditUser
@UserId INT,
@UserName VARCHAR(20),
@UserFirstName VARCHAR(30),
@UserLastName VARCHAR(30),
@UserEmail VARCHAR(40),
@UserPassword VARCHAR(200)
AS
BEGIN
	UPDATE Users
	SET 
	UserName = @UserName,
	UserFirstName = @UserFirstName,
	UserLastName = @UserLastName,
	UserEmail = @UserEmail,
	UserPassword = @UserPassword
	WHERE UserId = @UserId
END
