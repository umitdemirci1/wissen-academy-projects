using BusinessLayer;

namespace PresentationLayer
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            BusinessLogicLayer businessLayer = new();
            dgvCustomers.DataSource = businessLayer.GetAllCustomers();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string customerID = string.Empty;
            customerID = dgvCustomers[0, e.RowIndex].Value.ToString();

            MessageBox.Show($"Seçilen customerID si : {customerID}");
        }
    }
}
