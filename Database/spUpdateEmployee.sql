Create or alter procedure spUpdateEmployee          
(          
   @EmployeeId int ,        
   @EmployeeName varchar(50),
@ProfileImage varchar(255),
@Department varchar(50),
@Gender varchar(30),
@Salary bigInt,
@StartDate date,
@Notes varchar(Max)
)          
as          
begin 

begin try

begin transaction
   Update Employee         
   set EmployeeName=@EmployeeName, Department=@Department, Gender=@Gender,Salary=@Salary,StartDate=@StartDate,Notes=@Notes
      where EmployeeId=@EmployeeId      
      commit transaction

  end try

    begin catch
    rollback transaction
    end catch
 End
   
          
     