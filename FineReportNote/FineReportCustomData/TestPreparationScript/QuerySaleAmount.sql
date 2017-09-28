SELECT * FROM T_USER
SELECT * FROM T_Sale
SELECT * FROM T_PRODUCT
SELECT * FROM T_PRODUCTTYPE

-- Query
Select UserName, ProductTypeName, ProductName, Sum(Amount) as Amount from (SELECT U.UserName, PT.TypeName as ProductTypeName, P.ProductName, Amount FROM T_SALE S LEFT JOIN T_USER U ON S.USERID = U.USERID LEFT JOIN T_PRODUCT P ON S.USERID = P.ProductID LEFT JOIN T_PRODUCTTYPE PT ON PT.ProductTypeID = P.ProductTypeId) T Group by T.UserName, T.ProductTypeName, T.ProductName

SELECT U.UserName, PT.TypeName as ProductTypeName, P.ProductName, Amount FROM T_SALE S LEFT JOIN T_USER U ON S.USERID = U.USERID LEFT JOIN T_PRODUCT P ON S.USERID = P.ProductID LEFT JOIN T_PRODUCTTYPE PT ON PT.ProductTypeID = P.ProductTypeId

SELECT * FROM T_Product

SELECT * FROM T_Sale Where USERID = 1


SELECT U.UserName, PT.TypeName as ProductTypeName, P.ProductName,Amount FROM T_SALE S 
LEFT JOIN T_USER U ON S.USERID = U.USERID LEFT JOIN T_PRODUCT P ON S.USERID = P.ProductID 
LEFT JOIN T_PRODUCTTYPE PT ON PT.ProductTypeID = P.ProductTypeId Where S.UserId = 1

SELECT U.UserName, P.ProductName, Amount FROM T_SALE S 
LEFT JOIN T_USER U ON S.USERID = U.USERID LEFT JOIN T_PRODUCT P ON S.USERID = P.ProductID Where S.UserId = 1

SELECT * FROM T_Sale WHERE UserId = 1

SELECT TS.UserId, TU.UserName, TS.ProductID, TP.ProductName, TPT.TypeName FROM T_Sale TS LEFT JOIN T_USER TU ON TS.UserId = TU.UserId Left Join T_Product TP ON TS.ProductID = TP.ProductID Left Join T_ProductType TPT ON TP.ProductTypeId = TPT.ProductTypeID

SELECT TS.UserId, TU.UserName, TS.ProductID, TP.ProductName, TPT.TypeName FROM T_Sale TS LEFT JOIN T_USER TU ON TS.UserId = TU.UserId Left Join T_Product TP ON TS.ProductID = TP.ProductID Left Join T_ProductType TPT ON TP.ProductTypeId = TPT.ProductTypeID