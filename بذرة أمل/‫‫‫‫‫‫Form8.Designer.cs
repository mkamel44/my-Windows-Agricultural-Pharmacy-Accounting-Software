namespace بذرة_أمل
{
    partial class Form8
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
        	this.button2 = new System.Windows.Forms.Button();
        	this.button5 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.label10 = new System.Windows.Forms.Label();
        	this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBox8 = new System.Windows.Forms.TextBox();
        	this.label12 = new System.Windows.Forms.Label();
        	this.dataGridView2 = new System.Windows.Forms.DataGridView();
        	this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(216, 296);
        	this.button2.Margin = new System.Windows.Forms.Padding(4);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(139, 34);
        	this.button2.TabIndex = 206;
        	this.button2.Text = "تعديل الدفعة";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// button5
        	// 
        	this.button5.Location = new System.Drawing.Point(13, 296);
        	this.button5.Margin = new System.Windows.Forms.Padding(4);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(133, 34);
        	this.button5.TabIndex = 209;
        	this.button5.Text = "حذف الدفعة";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(425, 296);
        	this.button3.Margin = new System.Windows.Forms.Padding(4);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(131, 34);
        	this.button3.TabIndex = 232;
        	this.button3.Text = "اضافة دفعة";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// label10
        	// 
        	this.label10.AutoSize = true;
        	this.label10.Location = new System.Drawing.Point(195, 268);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(86, 19);
        	this.label10.TabIndex = 246;
        	this.label10.Text = "تاريخ الدفعة";
        	// 
        	// dateTimePicker3
        	// 
        	this.dateTimePicker3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.dateTimePicker3.Location = new System.Drawing.Point(13, 262);
        	this.dateTimePicker3.Name = "dateTimePicker3";
        	this.dateTimePicker3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.dateTimePicker3.RightToLeftLayout = true;
        	this.dateTimePicker3.Size = new System.Drawing.Size(165, 27);
        	this.dateTimePicker3.TabIndex = 252;
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(13, 229);
        	this.textBox1.MaxLength = 10;
        	this.textBox1.Name = "textBox1";
        	this.textBox1.ReadOnly = true;
        	this.textBox1.Size = new System.Drawing.Size(426, 27);
        	this.textBox1.TabIndex = 259;
        	this.textBox1.Text = "0";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(442, 232);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(111, 19);
        	this.label1.TabIndex = 258;
        	this.label1.Text = "مجموع الدفعات";
        	// 
        	// textBox8
        	// 
        	this.textBox8.Location = new System.Drawing.Point(297, 262);
        	this.textBox8.MaxLength = 10;
        	this.textBox8.Name = "textBox8";
        	this.textBox8.Size = new System.Drawing.Size(142, 27);
        	this.textBox8.TabIndex = 257;
        	this.textBox8.Text = "0";
        	this.textBox8.TextChanged += new System.EventHandler(this.TextBox8TextChanged);
        	// 
        	// label12
        	// 
        	this.label12.AutoSize = true;
        	this.label12.Location = new System.Drawing.Point(444, 265);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(109, 19);
        	this.label12.TabIndex = 256;
        	this.label12.Text = "مـبـلـغ الـدفـعـة";
        	// 
        	// dataGridView2
        	// 
        	this.dataGridView2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        	this.dataGridView2.AllowUserToAddRows = false;
        	this.dataGridView2.AllowUserToDeleteRows = false;
        	this.dataGridView2.AllowUserToResizeColumns = false;
        	this.dataGridView2.AllowUserToResizeRows = false;
        	this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        	this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1,
			this.Column10,
			this.Column2,
			this.Column5});
        	this.dataGridView2.Location = new System.Drawing.Point(13, 15);
        	this.dataGridView2.Margin = new System.Windows.Forms.Padding(6);
        	this.dataGridView2.MultiSelect = false;
        	this.dataGridView2.Name = "dataGridView2";
        	this.dataGridView2.ReadOnly = true;
        	this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.dataGridView2.RowHeadersVisible = false;
        	this.dataGridView2.RowTemplate.Height = 25;
        	this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dataGridView2.ShowCellToolTips = false;
        	this.dataGridView2.ShowEditingIcon = false;
        	this.dataGridView2.Size = new System.Drawing.Size(543, 205);
        	this.dataGridView2.TabIndex = 255;
        	// 
        	// Column1
        	// 
        	this.Column1.HeaderText = "الرقم";
        	this.Column1.Name = "Column1";
        	this.Column1.ReadOnly = true;
        	this.Column1.Visible = false;
        	// 
        	// Column10
        	// 
        	this.Column10.HeaderText = "فاتورة الشراء ID";
        	this.Column10.Name = "Column10";
        	this.Column10.ReadOnly = true;
        	this.Column10.Visible = false;
        	// 
        	// Column2
        	// 
        	this.Column2.FillWeight = 104.6212F;
        	this.Column2.HeaderText = "المبلغ";
        	this.Column2.Name = "Column2";
        	this.Column2.ReadOnly = true;
        	// 
        	// Column5
        	// 
        	this.Column5.FillWeight = 107.8569F;
        	this.Column5.HeaderText = "تاريخ الدفعة";
        	this.Column5.Name = "Column5";
        	this.Column5.ReadOnly = true;
        	// 
        	// Form8
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(565, 335);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox8);
        	this.Controls.Add(this.label12);
        	this.Controls.Add(this.dataGridView2);
        	this.Controls.Add(this.dateTimePicker3);
        	this.Controls.Add(this.label10);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.button5);
        	this.Controls.Add(this.button2);
        	this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Form8";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "دفعات فاتورة الشراء";
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}