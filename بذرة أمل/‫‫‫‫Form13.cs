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

namespace بذرة_أمل
{
	public partial class Form13 : Form
	{
			
		public XButton btn;
		
		public string crec_id;
		
		public bool kk = true;
		
		public Form13(string crec_id, XButton btn)
		{
			InitializeComponent();

			this.crec_id = crec_id;
			
			this.btn = btn;
			
			textBox1.Text = btn.pro_name;
			
			textBox2.Text = btn.minimum;
			
			textBox3.Text = btn.maximum;
			
			getAllPURCHASE_WAREHOUSE_PRODUCTS(btn.pro_id);
		
		}
        
        
		public void getAllPURCHASE_WAREHOUSE_PRODUCTS(string pro_id)
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT DISTINCT pwp_price,pwp_id,pwp_quantity,pwp_quantity_of_product,pwp_price,pwp_validity_of_the,pwp_the_power_to_the FROM PURCHASE_WAREHOUSE_PRODUCTS where pro_id=" + pro_id + " and pwp_quantity_of_product <> 0";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["pwp_id"].ToString(),
					reader["pwp_quantity"].ToString(),
					reader["pwp_quantity_of_product"].ToString(),
					reader["pwp_price"].ToString(),
					DateTime.Parse(reader["pwp_validity_of_the"].ToString()).ToString("dd/MM/yyyy"),
					DateTime.Parse(reader["pwp_the_power_to_the"].ToString()).ToString("dd/MM/yyyy")
				});

			}

			reader.Close();

			con.Close();
			
			if (dataGridView2.Rows.Count == 0) {
				MessageBox.Show("لايوجد كميات لهذا المنتج بعد");
				
				kk = false;
			
			}
			
			
			textBox4.Text = "";
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if (double.Parse(textBox5.Text) > 0) {
				
				add();
				
				double new_pwp_quantity_of_product = double.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString()) - double.Parse(textBox4.Text);
				
				minus_pwp_quantity_of_product(new_pwp_quantity_of_product.ToString());
				
				Close();
				
			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
				
			}
		}
		
		
		public void minus_pwp_quantity_of_product(string new_pwp_quantity_of_product)
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "update PURCHASE_WAREHOUSE_PRODUCTS set pwp_quantity_of_product=" + new_pwp_quantity_of_product + " where pwp_id=" + dataGridView2.CurrentRow.Cells[0].Value;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		}
		
		public void add()
		{
			OleDbConnection con = DataBase.createConnection();

			String insertSQL = "insert into CPRODUCT (pwp_id,crec_id,cpro_quantity,cpro_price) " +
			                   "values (" + dataGridView2.CurrentRow.Cells[0].Value + "," + crec_id + "," + textBox4.Text + "," + textBox6.Text + ")";

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
			
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			var txt = ((TextBox)sender);
			
			try {
				if (int.Parse(txt.Text) >= 0 && int.Parse(txt.Text) <= int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString())) {
					
				} else {
					txt.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
					txt.SelectionStart = txt.Text.Length;
					txt.SelectionLength = 0;
				}
			} catch {
				txt.Text = "0";
			}
			
			SumAll();
		}
		
		
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			var aBalBeginS = ((TextBox)sender).Text;
			
			double abalbeginVal;
			
			bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
			
			if (parsed && abalbeginVal >= 0.0) {
				// We're good
			} else {
				((TextBox)sender).Text = "";
			}
			
			SumAll();
		}
		
		
		public void SumAll()
		{
		
			try {
		
				textBox5.Text = (double.Parse(textBox4.Text) * double.Parse(textBox6.Text)).ToString();
				
			} catch {
				textBox5.Text = "0.0";
			}
		}
		
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			textBox4.Text = "0";
			
			textBox6.Text = "0.0";
			
			textBox5.Text = "0.0";
		}
		

	}
}