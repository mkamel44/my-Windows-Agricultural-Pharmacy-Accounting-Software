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
	public partial class Form9 : Form
	{
		public bool kk = true;
		
		public Form9()
		{
			InitializeComponent();

			
			getAllRecords3();
			getAllRecords2();
		 	 	
		}
		
		public void getAllRecords3()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM WAREHOUSE order by war_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox1.DisplayMember = "Text";
			
			comboBox1.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox1.Items.Add(new { Text = reader["war_name"].ToString(), Value = reader["war_id"].ToString() });
				
				comboBox1.SelectedIndex = 0;
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox1.Items.Count == 0) {
				MessageBox.Show("لايوجد مورد بعد");
				
				kk = false;
			
			}
		}
		
		public void getAllRecords2()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PRODUCT order by pro_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["pro_name"].ToString(), Value = reader["pro_id"].ToString() });
				
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

			String selectSQL = "SELECT * FROM PURCHASE_WAREHOUSE_PRODUCTS where pro_id=" + (comboBox2.SelectedItem as dynamic).Value + " and war_id="+(comboBox1.SelectedItem as dynamic).Value+" order by war_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
				    reader["pwp_id"].ToString(),
				    getNameOFPro(reader["pro_id"].ToString()),
					reader["pwp_quantity"].ToString(),
					DateTime.Parse(reader["pwp_validity_of_the"].ToString()).ToString("dd/MM/yyyy"),
					DateTime.Parse(reader["pwp_the_power_to_the"].ToString()).ToString("dd/MM/yyyy"),
					reader["pwp_quantity_of_product"].ToString(),
						
				});

			}

			reader.Close();

			con.Close();

		}
		
		public string getNameOFPro(string pro_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PRODUCT where pro_id =" + pro_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["pro_name"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		void Button3Click(object sender, EventArgs e)
		{
			getAllRecords();
		}
	
	
		
	}
}