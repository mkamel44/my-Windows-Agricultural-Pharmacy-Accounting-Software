using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace بذرة_أمل
{
	public partial class Form3 : Form
	{
		
		public bool kk = true;
		
		
		
		public Form3()
		{
			InitializeComponent();

			getAllRecords();
			
			getAllRecords2();
			
			rest_data();
		
		}
		
		public void getAllRecords2()
		{
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CATEGORY order by cat_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["cat_name"].ToString(), Value = reader["cat_id"].ToString() });
				
			}

			reader.Close();

			con.Close();
			
			if (comboBox2.Items.Count == 0) {
				MessageBox.Show("لايوجد اصناف بعد");
				
				kk = false;
			
			}
		}
        
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM PRODUCT order by cat_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["pro_id"].ToString(),
					reader["cat_id"].ToString(),
					reader["pro_name"].ToString(),
					getNameOFCat(reader["cat_id"].ToString()),
					reader["form_pro"].ToString(),
					reader["size_pro"].ToString(),
					reader["minimum"].ToString(),
					reader["maximum"].ToString(),
					reader["pic"].ToString()
					
				});

			}

			reader.Close();

			con.Close();
			
			textBox4.Text = "";
		}
		
		void  rest_data()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			
			pictureBox1.Image = null;
			pictureBox1.Tag = "";
			pictureBox1.Name = "";
			
			if (comboBox2.Items.Count != 0) {
				comboBox2.SelectedIndex = 0;
			}

			
		}
		
		public string getNameOFCat(string cat_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM CATEGORY where cat_id =" + cat_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["cat_name"].ToString();
				
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals("") && !textBox5.Text.Trim().Equals("") && !textBox6.Text.Trim().Equals("")) {
			
				try {
					pictureBox1.Image.Save(pictureBox1.Name); 
				} catch {
				}

				OleDbConnection con = DataBase.createConnection();

				String insertSQL = "insert into PRODUCT (cat_id,form_pro,size_pro,pro_name,minimum,maximum,pic) " +
				                   "values (" + (comboBox2.SelectedItem as dynamic).Value + ",'" + textBox3.Text + "','" +
				                   textBox2.Text + "','" + textBox1.Text + "'," + textBox5.Text + "," + textBox6.Text + ",'" + pictureBox1.Tag + "')";


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
			if (!string.IsNullOrEmpty(textBox4.Text) && !textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals("") && !textBox5.Text.Trim().Equals("") && !textBox6.Text.Trim().Equals("") && !pictureBox1.Tag.ToString().Trim().Equals("")) {
			
			
				
				if (pictureBox1.Tag.ToString().Equals(dataGridView2.SelectedRows[0].Cells[8].Value)) {
			
					
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update PRODUCT set cat_id=" + (comboBox2.SelectedItem as dynamic).Value + ",form_pro='" + textBox3.Text + "',pro_name='" + textBox1.Text + "',size_pro='" + textBox2.Text + "',minimum=" + textBox5.Text + ",maximum=" + textBox6.Text + " where pro_id=" + textBox4.Text;

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
				
					getAllRecords();
 				
					rest_data();
			
				} else {
			
					
										
					int index = Application.ExecutablePath.LastIndexOf('\\');
				
					string path = Application.ExecutablePath.Substring(0, index) + dataGridView2.SelectedRows[0].Cells[8].Value;
					
					try {
						File.Delete(path);
					} catch {
					}
								
					pictureBox1.Image.Save(pictureBox1.Name); 
			
								
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update PRODUCT set cat_id=" + (comboBox2.SelectedItem as dynamic).Value + ",form_pro='" + textBox3.Text + "',pro_name='" + textBox1.Text + "',size_pro='" + textBox2.Text + "',minimum=" + textBox5.Text + ",maximum=" + textBox6.Text + ",pic='" + pictureBox1.Tag + "' where pro_id=" + textBox4.Text;

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
				
					getAllRecords();
 				
					rest_data();
			
				}
			}
			
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

			String selectSQL = "SELECT * from  PURCHASE_WAREHOUSE_PRODUCTS where pro_id=" + id;

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
				
				try {
					int index = Application.ExecutablePath.LastIndexOf('\\');
				
					string path = Application.ExecutablePath.Substring(0, index) + dataGridView2.SelectedRows[0].Cells[8].Value;
			
					Image SSSS = Image.FromFile(path);
				
					if (pictureBox1.Image != null) {
						pictureBox1.Image.Dispose();
					}
				
					pictureBox1.Image = SSSS;
				
					pictureBox1.Tag = dataGridView2.SelectedRows[0].Cells[8].Value;
					
					pictureBox1.Name = path;
				} catch {
				}
				
				textBox4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
				textBox1.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
				textBox2.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
				textBox3.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
				textBox5.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
				textBox6.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
				
				for (int i = 0; i < comboBox2.Items.Count; i++) {
					string hh = (comboBox2.Items[i] as dynamic).Value;
					if (hh.Equals(dataGridView2.SelectedRows[0].Cells[1].Value.ToString())) {
						comboBox2.SelectedIndex = i;
						break;
					}
				
				}
			}
		}
		
	
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM PRODUCT where pro_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			var aBalBeginS = textBox5.Text;
			
			double abalbeginVal;
			
			bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
			
			if (parsed && abalbeginVal >= 0.0) {
				// We're good
			} else {
				textBox5.Text = "";
			}
		}
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			var aBalBeginS = textBox6.Text;
			
			double abalbeginVal;
			
			bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
			
			if (parsed && abalbeginVal >= 0.0) {
				// We're good
			} else {
				textBox6.Text = "";
			}
		}
		
		
		int row_pp = -1;
		
		int cell_pp = -1;
		
		bool row_ppp = true;
		
		
		void Button3Click(object sender, EventArgs e)
		{
			row_pp = -1;
			
			cell_pp = -1;
		
			row_ppp = true;
			
			button6.Enabled = true;
	
			new Thread(new ThreadStart(SearchValueRowIndex)).Start();
			
		}
		
		public void SearchValueRowIndex()
		{
			string searchValue = textBox7.Text.Trim();

			if (searchValue != "") {
				
				foreach (DataGridViewRow row in dataGridView2.Rows) {
					
					foreach (DataGridViewCell cell in row.Cells) {
						
						if (cell.ColumnIndex != 0 && cell.ColumnIndex != 1 && cell.ColumnIndex != 8) {
						
							if (cell.Value != null && cell.Value.ToString().Trim().Contains(searchValue)) {
							
								if (row_ppp) {
									row_pp = row.Cells[0].RowIndex;
								
									cell_pp = cell.ColumnIndex;
							
									row.Selected = true;
							
									return;
								}
							
								if (row_pp == row.Cells[0].RowIndex && cell_pp == cell.ColumnIndex) {
								
									row_ppp = true;
								
								}
							}
						}
					}
				}
				
				MessageBox.Show("لم يعد هنالك نتائج");
					
				row_pp = -1;
			
				cell_pp = -1;
		
				row_ppp = true;
					
				button6.BeginInvoke((Action)delegate() {
					button6.Enabled = false;
				});
					
				
			}

			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			Stream myStream;
			
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\";
			
			//openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			
			openFileDialog1.Filter = "صور (*.jpg)|*.jpg";
			
			openFileDialog1.FilterIndex = 2;
			
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				
				if ((myStream = openFileDialog1.OpenFile()) != null) {
					
					int index = Application.ExecutablePath.LastIndexOf('\\');

					string newfile = "\\images\\big_" + new Random().Next(1000000) + ".jpg";

					string path = Application.ExecutablePath.Substring(0, index) + newfile;

					Image SSS = Image.FromStream(myStream);
								
					if (pictureBox1.Image != null) {
						pictureBox1.Image.Dispose();
					}
								
					pictureBox1.Image = SSS;
			
					pictureBox1.Tag = newfile;
					
					pictureBox1.Name = path;
						
				}
			}
		}
		
		
		void Button6Click(object sender, EventArgs e)
		{
			row_ppp = false;
			
			new Thread(new ThreadStart(SearchValueRowIndex)).Start();
		}

	}
}