Create Procedure [dbo].[UpdateClientByID]
	@Id_Cliente int,
	@Primeiro_Nome varchar(256),
	@Ultimo_Nome varchar(256),
	@Telemovel int,
	@Morada varchar(256),
	@Email varchar(256),
	@Codigo_Postal int,
	@Password char(64)
	
	as
	begin
	declare @count int
	select @count = Count(*) from Clientes where Id_Cliente = @Id_Cliente
	if(@count = 1)
	begin
		select -1 as ReturnCode
	end
	else
	begin
		update Clientes set Primeiro_Nome=@Primeiro_Nome, Ultimo_Nome=@Ultimo_Nome,Telemovel=@Telemovel,Morada=@Morada,Codigo_Postal=@Codigo_Postal,Password=@Password 
		select 1 as ReturnCode
	end
	end