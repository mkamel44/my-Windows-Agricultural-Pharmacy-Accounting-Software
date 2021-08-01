using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace بذرة_أمل
{
	public partial class Form11 : Form
	{
		public string Action = "";
		
		public Form11()
		{
			InitializeComponent();
            
			getAllCATEGORY();
			
			getAllCUSTOMER();
            
		}
        
        
		public void getAllCATEGORY()
		{
			flowLayoutPanel2.Controls.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CATEGORY order by cat_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				var b = new XButton(123, 104);
				
				b.Click += catClick;
				
				b.cat_id = reader["cat_id"].ToString();
				
				b.cat_name = reader["cat_name"].ToString();
				
				b.RightText = reader["cat_name"].ToString();
        
				this.flowLayoutPanel2.Controls.Add(b);

			}

			reader.Close();

			con.Close();
			
		}
        
		void catClick(object sender, EventArgs e)
		{
			var xb = (XButton)sender;
			
			getAllPRODUCT(xb.cat_id);
		}
        
		public void getAllPRODUCT(string cat_id)
		{
			
			flowLayoutPanel1.Controls.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PRODUCT where cat_id=" + cat_id + " order by pro_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				var b = new XButton(123, 104);
				
				b.Click += proClick;
				
				b.RightText = reader["pro_name"].ToString() + Environment.NewLine + " حجم المنتج " + reader["size_pro"].ToString();
				
				b.pro_id = reader["pro_id"].ToString();
				
				b.cat_id = reader["cat_id"].ToString();
				
				b.pro_name = reader["pro_name"].ToString();
				
				b.form_pro = reader["form_pro"].ToString();
				
				b.size_pro = reader["size_pro"].ToString();
				
				b.minimum = reader["minimum"].ToString();
				
				b.maximum = reader["maximum"].ToString();
				
				b.pic = reader["pic"].ToString();
        
				this.flowLayoutPanel1.Controls.Add(b);

			}

			reader.Close();

			con.Close();
			
		}
        
		void proClick(object sender, EventArgs e)
		{
			var btn = (XButton)sender;
			
			if (Action.Equals("add")) {
			
				var ss = new Form13(textBox1.Text, btn);
				
				if (ss.kk) {
					ss.ShowDialog();
				}
				
				getAllCPRODUCT();
				
				sum_all();
				
			} else if (Action.Equals("update")) {
			
				var ss = new Form13(textBox1.Text, btn);
				
				if (ss.kk) {
					ss.ShowDialog();
				}
				
				getAllCPRODUCT();
				
				sum_all();
				
			} else {
				
				ShowMessageBox("الرجاء تحديد حالة الفاتورة (فاتورة جديدة - اظهار فاتورة)", "تنبيه");
			
			}
			
		}
		
		public double sum_all_cproduct()
		{
			double all = 0;
			
			for (int ii = 0; ii < dataGridView2.RowCount; ii++) {
					
				all += double.Parse(dataGridView2.Rows[ii].Cells[4].Value.ToString());
			}
			
			return all;
		}
		
		public double sum_all()
		{
			double all = sum_all_cproduct();
		
			textBox5.Text = (all - double.Parse(textBox3.Text) - double.Parse(textBox4.Text)).ToString();
		
			return all;
		}
				
		public void getAllCPRODUCT()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CPRODUCT where crec_id=" + textBox1.Text + " order by cpro_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["cpro_id"].ToString(),
					getPro_name(getPro_id(reader["pwp_id"].ToString())),
					reader["cpro_quantity"].ToString(),
					reader["cpro_price"].ToString(),
					(double.Parse(reader["cpro_price"].ToString()) * double.Parse(reader["cpro_quantity"].ToString())).ToString(),
					reader["pwp_id"].ToString()
				});

			}

			reader.Close();

			con.Close();
	
		}
		
		public string getPro_id(string pwp_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PURCHASE_WAREHOUSE_PRODUCTS where pwp_id =" + pwp_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["pro_id"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		public string getPro_name(string pro_id)
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
		
		public void ShowMessageBox(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			
			var form2 = new Form1();
			
			form2.Closed += (s, args) => this.Close(); 
			
			form2.Show();
		}
		
		
		public void getAllCUSTOMER()
		{
			dataGridView1.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CUSTOMER order by cust_id asc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView1.Rows.Add(new string[] {
					reader["cust_id"].ToString(),
					reader["cust_name"].ToString(),
					reader["cust_phone"].ToString(),
					reader["cust_mobile"].ToString(),
					reader["cust_address"].ToString()
						
				});

			}

			reader.Close();

			con.Close();
	
		}
				
		public void action_add()
		{
			Action = "add";
			
			addCRECEIPT();
			
			textBox1.Text = getLastID();
			
			textBox3.Text = "0";
			
			textBox4.Text = "0";
			
			textBox5.Text = "0";
			
			button13.Enabled = false;
			
			button62.Enabled = false;
			
			dataGridView1.Enabled = false;
			
			textBox1.Enabled = false;
			
			dataGridView2.Rows.Clear();
			
		}
		
		public void action_update()
		{
			Action = "update";
			
			dataGridView1.Enabled = false;
			
			button13.Enabled = false;
			
			button62.Enabled = false;
			
			textBox1.Enabled = false;
		}
		
		
		public void addCRECEIPT()
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "insert into CRECEIPT (cust_id,discount,tax,date_of_purchase,purchase_price_that_was) " +
			                   "values (" + dataGridView1.CurrentRow.Cells[0].Value + ",0,0,'" + dateTimePicker1.Value.ToShortDateString() + "',0)";

			OleDbCommand command = new OleDbCommand(insertSQL, con);
	
			command.ExecuteNonQuery();

			con.Close();

		}
		
		
		public void addCPAYMENT_PURCHASE()
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "insert into CPAYMENT_PURCHASE (crec_id,cpayment,cpayment_date) " +
			                   "values (" + textBox1.Text + "," + textBox2.Text + ",'" + dateTimePicker1.Value.ToShortDateString() + "')";

			OleDbCommand command = new OleDbCommand(insertSQL, con);
	
			command.ExecuteNonQuery();

			con.Close();

		}
		
		public string getLastID()
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT LAST(crec_id) as lolo FROM CRECEIPT";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["lolo"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		public bool check_crec_id_is_here()
		{
			bool boo = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CRECEIPT where crec_id=" + textBox1.Text;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				boo = true;
							
				string cust_id = reader["cust_id"].ToString();
				
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[0].Value.Equals(cust_id)) {
						row.Selected = true;
						break;
					}
				}
				
				textBox3.Text = reader["discount"].ToString();
				
				textBox4.Text = reader["tax"].ToString();
				
				dateTimePicker1.Value = DateTime.Parse(reader["date_of_purchase"].ToString());
				
				textBox5.Text = reader["purchase_price_that_must"].ToString();
				
				textBox2.Text = reader["purchase_price_that_was"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return boo;

		}
		
		void Button62Click(object sender, EventArgs e)
		{
			action_add();
		}
		
		public void Button13Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("")) {
			
				if (check_crec_id_is_here()) {
				
					action_update();
					
					getAllCPRODUCT();
					
					sum_all();
					
				} else {
					ShowMessageBox("الرقم الذي ادخلته غير صحيح", "تنبيه");
				}
				
				
				
			} else {
				ShowMessageBox("الرجاء التأكد من المدخلات", "تنبيه");
			}

		}
		
		
		public void updateCRECEIPT()
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "update CRECEIPT set discount=" + textBox3.Text + ",purchase_price_that_must=" + textBox5.Text + ",purchase_price_that_was=" + textBox2.Text + ",date_of_purchase='" + dateTimePicker1.Value.ToShortDateString() + "' where crec_id=" + textBox1.Text;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		}
		
		public void action_save()
		{
		
			Action = "save";
			
			addCPAYMENT_PURCHASE();
			
			updateCRECEIPT();
			
			textBox1.Text = "";
			
			textBox3.Text = "0";
			
			textBox4.Text = "0";
			
			textBox5.Text = "0";
			
			textBox2.Text = "0";
			
			button13.Enabled = true;
			
			button62.Enabled = true;
			
			dataGridView1.Enabled = true;
			
			textBox1.Enabled = true;
			
			dataGridView2.Rows.Clear();
			
		}
		
		
		
		void Button2Click(object sender, EventArgs e)
		{
			double all = sum_all();
			
			double cpay = double.Parse(textBox2.Text);
			
			if (cpay <= all && dataGridView1.Rows.Count != 0 && dataGridView2.Rows.Count != 0) {
				action_save();
			} else {
				ShowMessageBox("الرجاء التأكد من المبالغ", "تنبيه");
			}
			
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			var txt = ((TextBox)sender);
			
			double all = sum_all_cproduct();
			
			all = all - double.Parse(textBox4.Text);
			
			try {
				if (double.Parse(txt.Text) >= 0 && double.Parse(txt.Text) <= all) {
					
				} else {
					txt.Text = all.ToString();
				}
			} catch {
				txt.Text = "0";
			}
			
			
			sum_all();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			var txt = ((TextBox)sender);
			
			if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, "[^0-9]")) {
				txt.Text = "";
			}
		}
		
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			var txt = ((TextBox)sender);
			
			double all = sum_all_cproduct();
			
			all = all - double.Parse(textBox3.Text);
			
			try {
				if (double.Parse(txt.Text) >= 0 && double.Parse(txt.Text) <= all) {
					
				} else {
					txt.Text = all.ToString();
				}
			} catch {
				txt.Text = "0";
			}
			
			
			sum_all();
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
			var txt = ((TextBox)sender);
			
			double all = sum_all_cproduct();
			
			all = all - double.Parse(textBox3.Text) - double.Parse(textBox4.Text);
			
			try {
				if (double.Parse(txt.Text) >= 0 && double.Parse(txt.Text) <= all) {
					
				} else {
					txt.Text = all.ToString();
				}
			} catch {
				txt.Text = "0";
			}
			
		}
		
		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				Button13Click(sender, e);
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
				
				int pwp_quantity_of_product = getpwp_quantity_of_product();
				
				pwp_quantity_of_product += int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
				
				plus_pwp_quantity_of_product(pwp_quantity_of_product.ToString());
				
				deleteCPRODUCT();
				
				getAllCPRODUCT();
				
				sum_all();
				
			}
		}
		
		public void deleteCPRODUCT()
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM CPRODUCT where cpro_id=" + dataGridView2.CurrentRow.Cells[0].Value.ToString();

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		public int getpwp_quantity_of_product()
		{
			int pwp_quantity_of_product = 0;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PURCHASE_WAREHOUSE_PRODUCTS where pwp_id =" + dataGridView2.CurrentRow.Cells[5].Value.ToString();

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				pwp_quantity_of_product = int.Parse(reader["pwp_quantity_of_product"].ToString());
				
			}

			reader.Close();

			con.Close();
			
			return pwp_quantity_of_product;

		}
		
		
		public void plus_pwp_quantity_of_product(string new_pwp_quantity_of_product)
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "update PURCHASE_WAREHOUSE_PRODUCTS set pwp_quantity_of_product=" + new_pwp_quantity_of_product + " where pwp_id=" + dataGridView2.CurrentRow.Cells[5].Value.ToString();

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		}
		
		       
	}
}
