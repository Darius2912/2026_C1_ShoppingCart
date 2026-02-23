 create procedure UPD_PRODUCT_PR
 @P_Id int,
 @P_Name nvarchar(50),
 @P_Description nvarchar(250),
 @P_Price numeric(18, 2),
 @P_Quantity int,
 @P_Category nvarchar(50)
 AS 

 begin 
 Update tblProduct
  set 
      Name = @P_Name,
      Description = @P_Description,
      Price = @P_Price,
      Quantity = @P_Quantity,
      Category = @P_Category
where Id = @P_Id

 End