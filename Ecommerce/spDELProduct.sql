create procedure DEL_PRODUCT_PR	
@P_Id int
AS
Begin
Delete from tblProduct where Id = @P_Id;
End