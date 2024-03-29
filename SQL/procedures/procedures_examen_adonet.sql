CREATE OR ALTER PROCEDURE SP_CLIENTES
AS
	SELECT Empresa FROM clientes;
GO

CREATE OR ALTER PROCEDURE SP_PEDIDOS_CLIENTE
(@CLIENTE NVARCHAR(50))
AS
	DECLARE @CODIGO_CLIENTE NVARCHAR(50);
	SELECT @CODIGO_CLIENTE = clientes.CodigoCliente FROM clientes WHERE clientes.Empresa = @CLIENTE;
	SELECT CodigoPedido FROM PEDIDOS WHERE CodigoCliente = @CODIGO_CLIENTE;
GO

CREATE OR ALTER PROCEDURE SP_FIND_CLIENTE
(@CLIENTE NVARCHAR(50))
AS
	DECLARE @CODIGO_CLIENTE NVARCHAR(50);
	SELECT @CODIGO_CLIENTE = clientes.CodigoCliente FROM clientes WHERE clientes.Empresa = @CLIENTE;
	SELECT * FROM clientes WHERE CodigoCliente = @CODIGO_CLIENTE;
GO

CREATE OR ALTER PROCEDURE SP_UPDATE_CLIENTE
(
@CLIENTE NVARCHAR(50), @CARGO NVARCHAR(50), @CIUDAD NVARCHAR(50), @CONTACTO NVARCHAR(50), @EMPRESA NVARCHAR(50), @TELEFONO INT
)
AS
	DECLARE @CODIGO_CLIENTE NVARCHAR(50);
	SELECT @CODIGO_CLIENTE = clientes.CodigoCliente FROM clientes WHERE clientes.Empresa = @CLIENTE;
	UPDATE clientes SET Cargo = @CARGO, Ciudad = @CIUDAD, Contacto = @CONTACTO, Empresa = @EMPRESA, Telefono = @TELEFONO
	WHERE CodigoCliente = @CODIGO_CLIENTE;
GO

CREATE OR ALTER PROCEDURE SP_DELETE_PEDIDO_CLIENTE
(@CODIGO_PEDIDO NVARCHAR(50))
AS
	DELETE FROM pedidos WHERE CodigoPedido = @CODIGO_PEDIDO;
GO

CREATE OR ALTER PROCEDURE SP_UPDATE_PEDIDO
(
@CODIGO_PEDIDO NVARCHAR(50), @FECHA_ENTREGA NVARCHAR(50), @FORMA_ENVIO NVARCHAR(50), @IMPORTE INT
)
AS
	UPDATE pedidos SET FechaEntrega = @FECHA_ENTREGA, FormaEnvio = @FORMA_ENVIO, Importe = @IMPORTE
	WHERE CodigoPedido = @CODIGO_PEDIDO;
GO

CREATE OR ALTER PROCEDURE SP_FIND_PEDIDO
(@CODIGO_PEDIDO NVARCHAR(50))
AS
	SELECT * FROM pedidos WHERE CodigoPedido = @CODIGO_PEDIDO;
GO

CREATE OR ALTER PROCEDURE SP_CREATE_PEDIDO
(
@CODIGO_PEDIDO NVARCHAR(50), @CLIENTE NVARCHAR(50), @FECHA_ENTREGA NVARCHAR(50), @FORMA_ENVIO NVARCHAR(50), @IMPORTE INT
)
AS
	DECLARE @CODIGO_CLIENTE NVARCHAR(50);
	SELECT @CODIGO_CLIENTE = clientes.CodigoCliente FROM clientes WHERE clientes.Empresa = @CLIENTE;
	INSERT INTO pedidos VALUES (@CODIGO_PEDIDO,@CODIGO_CLIENTE, @FECHA_ENTREGA,@FORMA_ENVIO, @IMPORTE);
GO