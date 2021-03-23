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

namespace Seminar2FullApp
{
    public partial class Form1 : Form
    {
        SqlConnection dbConn;
        SqlDataAdapter daShips, daPirates;
        DataSet ds;
        SqlCommandBuilder cbPirates;
        BindingSource bsShips, bsPirates;

        private void Form1_Load(object sender, EventArgs e)
        {
            dbConn = new SqlConnection(@"Data Source = DESKTOP-SRFT1LS; " +
                "Initial Catalog = SHOP;Integrated Security = SSPI");
            ds = new DataSet();
            daShips = new SqlDataAdapter("SELECT * FROM Ships", dbConn);
            daPirates = new SqlDataAdapter("SELECT * FROM Pirates", dbConn);
            cbPirates = new SqlCommandBuilder(daPirates);
            daShips.Fill(ds, "SHIPS");
            daPirates.Fill(ds, "Pirates");

            DataRelation dr = new DataRelation("FK_Pirates_Ships", ds.Tables["Ships"].Columns["ShipID"],
                ds.Tables["Pirates"].Columns["ShipID"]);
            //UniqueConstraint, ForeignKeyConstraint classes
            //GetChildRows de cercetat
            //GetParentRow de cercetat

            ds.Relations.Add(dr);

            //Console.WriteLine(ds.Tables["Ships"].Constraints[0].GetType());
            //Console.WriteLine(ds.Tables["Pirates"].Constraints.Count);

            bsShips = new BindingSource();
            bsShips.DataSource = ds;
            bsShips.DataMember = "Ships";

            bsPirates = new BindingSource();
            bsPirates.DataSource = bsShips; //we use the parent binding source
            bsPirates.DataMember = "FK_Pirates_Ships"; //now whenever we change the selection in Ships the binding source which ship is selected
                                                       //now thanks to this it will know what pirates to show based on ship selected

            dgvShips.DataSource = bsShips;
            dgvPirates.DataSource = bsPirates;




        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            daPirates.Update(ds, "Pirates");

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
