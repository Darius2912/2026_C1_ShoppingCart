create procedure RET_PRODUCT_BY_ID_PR
@P_Id int
as
begin 
   select  Id, Created, Name, Description, Price, Quantity, Category
   from tblProduct
   where Id = @P_Id;
end;
