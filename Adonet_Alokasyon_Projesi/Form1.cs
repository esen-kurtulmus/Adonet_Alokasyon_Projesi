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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection=new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=PerakendeSatis;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Product",connection);
            SqlDataAdapter adapter=new SqlDataAdapter(command); //datagridviewe veri çekmek için kullanılır.
            DataTable dataTable=new DataTable(); //sanal tablo
            adapter.Fill(dataTable);  
            dtgProduct.DataSource=dataTable;
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=PerakendeSatis;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into  Product (ProductName) Values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("ürün başarılı bir şekilde eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=PerakendeSatis;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("delete from product where productID=@p1", connection);
            command.Parameters.AddWithValue("@p1",txtProductID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Silindi");

            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=PerakendeSatis;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("update product set productName=@p1 where productID=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.Parameters.AddWithValue("@p2", txtProductID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Güncellendi");
        }
    }
}
