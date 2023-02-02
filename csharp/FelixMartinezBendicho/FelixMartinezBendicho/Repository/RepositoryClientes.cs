using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FelixMartinezBendicho.Helpers;
using FelixMartinezBendicho.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FelixMartinezBendicho.Repository
{
    public class RepositoryClientes
    {
        readonly SqlConnection cn;
        readonly SqlCommand cmd;
        SqlDataReader? reader;

        public RepositoryClientes()
        {
            this.cn = new SqlConnection(HelperConfiguration.GetConnectionString());
            this.cmd = this.cn.CreateCommand();
        }

        public List<string> GetClientes()
        {
            var list = new List<string>();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_CLIENTES";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                list.Add((string)this.reader["Empresa"]);
            }
            this.reader.Close();
            this.cn.Close();
            return list;
        }

        public Cliente FindCliente(string clienteFind)
        {
            var cliente = new Cliente();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_FIND_CLIENTE";

            SqlParameter paramClienteCod = new("@CLIENTE", clienteFind);
            this.cmd.Parameters.Add(paramClienteCod);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                cliente.Cargo = (string)this.reader["Cargo"];
                cliente.Ciudad = (string)this.reader["Ciudad"];
                cliente.CodigoCliente = (string)this.reader["CodigoCliente"];
                cliente.Contacto = (string)this.reader["Contacto"];
                cliente.Empresa = (string)this.reader["Empresa"];
                cliente.Telefono = int.Parse(this.reader["Telefono"].ToString()!);
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return cliente;
        }

        public List<string> GetPedidosCliente(string cliente)
        {
            var list = new List<string>();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_PEDIDOS_CLIENTE";

            SqlParameter paramClienteCod = new("@CLIENTE", cliente);
            this.cmd.Parameters.Add(paramClienteCod);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                list.Add((string)this.reader["CodigoPedido"]);
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return list;
        }

        public int ModificarCliente(string cliente, string cargo, string ciudad, string contacto, string empresa, int telefono)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_UPDATE_CLIENTE";

            SqlParameter paramClienteCod = new("@CLIENTE", cliente);
            this.cmd.Parameters.Add(paramClienteCod);

            SqlParameter paramCargo = new("@CARGO", cargo);
            this.cmd.Parameters.Add(paramCargo);

            SqlParameter paramCiudad = new("@CIUDAD", ciudad);
            this.cmd.Parameters.Add(paramCiudad);

            SqlParameter paramContacto = new("@CONTACTO", contacto);
            this.cmd.Parameters.Add(paramContacto);

            SqlParameter paramEmpresa = new("@EMPRESA", empresa);
            this.cmd.Parameters.Add(paramEmpresa);

            SqlParameter paramTelefono = new("@TELEFONO", telefono);
            this.cmd.Parameters.Add(paramTelefono);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
            return affectedRows;
        }

        public int EliminarPedidoCliente(string codigoPedido)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DELETE_PEDIDO_CLIENTE";

            SqlParameter paramPedidoCod = new("@CODIGO_PEDIDO", codigoPedido);
            this.cmd.Parameters.Add(paramPedidoCod);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
            return affectedRows;
        }

        public int ModificarPedidoCliente(string codigoPedido, string fechaEntrega, string formaEnvio, int importe)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_UPDATE_PEDIDO";

            SqlParameter paramPedidoCod = new("@CODIGO_PEDIDO", codigoPedido);
            this.cmd.Parameters.Add(paramPedidoCod);

            SqlParameter paramFechaEntrega = new("@FECHA_ENTREGA", fechaEntrega);
            this.cmd.Parameters.Add(paramFechaEntrega);

            SqlParameter paramFormaEnvio = new("@FORMA_ENVIO", formaEnvio);
            this.cmd.Parameters.Add(paramFormaEnvio);

            SqlParameter paramImporte = new("@IMPORTE", importe);
            this.cmd.Parameters.Add(paramImporte);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
            return affectedRows;
        }

        public Pedido FindPedido(string codigoPedido)
        {
            var pedido = new Pedido();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_FIND_PEDIDO";

            SqlParameter paramClienteCod = new("@CODIGO_PEDIDO", codigoPedido);
            this.cmd.Parameters.Add(paramClienteCod);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                pedido.CodigoCliente = (string)this.reader["CodigoCliente"];
                pedido.CodigoPedido = (string)this.reader["CodigoPedido"];
                pedido.FechaEntrega = this.reader["FechaEntrega"].ToString()!;
                pedido.FormaEnvio = (string)this.reader["FormaEnvio"];
                pedido.Import = int.Parse(this.reader["Importe"].ToString()!);
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return pedido;
        }

        public int CrearPedido(string codigoPedido, string cliente, string fechaEntrega, string formaEnvio, int importe)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_CREATE_PEDIDO";

            SqlParameter paramPedidoCod = new("@CODIGO_PEDIDO", codigoPedido);
            this.cmd.Parameters.Add(paramPedidoCod);

            SqlParameter paramClienteCod = new("@CLIENTE", cliente);
            this.cmd.Parameters.Add(paramClienteCod);

            SqlParameter paramFechaEntrega = new("@FECHA_ENTREGA", fechaEntrega);
            this.cmd.Parameters.Add(paramFechaEntrega);

            SqlParameter paramFormaEnvio = new("@FORMA_ENVIO", formaEnvio);
            this.cmd.Parameters.Add(paramFormaEnvio);

            SqlParameter paramImporte = new("@IMPORTE", importe);
            this.cmd.Parameters.Add(paramImporte);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
            return affectedRows;
        }
    }
}
