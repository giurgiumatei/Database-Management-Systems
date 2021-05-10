using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapterParent, dataAdapterChild;
        private BindingSource bindingSourceParent, bindingSourceChild;


        public Form1()
        {
            InitializeComponent();
            loadConfigurationFile();
        }

        private void loadConfigurationFile()
        {
            sqlConnection = new SqlConnection(getConnectionString());
            dataSet = new DataSet();

            dataAdapterParent = new SqlDataAdapter(getParentQuery(), sqlConnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterParent);
            dataAdapterParent.Fill(dataSet, getParentTable());

            dataAdapterChild = new SqlDataAdapter(getChildQuery(), sqlConnection);
            commandBuilder = new SqlCommandBuilder(dataAdapterChild);
            dataAdapterChild.Fill(dataSet, getChildTable());


            DataRelation childParentRelation = new DataRelation("fk_child_parent", dataSet.Tables[getParentTable()].Columns[getPrimaryKeyName()],
                dataSet.Tables[getChildTable()].Columns[getForeignKeyName()]);
            dataSet.Relations.Add(childParentRelation);

            //create bindings
            bindingSourceParent = new BindingSource();
            bindingSourceParent.DataSource = dataSet;
            bindingSourceParent.DataMember = getParentTable();

            bindingSourceChild = new BindingSource();
            bindingSourceChild.DataSource = bindingSourceParent;
            bindingSourceChild.DataMember = "fk_child_parent";

            //populate views
            parentView.DataSource = bindingSourceParent;
            childView.DataSource = bindingSourceChild;

        }
        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            //fill method updates the dataset, update method updates the DB
            dataAdapterParent.Update(this.dataSet, getParentTable());
            dataAdapterChild.Update(this.dataSet, getChildTable());

        }
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString.ToString();
        }


        private string getParentTable()
        {
            return ConfigurationManager.AppSettings["parent_table"];
        }

        private string getChildTable()
        {
            return ConfigurationManager.AppSettings["child_table"];
        }

        private string getParentQuery()
        {
            return ConfigurationManager.AppSettings["parent_query"];
        }
        private string getChildQuery()
        {
            return ConfigurationManager.AppSettings["child_query"];
        }
        private string getPrimaryKeyName()
        {
            return ConfigurationManager.AppSettings["parent_table_pk"];
        }

        private string getForeignKeyName()
        {

            return ConfigurationManager.AppSettings["child_table_fk"];

        }



       
    }
}
