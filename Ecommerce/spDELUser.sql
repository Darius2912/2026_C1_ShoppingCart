create procedure DEL_USER_PR
@P_ID int
AS
Begin
Delete from tblUser where ID = @P_ID;
End