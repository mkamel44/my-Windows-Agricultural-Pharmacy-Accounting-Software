/*
 * Created by SharpDevelop.
 * User: 1
 * Date: 21/03/2020
 * Time: 10:42 ص
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace بذرة_أمل
{
	/// <summary>
	/// Description of UserControl1.
	/// </summary>
	public sealed class XButton : Button
	{
		public string cat_id = "";
		
		public string pro_name = "";
		
		public string pro_id = "";
		
		public string form_pro = "";
		
		public string size_pro = "";
		
		public string minimum = "";
		
		public string maximum = "";
		
		public string pic = "";
		
		public string cat_name = "";
	
		
		public XButton(int bWidth, int bHeight)
		{
			this.RightToLeft = RightToLeft.Yes;
			this.Size = new Size(bWidth, bHeight);
			UseVisualStyleBackColor = false;
			TextImageRelation = TextImageRelation.ImageAboveText;
		}
		
		public override string Text {
			get { return ""; }
			set { base.Text = value; }
		}
		public string LeftText { get; set; }
		public string RightText { get; set; }
		protected override void OnPaint(PaintEventArgs pevent)
		{            
			base.OnPaint(pevent);
			Rectangle rect = ClientRectangle;
			rect.Inflate(-5, -5);
			using (StringFormat sf = new StringFormat() {
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Far
			}) {
				using (Brush brush = new SolidBrush(ForeColor)) 
				{
					pevent.Graphics.DrawString(LeftText, Font, brush, rect, sf);
					sf.Alignment = StringAlignment.Far;
					pevent.Graphics.DrawString(RightText, Font, brush, rect, sf);
				}
			}
		}
	}
	
	//xButton1.Image = yourImage;
	//xButton1.LeftText = "How interesting winforms is";
	//xButton2.RightText = "F12";
}
