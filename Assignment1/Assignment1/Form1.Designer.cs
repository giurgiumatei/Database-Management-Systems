
namespace Assignment1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKnives_Brand = new System.Windows.Forms.DataGridView();
            this.dgvKnives = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnives_Brand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnives)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKnives_Brand
            // 
            this.dgvKnives_Brand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnives_Brand.Location = new System.Drawing.Point(474, 45);
            this.dgvKnives_Brand.Name = "dgvKnives_Brand";
            this.dgvKnives_Brand.RowHeadersWidth = 51;
            this.dgvKnives_Brand.RowTemplate.Height = 24;
            this.dgvKnives_Brand.Size = new System.Drawing.Size(377, 196);
            this.dgvKnives_Brand.TabIndex = 0;
            // 
            // dgvKnives
            // 
            this.dgvKnives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnives.Location = new System.Drawing.Point(288, 273);
            this.dgvKnives.Name = "dgvKnives";
            this.dgvKnives.RowHeadersWidth = 51;
            this.dgvKnives.RowTemplate.Height = 24;
            this.dgvKnives.Size = new System.Drawing.Size(770, 231);
            this.dgvKnives.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Knives Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Knives";
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(1230, 244);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(119, 69);
            this.btnUpdateDB.TabIndex = 4;
            this.btnUpdateDB.Text = "Update DB";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 511);
            this.Controls.Add(this.btnUpdateDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvKnives);
            this.Controls.Add(this.dgvKnives_Brand);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnives_Brand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKnives_Brand;
        private System.Windows.Forms.DataGridView dgvKnives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateDB;
    }
}

