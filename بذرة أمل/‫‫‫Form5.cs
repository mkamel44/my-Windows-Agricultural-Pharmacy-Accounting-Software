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
	public partial class Form5 : Form
	{
		public Form5()
		{
			InitializeComponent();

			getAllRecords();
		
		}
        
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM WAREHOUSE order by war_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["war_id"].ToString(),
					reader["war_name"].ToString(),
					reader["war_address"].ToString(),
						
				});

			}

			reader.Close();

			con.Close();
			
			textBox4.Text = "";
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("")) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "insert into WAREHOUSE (war_name,war_address) values ('" + textBox1.Text + "','" + textBox2.Text + "')";

				OleDbCommand command = new OleDbCommand(insertSQL, con);

				command.ExecuteNonQuery();

				con.Close();
			
				getAllRecords();
				
				rest_data();
			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
			}
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox4.Text)) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "update WAREHOUSE set war_name='" + textBox1.Text + "',war_address='" + textBox2.Text + "' where war_id=" + textBox4.Text;

				OleDbCommand command = new OleDbCommand(insertSQL, con);

				command.ExecuteNonQuery();

				con.Close();
				
				getAllRecords();
 				
				rest_data();
			}
			
		}
		
		void  rest_data()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox4.Text = "";
			
		}
	
		
		void Button5Click(object sender, EventArgs e)
		{
			
			if (dataGridView2.SelectedRows.Count > 0) {

				if (check_name_here(dataGridView2.SelectedRows[0].Cells[0].Value.ToString())) {
				
					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
					rest_data();
				
				} else {
			
					MessageBox.Show("ان هذه المادة مرتبطة بعمليات");
				}	
								
			}
		}
		
		public bool check_name_here(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from  PURCHASE_WAREHOUSE_PRODUCTS where war_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) {  
				textBox4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
				textBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
				textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
			}
		}
		
	
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM WAREHOUSE where war_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		

	}
}