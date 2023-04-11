using NugetCustomers_FMB.Models;
using NugetCustomers_FMB.Services;

namespace PruebaNugetCustomers
{
    public partial class Form1 : Form
    {
        readonly ServiceNorthwind service;
        readonly List<string> customersIds = new();

        public Form1()
        {
            InitializeComponent();
            this.service = new ServiceNorthwind();
            this.customersIds = new List<string>();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            CustomersList customersList = await this.service.GetCustomersAsync();
            foreach (Customer c in customersList.Customers)
            {
                this.lstClientes.Items.Add(c.Contact);
                this.customersIds.Add(c.IdCustomer);
            }
        }

        private async void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstClientes.SelectedIndex;
            string idCustomer = this.customersIds[index];
            Customer? customer = await this.service.FindCustomerAsync(idCustomer);
            List<Order> orders = await this.service.GetCustomerOrdersAsync(idCustomer);

            if (customer != null)
            {
                this.txtId.Text = customer.IdCustomer;
                this.txtCompany.Text = customer.CompanyName;
                this.txtCity.Text = customer.City;
                this.txtAdress.Text = customer.Address;

                foreach (var order in orders)
                {
                    this.lstOrders.Items.Clear();
                    this.lstOrders.Items.Add(order.OrderName + " | " + order.OrderId);
                }
            }
        }
    }
}
