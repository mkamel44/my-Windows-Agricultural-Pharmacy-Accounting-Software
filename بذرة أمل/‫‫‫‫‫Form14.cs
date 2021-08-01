using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.VisualStyles;

namespace بذرة_أمل
{
	public partial class Form14 : Form
	{
		public bool kk = true;
		
		public string jj = "";
		
		public Form14()
		{
			InitializeComponent();	

			getAllCUSTOMER();
		}
        
		public void getAllCUSTOMER()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CUSTOMER order by cust_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox1.DisplayMember = "Text";
			
			comboBox1.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox1.Items.Add(new { Text = reader["cust_name"].ToString(), Value = reader["cust_id"].ToString() });
				
				comboBox1.SelectedIndex = 0;
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox1.Items.Count == 0) {
				MessageBox.Show("لايوجد زبائن بعد");
				
				kk = false;
			
			}
		}
		
		public void getAllCRECEIPT()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CRECEIPT where cust_id=" + (comboBox1.SelectedItem as dynamic).Value + " order by crec_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["crec_id"].ToString(),
					reader["purchase_price_that_was"].ToString(),
					reader["purchase_price_that_must"].ToString(),
					reader["discount"].ToString(),
					reader["tax"].ToString(),
					DateTime.Parse(reader["date_of_purchase"].ToString()).ToString("dd/MM/yyyy")
				});

			}

			reader.Close();

			con.Close();
	
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
			
				new Form15(dataGridView2.SelectedRows[0].Cells[1].Value.ToString(), dataGridView2.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();
	
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			getAllCRECEIPT();
		}
		
		
		
		void DataGridView2CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
				
				jj = dataGridView2.CurrentRow.Cells[0].Value.ToString();
				
				Close();
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			DataGridView2CellDoubleClick(null, null);
		}
	}
}