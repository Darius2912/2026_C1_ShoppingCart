 Create procedure CRE_USER_PR
 @P_Name nvarchar(50),
 @P_Last_Name nvarchar(50),
 @P_Password nvarchar(20),
 @P_Email nvarchar(50),
 @P_BIRTH_DATE datetime,
 @P_Status nvarchar(2)
 AS 

 begin 

 Insert into tblUser (Created, Name, LastName, Password, Email, BirthDate, Status)
values(GetDate(), @P_Name, @P_Last_Name, @P_Password, @P_Email, @P_BIRTH_DATE, @P_Status);

 End