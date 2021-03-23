using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-SRFT1LS;Initial Catalog=SHOP; Integrated Security = SSPI";

            DataSet dataset = new DataSet();


            /*
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Swords", connection);
            dataAdapter.Fill(dataset, "Swords");
            
            foreach (DataRow dataRow in dataset.Tables["Swords"].Rows)
                Console.WriteLine("{0}, {1}", dataRow["id"], dataRow["name"]);

            DataRow dataRow1 = dataset.Tables["Swords"].NewRow();
            dataRow1["id"] = 34986;
            dataRow1["name"] = "ccccc";
            dataRow1["brand_id"] = 1;
            dataset.Tables["Swords"].Rows.Add(dataRow1);

            dataAdapter.Update(dataset,"Swords");
            */

            

            connection.Open();

            SqlCommand selectCountAllCommand= new SqlCommand("SELECT COUNT(*) FROM Swords", connection);

            int numberSwords = (int)selectCountAllCommand.ExecuteScalar();

            Console.WriteLine(numberSwords);

            connection.Close();


            SqlCommand selectAllCommand = new SqlCommand("SELECT * FROM Swords", connection);

            connection.Open();

            SqlDataReader dataReader = selectAllCommand.ExecuteReader();

            while(dataReader.Read())
            {
                Console.WriteLine("{0}, {1}", dataReader.GetInt32(0), dataReader.GetString(1));

            }

            connection.Close();

            SqlCommand insertCommand = new SqlCommand();
            
            connection.Open();
            insertCommand.CommandText = "INSERT Swords(name) VALUES ('Sabie')";
            insertCommand.CommandType = CommandType.Text;
            insertCommand.Connection = connection;
            insertCommand.ExecuteNonQuery();



            //mai trebuie facut adapterul


        }
    }
}
