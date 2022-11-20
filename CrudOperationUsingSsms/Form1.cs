using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrudOperationUsingSsms
{
   
    public partial class Form1 : Form
    {
      

        Customer customer=new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        public static String pp;
        public static String contactnmm;
        public static String companynmm;
        public static String id;
        private void button1_Click(object sender, EventArgs e)
        {
           pp=textBox3.Text;
            contactnmm=textBox2.Text;
            companynmm=textBox1.Text;
            id = textBox4.Text;
            customer.Insertcustomer(customer);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customer.Getcustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer.companynam = textBox1.Text;
            customer.contactnam = textBox2.Text;
            customer.phon = textBox3.Text;
            customer.cusid = textBox4.Text;
            var success = customer.updatecustomer(customer);
            dataGridView1.DataSource = customer.Getcustomer();
            if (success)

            {
                
              
                MessageBox.Show("Employee has been added successfully");
            
             }

            else
            {
                MessageBox.Show("Error occured. Please try again...");
            }
 
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            customer.cusid = textBox4.Text;
            var success = customer.deletecustomer(customer);
            dataGridView1.DataSource = customer.Getcustomer();
            if (success)

            {


                MessageBox.Show("Employee has been added successfully");

            }

            else
            {
                MessageBox.Show("Error occured. Please try again...");
            }
        }
    }
}
