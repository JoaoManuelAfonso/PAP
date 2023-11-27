CREATE PROCEDURE [dbo].[InsertUser]
	
	@username varchar(64),
	@password char(64)
as
begin
	declare @count int
	select @count = Count(*) from users where username = @username

	if(@count<>0)
	begin
		select -1 as returncode
	end
	else
	begin
	insert into users (username,password) values(@username,@password)
	select 1 as returncode
end
end
go