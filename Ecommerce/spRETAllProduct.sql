USE [2026C1-ecommerce]
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_PRODUCT_PR]    Script Date: 23/2/2026 11:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RET_ALL_PRODUCT_PR]
as
begin 
   select  Id, Created, Name, Description, Price, Quantity, Category
   from tblProduct;

end

