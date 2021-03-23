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

namespace Assignment1
{
    public partial class Form1 : Form
    {


        SqlConnection dbConn;
        SqlDataAdapter daKnives_Brand, daKnives;
        DataSet ds;
        SqlCommandBuilder cbKnives;
        BindingSource bsKnives_Brand, bsKnives;

      


        private void btnUpdateDB_Click_1(object sender, EventArgs e)
        {
            daKnives.Update(ds, "Knives");
        }

        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dbConn = new SqlConnection(@"Data Source = DESKTOP-SRFT1LS; " +
                "Initial Catalog = SHOP;Integrated Security = SSPI");
            ds = new DataSet();
            daKnives_Brand = new SqlDataAdapter("SELECT * FROM Knives_Brand", dbConn);
            daKnives = new SqlDataAdapter("SELECT * FROM Knives", dbConn);
            cbKnives = new SqlCommandBuilder(daKnives);
            daKnives_Brand.Fill(ds, "Knives_Brand");
            daKnives.Fill(ds, "Knives");

            DataRelation dr = new DataRelation("FK_Knives_Knives__Brand", ds.Tables["Knives_Brand"].Columns["id"],
                ds.Tables["Knives"].Columns["brand_id"]);
            //UniqueConstraint, ForeignKeyConstraint classes
            //GetChildRows de cercetat
            //GetParentRow de cercetat

            ds.Relations.Add(dr);

            //Console.WriteLine(ds.Tables["Knives_Brand"].Constraints[0].GetType());
            //Console.WriteLine(ds.Tables["Knives"].Constraints.Count);

            bsKnives_Brand = new BindingSource();
            bsKnives_Brand.DataSource = ds;
            bsKnives_Brand.DataMember = "Knives_Brand";

            bsKnives = new BindingSource();
            bsKnives.DataSource = bsKnives_Brand; //we use the parent binding source
            bsKnives.DataMember = "FK_Knives_Knives__Brand"; //now whenever we change the selection in Knives_Brand the binding source which ship is selected
                                                             //now thanks to this it will know what pirates to show based on ship selected

            dgvKnives_Brand.DataSource = bsKnives_Brand;
            dgvKnives.DataSource = bsKnives;



        }

    }
}
