create procedure RET_USER_BY_ID_PR
@P_ID int
as
begin 
   select  ID, Created, Name, LastName, Password, Email, BirthDate, Status 
   from tblUser
   where Id = @P_ID;
end;
