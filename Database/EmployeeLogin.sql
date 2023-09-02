
create or alter procedure spEmployeeLogin
@empLoginId int,
@empLoginName varchar(30)
as
begin
  begin try      
	select * from Employee where EmployeeId=@empLoginId and EmployeeName=@empLoginName;
  end try
  begin catch
  select
  'An error occurred: '+ ERROR_MESSAGE() AS ErrorMessage;
  end catch
end