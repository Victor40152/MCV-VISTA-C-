create table TblContacto(

Id int not null primary key,
Nombre varchar (50) null,
Telefono varchar (50) null,

)

insert into dbo.TblContacto(Id, Nombre, Telefono)
values (1,'Juana de Arco', '1234567')

select * from dbo.TblContacto

create proc SPContacto
@opc int,
@Id int = null,
@Nombre varchar (50) = null,
@Telefono varchar (50) = null
as

if @opc = 1
begin
select * from TblContacto
end
go



