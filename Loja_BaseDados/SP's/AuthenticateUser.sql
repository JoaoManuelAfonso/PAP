create procedure AuthenticateUser
@email varchar(250),
@password char(64)
as
begin
declare @count int
select @count = Count(email) from Clientes where email=@email and password=@password
if(@count=1)
begin
select 1 as ReturnCode
end
else
begin
select -1 as ReturnCode
end
end