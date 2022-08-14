using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Adonet_Alokasyon_Projesi
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=PerakendeSatis;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Performans", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command); //datagridviewe veri çekmek için kullanılır.
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource=dataTable;
            connection.Close();
        }
    }
}
