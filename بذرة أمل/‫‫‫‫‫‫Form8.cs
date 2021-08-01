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
	public partial class Form8 : Form
	{
		string rec_id = "0";
		
		string purchase_price_that_was = "0";
		
		double all_payment = 0;
		
		public Form8(string purchase_price_that_was, string rec_id)
		{
			InitializeComponent();
			
			this.rec_id = rec_id;
			
			this.purchase_price_that_was = purchase_price_that_was;
			
			getAllRecords();
		
		}
        
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PAYMENT_PURCHASE where rec_id=" + rec_id + " order by paym_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			all_payment = 0;
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["paym_id"].ToString(),
					reader["rec_id"].ToString(),
					reader["payment"].ToString(),
					DateTime.Parse(reader["payment_date"].ToString()).ToString("dd/MM/yyyy"),
						
				});
				
				
				all_payment += double.Parse(reader["payment"].ToString());

			}
			
			textBox1.Text = all_payment.ToString();
			
			reader.Close();

			con.Close();

		}
		
		
		void Button3Click(object sender, EventArgs e)
		{
			if (!textBox8.Text.Trim().Equals("") && !textBox8.Text.Trim().Equals("0")) {
			
				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "insert into PAYMENT_PURCHASE (rec_id,payment,payment_date) values (" + rec_id + "," + textBox8.Text + ",'" + dateTimePicker3.Value.ToShortDateString() + "')";

				OleDbCommand command = new OleDbCommand(insertSQL, con);

				command.ExecuteNonQuery();

				con.Close();
			
				getAllRecords();
				
				textBox8.Text = "0";

			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
			}
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				if (!string.IsNullOrEmpty(textBox8.Text) && !textBox8.Text.Trim().Equals("0")) {
					
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update PAYMENT_PURCHASE set payment=" + textBox8.Text + ",payment_date='" + dateTimePicker3.Value.ToShortDateString() + "' where paym_id=" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
					
					getAllRecords();
					
					textBox8.Text = "0";
				
				} else {
					MessageBox.Show("الرجاء التأكد من المدخلات");
				}
			}
		}
		
		
		void Button5Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
				getAllRecords();
			}
		}
		
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM PAYMENT_PURCHASE where paym_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void TextBox8TextChanged(object sender, EventArgs e)
		{
			var txt = ((TextBox)sender);
			
			try {
				
				double aa = double.Parse(purchase_price_that_was);
				
				aa = aa - all_payment;
				
				if (double.Parse(txt.Text) >= 0 && double.Parse(txt.Text) <= aa) {
					
				} else {
					txt.Text = aa.ToString();
				}
			} catch {
				txt.Text = "0";
			}
			
		}
		
		void DataGridView2MouseClick(object sender, MouseEventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) {  
				textBox8.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
				dateTimePicker3.Value = DateTime.Parse(dataGridView2.SelectedRows[0].Cells[3].Value.ToString());
			}
		}
		
		
	}
}