
 create procedure [dbo].[UPD_USER_PR]
 @P_ID int,
 @P_Name nvarchar(50),
 @P_Last_Name nvarchar(50),
 @P_Password nvarchar(20),
 @P_Email nvarchar(50),
 @P_BIRTH_DATE datetime,
 @P_Status nvarchar(2)
 AS 

 begin 
 Update tblUser
  set 
      Name = @P_Name,
      LastName = @P_Last_Name,
      Email = @P_Email,
      Password = @P_Password,
      BirthDate = @P_BIRTH_DATE,
      Status = @P_Status
  where ID = @P_ID

 End