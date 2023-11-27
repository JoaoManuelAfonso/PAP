CREATE PROCEDURE [dbo].[AuthenticateUser]
	@username varchar(64),
	@password char(64)
	as
	begin
	declare @count int
	select @count =COUNT(username) From users where username=@username and password=@password
	if(@count=1)
	begin
	select 1 as returnCode
	end
	else
	begin
	select -1 as returnCode
	end
	end
