using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Hangman
{
	public class Data : IDisposable
	{
		/*
		 * Global variables
		 */

		/*
		private static readonly string connectionString = "" +
			"Server=localhost;" +
			"Database=hangman;" +
			"User ID=cmt;" +
			"Password=cmt2#;" +
			"Pooling=false;";
		*/

		private MySqlConnection conn = null;
		private MySqlCommand cmd = null;
		private MySqlDataAdapter dataAdapter = null;

		/*
		 * Pulib methods
		 */

		/*
		 * Otvara konekciju na bazu podataka
		 */
		public void Open ()
		{
			try
			{
				string connectionString = ConfigurationSettings.AppSettings["connectionString"];
				conn = new MySqlConnection (connectionString);
				conn.Open ();
				dataAdapter = new MySqlDataAdapter ();
			} catch (Exception ex)
			{
				throw ex;
			}
		}

		/*
		 * Preuzima rekorde iz baze
		 * 	id - broj rekorda, ili null za sve
		 */
		public List<Rekord> PreuzmiRekorde(int? br)
		{
			List <Rekord> rekordi = new List<Rekord> ();
			DataSet ds = new DataSet ();
			DataRow[] rows;
			string query = "SELECT * FROM rekordi ORDER BY broj_pogresnih_slova+broj_sekundi ASC";

			try
			{
				cmd = new MySqlCommand (query, conn);
				dataAdapter.SelectCommand = cmd;
				dataAdapter.Fill (ds, "rekordi");
				rows = ds.Tables["rekordi"].Select ();

				if (br == null || br > ds.Tables["rekordi"].Rows.Count)
					br = rows.Length;

				for(int i = 0; i < br; i++)
					rekordi.Add(new Rekord(
						int.Parse(rows[i]["id"].ToString ()),
						int.Parse(rows[i]["broj_pogresnih_slova"].ToString ()),
						int.Parse(rows[i]["broj_sekundi"].ToString ()),
						rows[i]["ime_korisnika"].ToString ()));
				
				return rekordi;
			} catch (Exception ex)
			{
				throw ex;
			}
		}

		/*
		 * Dispose
		 */
		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		/*
		 * Oslobadja memoriju
		 */

		protected virtual void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (dataAdapter != null)
					dataAdapter.Dispose ();
				if (cmd != null)
					cmd.Dispose ();
				if (conn != null)
					conn.Dispose ();
			}
		}
	}
}

