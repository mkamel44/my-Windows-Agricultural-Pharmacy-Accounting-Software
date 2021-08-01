using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace بذرة_أمل
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			new Form2().ShowDialog();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			new Form4().ShowDialog();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			var ss = new Form3();
			
			if (ss.kk) {
				ss.ShowDialog();
			}
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			new Form5().ShowDialog();
		}
	
		void Button9Click(object sender, EventArgs e)
		{
			var ss = new Form6();
			
			if (ss.kk) {
				ss.ShowDialog();
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			var ss = new Form9();
			
			if (ss.kk) {
				ss.ShowDialog();
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			new Form12().ShowDialog();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			this.Hide();
			
			var form2 = new Form11();
			
			form2.Closed += (s, args) => this.Close(); 
			
			form2.Show();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			var ss = new Form14();
			
			if (ss.kk) {
				ss.ShowDialog();
			}
			
			if (!ss.jj.Equals("")) {
				this.Hide();
			
				var form2 = new Form11();
			
				form2.textBox1.Text = ss.jj;
			
				form2.Button13Click(null, null);
						
				form2.Closed += (s, args) => this.Close();
		
				form2.Show();
			}
		}
	}
}