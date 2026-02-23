create procedure CRE_PRODUCT_PR
@P_Name nvarchar(50),
@P_Description nvarchar(250),
@P_Price numeric(18, 2),
@P_Quantity int,
@P_Category nvarchar(50)
as
begin
	insert into tblProduct (Created, Name, Description, Price, Quantity, Category)
	values (GetDate(), @P_Name, @P_Description, @P_Price, @P_Quantity, @P_Category);
end