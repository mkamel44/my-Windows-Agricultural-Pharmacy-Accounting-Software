using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace بذرة_أمل
{
	public partial class Form6 : Form
	{
		public bool kk = true;
		
		
		public Form6()
		{
			InitializeComponent();

			getAllRecords();
			
			getAllRecords1();
		
		}
		
		public void getAllRecords1()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM SUPPLIER order by sup_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["sup_name"].ToString(), Value = reader["sup_id"].ToString() });
				
				comboBox2.SelectedIndex = 0;
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox2.Items.Count == 0) {
				MessageBox.Show("لايوجد مورد بعد");
				
				kk = false;
			
			}
		}
        
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM RECEIPT order by rec_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["rec_id"].ToString(),
					reader["num"].ToString(),
					getNameOFSUPPLIER(reader["sup_id"].ToString()),
					DateTime.Parse(reader["date_of_purchase"].ToString()).ToString("dd/MM/yyyy"),
					reader["purchase_price_that_was"].ToString(),
					reader["sup_id"].ToString()
				});

			}

			reader.Close();

			con.Close();
		}
		
		public void getAllRecords2()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM RECEIPT where sup_id = " + (comboBox2.SelectedItem as dynamic).Value + " order by rec_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["rec_id"].ToString(),
					reader["num"].ToString(),
					getNameOFSUPPLIER(reader["sup_id"].ToString()),
					DateTime.Parse(reader["date_of_purchase"].ToString()).ToString("dd/MM/yyyy"),
					reader["purchase_price_that_was"].ToString(),
					reader["sup_id"].ToString()
				});

			}

			reader.Close();

			con.Close();
		}
		
		public string getNameOFSUPPLIER(string cat_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM SUPPLIER where sup_id =" + cat_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["sup_name"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		void Button1Click(object sender, EventArgs e)
		{
			var ss = new Form7("new", "0");
		
			if (ss.kk) {
				ss.ShowDialog();
			}
			
			getAllRecords();
			
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				new Form7("upate", dataGridView2.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();
			
				int ii = dataGridView2.SelectedRows[0].Index;
				
				getAllRecords();
				
				dataGridView2.Rows[ii].Selected = true;
			
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{

			if (dataGridView2.SelectedRows.Count > 0) { 
				
				if (check_here1(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()) && check_here2(dataGridView2.SelectedRows[0].Cells[0].Value.ToString())) {
				
					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
				} else {
					MessageBox.Show("ان هذه المادة مرتبطة بعمليات");
				}
			
			}
			
			
		}
		
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM RECEIPT where rec_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		public bool check_here1(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from  PURCHASE_WAREHOUSE_PRODUCTS where rec_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_here2(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from  PAYMENT_PURCHASE where rec_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		
	
		
		void Button4Click(object sender, EventArgs e)
		{
			getAllRecords();
		}
		
		
		void Button3Click(object sender, EventArgs e)
		{
			getAllRecords2();
		}
		
	}
}