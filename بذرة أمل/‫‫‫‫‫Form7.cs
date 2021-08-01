using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace بذرة_أمل
{
	public partial class Form7 : Form
	{
		public bool kk = true;
		
		
		
		public Form7(String stats, String id)
		{
			InitializeComponent();

			getAllRecords1();
			
			getAllRecords2();
			
			getAllRecords3();
			
			if (stats == "new") {
				
				Size = new Size(990, 153);
				
			} else if (stats == "upate") {
				
				textBox4.Text = id;
				
				getDataAll(id);
				
				getAllRecords();
				
			}

		}
		
		public string getDataAll(string rec_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM RECEIPT where rec_id =" + rec_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				textBox1.Text =	reader["num"].ToString();
				
				textBox3.Text = reader["purchase_price_that_was"].ToString();
				
				dateTimePicker1.Value = DateTime.Parse(reader["date_of_purchase"].ToString());
				
				for (int i = 0; i < comboBox2.Items.Count; i++) {
					string hh = (comboBox2.Items[i] as dynamic).Value;
					if (hh.Equals(reader["sup_id"].ToString())) {
						comboBox2.SelectedIndex = i;
						break;
					}
				}
				
			}

			reader.Close();

			con.Close();
			
			return name;

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
		
		public void getAllRecords2()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PRODUCT order by pro_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox1.DisplayMember = "Text";
			
			comboBox1.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox1.Items.Add(new { Text = reader["pro_name"].ToString(), Value = reader["pro_id"].ToString() });
				
				comboBox1.SelectedIndex = 0;
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox1.Items.Count == 0) {
				MessageBox.Show("لايوجد مورد بعد");
				
				kk = false;
			
			}
		}
		
		public void getAllRecords3()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM WAREHOUSE order by war_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox3.DisplayMember = "Text";
			
			comboBox3.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox3.Items.Add(new { Text = reader["war_name"].ToString(), Value = reader["war_id"].ToString() });
				
				comboBox3.SelectedIndex = 0;
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox3.Items.Count == 0) {
				MessageBox.Show("لايوجد مورد بعد");
				
				kk = false;
			
			}
		}
        
        
		public void getAllRecords()
		{
			double iii = 0;
			
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PURCHASE_WAREHOUSE_PRODUCTS where rec_id=" + textBox4.Text + " order by pwp_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {

					reader["pwp_id"].ToString(),
					getNameOFPro(reader["pro_id"].ToString()),
					getNameOFWar(reader["war_id"].ToString()),
					reader["pwp_quantity"].ToString(),
					DateTime.Parse(reader["pwp_entry_date"].ToString()).ToString("dd/MM/yyyy"),
					reader["pwp_price"].ToString(),
					DateTime.Parse(reader["pwp_validity_of_the"].ToString()).ToString("dd/MM/yyyy"),
					DateTime.Parse(reader["pwp_the_power_to_the"].ToString()).ToString("dd/MM/yyyy"),
					reader["pro_id"].ToString(),
					reader["war_id"].ToString(),
					reader["pwp_quantity_of_product"].ToString()

				});
				
				iii += (int.Parse(reader["pwp_quantity"].ToString()) * double.Parse(reader["pwp_price"].ToString()));

			}

			reader.Close();

			con.Close();
			
			textBox2.Text = iii.ToString();

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
		
		
		public string getNameOFWar(string war_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM WAREHOUSE where war_id =" + war_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["war_name"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
	
		
		void Button1Click(object sender, EventArgs e)
		{
			if (textBox4.Text == "") {
			
				if (!textBox1.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals("")) {
				
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "insert into RECEIPT (sup_id,num,date_of_purchase,purchase_price_that_was) " +
					                   "values (" + (comboBox2.SelectedItem as dynamic).Value + ",'" + textBox1.Text + "','"
					                   + dateTimePicker1.Value.ToShortDateString() + "'," + textBox3.Text + ")";

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
				
					Size = new Size(990, 600);
				
					Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
						(Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
				
					textBox4.Text = getLastID();
				
				} else {
					MessageBox.Show("الرجاء التأكد من المدخلات");
				}
			
				
			} else {
				
				if (!textBox1.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals("")) {
					
					
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update RECEIPT set sup_id=" + (comboBox2.SelectedItem as dynamic).Value + ",num='" + textBox1.Text +
					                   "',date_of_purchase='" + dateTimePicker1.Value.ToShortDateString() + "',purchase_price_that_was='" + textBox3.Text +
					                   "' where rec_id=" + textBox4.Text;

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
					
				}
			}
		}
		
		public string getLastID()
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT LAST(rec_id) as lolo FROM RECEIPT";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["lolo"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
	
		
		void Button5Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				if (dataGridView2.SelectedRows[0].Cells[3].Value.ToString().Equals(dataGridView2.SelectedRows[0].Cells[10].Value.ToString())) {
				
					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
				} else {
					MessageBox.Show("ان هذه المادة مباع منها");
				}
			
			}
			
		}
		
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM PURCHASE_WAREHOUSE_PRODUCTS where pwp_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			
			if (!textBox5.Text.Trim().Equals("") && !textBox8.Text.Trim().Equals("")) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "insert into PURCHASE_WAREHOUSE_PRODUCTS " +
				                   "(pro_id,war_id,rec_id,pwp_quantity,pwp_entry_date,pwp_price," +
				                   "pwp_validity_of_the,pwp_the_power_to_the,pwp_quantity_of_product) " +
				                   "values (" + (comboBox1.SelectedItem as dynamic).Value + ","
				                   + (comboBox3.SelectedItem as dynamic).Value + "," + textBox4.Text + "," + textBox5.Text + ",'"
				                   + dateTimePicker2.Value.ToShortDateString() + "'," + textBox8.Text + ",'" + dateTimePicker3.Value.ToShortDateString()
				                   + "','" + dateTimePicker4.Value.ToShortDateString() + "'," + textBox5.Text + ")";

				OleDbCommand command = new OleDbCommand(insertSQL, con);

				command.ExecuteNonQuery();

				con.Close();
			
				getAllRecords();
				
				textBox5.Text = "";
				
				textBox8.Text = "";
			
			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			new Form8(textBox3.Text , dataGridView2.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			var aBalBeginS = textBox3.Text;
			
			double abalbeginVal;
			
			bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
			
			if (parsed && abalbeginVal >= 0.0) {
				// We're good
			} else {
				textBox3.Text = "";
			}
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]")) {
				textBox5.Text = "";
			}
		}
		
		void TextBox8TextChanged(object sender, EventArgs e)
		{
			var aBalBeginS = textBox8.Text;
			
			double abalbeginVal;
			
			bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
			
			if (parsed && abalbeginVal >= 0.0) {
				// We're good
			} else {
				textBox8.Text = "";
			}
		}
		
		
	}
}