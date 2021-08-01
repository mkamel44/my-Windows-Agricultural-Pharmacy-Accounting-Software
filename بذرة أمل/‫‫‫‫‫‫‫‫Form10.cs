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
	public partial class Form10 : Form
	{
		public bool kk = true;
		
		public Form10()
		{
			InitializeComponent();

		
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

		}
		
		
	}
}