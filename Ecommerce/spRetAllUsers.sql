create procedure RET_ALL_USER_PR
as
begin 
   select  ID, Created, Name, LastName, Password, Email, BirthDate, Status 
   from tblUser;

end
