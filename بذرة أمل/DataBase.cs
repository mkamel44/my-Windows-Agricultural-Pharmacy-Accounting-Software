/*
 * Created by SharpDevelop.
 * User: mkamel
 * Date: 03/09/2019
 * Time: 06:18 ص
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace بذرة_أمل
{
	/// <summary>
	/// Description of DataBase.
	/// </summary>
	public class DataBase
	{
		public static OleDbConnection createConnection()
		{

			int index = Application.ExecutablePath.LastIndexOf('\\');

			string path = Application.ExecutablePath.Substring(0, index) + "\\" + "ALAMAL.mdb";

			OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Jet OLEDB:Database Password=lolo");

			aConnection.Open();

			return aConnection;

		}
	}
}
