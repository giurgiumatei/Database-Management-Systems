using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sHOPDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sHOPDataSet.Knives' table. You can move, or remove it, as needed.
            this.knivesTableAdapter.Fill(this.sHOPDataSet.Knives);
            // TODO: This line of code loads data into the 'sHOPDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sHOPDataSet.Client);

        }
    }
}
