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
	public partial class Form12 : Form
	{
		public Form12()
		{
			InitializeComponent();

			getAllRecords();
		
		}
        
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CUSTOMER order by cust_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["cust_id"].ToString(),
					reader["cust_name"].ToString(),
					reader["cust_phone"].ToString(),
					reader["cust_mobile"].ToString(),
					reader["cust_address"].ToString()
						
				});

			}

			reader.Close();

			con.Close();
			
			textBox4.Text = "";
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text) && !textBox1.Text.Trim().Equals("المفرق")) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "insert into CUSTOMER (cust_name,cust_phone,cust_mobile,cust_address) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";

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
			if (!string.IsNullOrEmpty(textBox4.Text) && !textBox1.Text.Equals("المفرق")) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "update CUSTOMER set cust_name='" + textBox1.Text + "',cust_phone='" + textBox2.Text + "',cust_mobile='" + textBox3.Text + "',cust_address='" + textBox5.Text + "' where cust_id=" + textBox4.Text;

				OleDbCommand command = new OleDbCommand(insertSQL, con);

				command.ExecuteNonQuery();

				con.Close();
				
				getAllRecords();
 				
				rest_data();
			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
			}
			
		}
		
		void  rest_data()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox5.Text = "";
			textBox4.Text = "";
		}
	
		
		void Button5Click(object sender, EventArgs e)
		{
			
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				if (check_name_here(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()) && !textBox1.Text.Equals("المفرق")) {
					
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

			String selectSQL = "SELECT * from  CRECEIPT where cust_id=" + id;

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
				textBox3.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
				textBox5.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
			}
		}
		
	
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM CUSTOMER where cust_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		

	}
}