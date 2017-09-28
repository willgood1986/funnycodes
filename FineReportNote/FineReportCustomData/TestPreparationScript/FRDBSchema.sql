
DECLARE @dbName nvarchar(128)
SET @dbName=N'FRRainy'

IF (DB_ID(@dbName) is NULL)
BEGIN
  DECLARE @executeScript nvarchar(255)
  SET @executeScript = 'CREATE DATABASE ' +  @dbName
  PRINT @executeScript
  EXECUTE SP_EXECUTESQL @executeScript 
END

GO

use FRRainy;

DECLARE @t_user NVARCHAR(128)
SET @t_user = N'DBO.T_USER'

IF OBJECT_ID(@t_user, N'U') IS NULL
BEGIN
    Create Table dbo.T_User(
        UserId Int NOT NULL IDENTITY(1, 1) Primary Key,
		Gender Char(1) Not null,
        UserName NVARCHAR(255) Not null,
        Birth Date null
     )
END
GO

DECLARE @t_productType NVARCHAR(128)
SET @t_productType = N'DBO.T_ProductType'

IF OBJECT_ID(@t_productType, N'U') IS NULL
BEGIN
    CREATE Table DBO.T_ProductType (
	ProductTypeID INT NOT NULL IDENTITY(1,1) Primary Key,
	TypeName NVARCHAR(128) NOT NULL	
	)
END
GO

DECLARE @t_product NVARCHAR(128)
SET @t_product = N'DBO.T_Product'

IF OBJECT_ID(@t_product, N'U') IS NULL
BEGIN
    CREATE TABLE DBO.T_Product(
	ProductID INT NOT NULL IDENTITY(1, 1) Primary Key,
	ProductTypeId INT NOT NULL,
	ProductName NVARCHAR(128) NOT NULL,
	CONSTRAINT FK_ProductType_ProductTypeId Foreign Key(ProductTypeId) REFERENCES DBO.T_ProductType(ProductTypeId)
	)   
END
GO

DECLARE @t_sale NVARCHAR(128)
SET @t_sale = N'DBO.T_Sale'

IF OBJECT_ID(@t_sale, N'U') IS NULL
BEGIN
    CREATE TABLE DBO.T_Sale(
	ProductID INT NOT NULL,
	UserId INT NOT NULL,
	Amount FLOAT NOT NULL,
	CONSTRAINT FK_Product_ProductId Foreign Key(ProductID) REFERENCES DBO.T_Product(ProductID)
	)
END
GO