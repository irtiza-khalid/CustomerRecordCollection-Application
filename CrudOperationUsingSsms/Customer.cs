using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationUsingSsms
{
    internal class Customer
    {

        public string id { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string phone { get; set; }


        public string cusid;
        public string companynam;
        public string contactnam;
        public string phon;
        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        private const string InsertQuery = "insert Into customer(companyname, contactname, phone)  Values (@companyname, @contactname, @phone)";
        public bool Insertcustomer(Customer customer)
        {

            int rows;
            using (SqlConnection con = new SqlConnection(myConn))

            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {

                    com.Parameters.AddWithValue("@companyname", Form1.companynmm);
                    com.Parameters.AddWithValue("@contactname", Form1.contactnmm);
                    com.Parameters.AddWithValue("@phone", Form1.pp);

                    rows = com.ExecuteNonQuery();
                }



            }

            return (rows > 0) ? true : false;
        }


        private const string SelectQuery = "Select* from customer";

        public DataTable Getcustomer()

        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {

                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                {
                    adapter.Fill(datatable);


                }

                return datatable;

            }




        }
        private const string updateQuery = "update customer set companyname=@companyname,contactname=@contactname,phone=@phone where ID_column=@ID_column ";
        public bool updatecustomer(Customer customer)
        {

            int rows;
            using (SqlConnection con = new SqlConnection(myConn))

            {
                con.Open();
                using (SqlCommand com = new SqlCommand(updateQuery, con))
                {

                    com.Parameters.AddWithValue("@companyname", customer.companynam);
                    com.Parameters.AddWithValue("@contactname",customer.contactnam );
                    com.Parameters.AddWithValue("@phone",customer.phon);
                    com.Parameters.AddWithValue("@ID_column",customer.cusid );
                    rows = com.ExecuteNonQuery();
                }



            }

            return (rows > 0) ? true : false;
        }




        private const string DeleteQuery = "Delete from customer where ID_column = @ID_column";

        public bool deletecustomer(Customer customer)
        {

            int rows;
            using (SqlConnection con = new SqlConnection(myConn))

            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {

                    
                    com.Parameters.AddWithValue("@ID_column", customer.cusid);
                    rows = com.ExecuteNonQuery();
                }



            }

            return (rows > 0) ? true : false;
        }

    }
}
