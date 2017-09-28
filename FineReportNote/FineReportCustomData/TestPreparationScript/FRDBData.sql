USE FRRainy;
GO

INSERT INTO DBO.T_USER(GENDER, UserName, Birth) VALUES ('M', 'Rainy1', '1986-11-20'), ('M', 'Rainy2', '1986-11-21'), ('M', 'Rainy3', '1986-11-22'), ('M', 'Rainy4', '1986-11-23')
GO

INSERT INTO DBO.T_ProductType(TypeName) Values ('Cake'), ('Fruit')
GO

Insert Into DBO.T_Product(ProductTypeId, ProductName) Values (1, 'Sanwiches'), (1, 'Bread'), (1, 'Moon Cake'), (2, 'Apple'), (2, 'Orange'), (2, 'Banana')
GO

INSERT INTO DBO.T_Sale(ProductId, UserId, Amount) Values (1,1,200), (1,2,250),(1,3,300),(1,4,400),(2,1,50),(2,2,150),(2,3,600),(2,4,200),(3,1,150),(3,2,200),(3,3,160),(3,4,70),(4,1,60),(4,2,80),(4,3,25),(4,4,180), (5,1, 88), (5,2,260), (5,3,10), (5,4,5), (6,1,110), (6,2, 150), (6,3,77), (6,4,400)
GO