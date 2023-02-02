using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FelixMartinezBendicho.Repository;

#region PROCEDURES
/*
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
 */
#endregion

namespace FelixMartinezBendicho
{
    public partial class FormPractica : Form
    {
        private readonly RepositoryClientes repo;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new();
            this.LoadClientes();
        }

        private void LoadClientes()
        {
            this.cmbclientes.Items.Clear();
            foreach (var cliente in this.repo.GetClientes())
            {
                this.cmbclientes.Items.Add(cliente);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbclientes.SelectedIndex != -1)
            {
                this.lstpedidos.Items.Clear();
                var pedidos = this.repo.GetPedidosCliente(this.cmbclientes.SelectedItem.ToString()!);
                foreach (var pedido in pedidos)
                {
                    this.lstpedidos.Items.Add(pedido);
                }
                var cliente = this.repo.FindCliente(this.cmbclientes.SelectedItem.ToString()!);
                this.txtempresa.Text = cliente.Empresa;
                this.txtcargo.Text = cliente.Cargo;
                this.txtciudad.Text = cliente.Ciudad;
                this.txtcontacto.Text = cliente.Contacto;
                this.txttelefono.Text = cliente.Telefono.ToString();
            }
        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstpedidos.SelectedIndex != 1)
            {
                var pedido = this.repo.FindPedido(this.lstpedidos.SelectedItems[0].ToString()!);
                this.txtimporte.Text = pedido.Import.ToString();
                this.txtformaenvio.Text = pedido.FormaEnvio.ToString();
                this.txtfechaentrega.Text = pedido.FechaEntrega.ToString();
                this.txtcodigopedido.Text = pedido.CodigoPedido.ToString();
            }
        }

        private void btnmodificarcliente_Click(object sender, EventArgs e)
        {
            if (this.cmbclientes.SelectedIndex != -1)
            {
                var affectedRows = this.repo.ModificarCliente(
                    cliente: this.cmbclientes.SelectedItem.ToString()!,
                    cargo: this.txtcargo.Text,
                    ciudad: this.txtciudad.Text,
                    contacto: this.txtcontacto.Text,
                    empresa: this.txtempresa.Text,
                    telefono: int.Parse(this.txttelefono.Text)
                    );
                MessageBox.Show($"Clientes modificados: {affectedRows}");
            }
        }

        private void btnnuevopedido_Click(object sender, EventArgs e)
        {
            var affectedRows = this.repo.CrearPedido(
                codigoPedido: this.txtcodigopedido.Text,
                cliente: this.cmbclientes.SelectedItem.ToString()!,
                fechaEntrega: this.txtfechaentrega.Text,
                formaEnvio: this.txtformaenvio.Text,
                importe: int.Parse(this.txtimporte.Text));

            MessageBox.Show($"Pedidos añadidos: {affectedRows}");
        }

        private void btneliminarpedido_Click(object sender, EventArgs e)
        {
            if (this.lstpedidos.SelectedIndex != 1)
            {
                this.repo.EliminarPedidoCliente(this.lstpedidos.SelectedItems[0].ToString()!);
            }
        }
    }
}
