using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hangman
{
	public static class Data
	{
		/*
		 * Global variables
		 */

		private static readonly string connectionString = "" +
			"Server=localhost;" +
			"Database=hangman;" +
			"User ID=cmt;" +
			"Password=cmt2#;" +
			"Pooling=false;";

		//private static MySqlConnection conn = null;
		//private static MySqlCommand cmd = null;
		//private static MySqlDataAdapter dataAdapter = null;

		/*
		 * Pulib methods
		 */

		/*
		 * Preuzima rekorde iz baze
		 * 	id - broj rekorda, ili null za sve
		 */
		public static List<Rekord> preuzmiRekorde(int? br)
		{
			List<Rekord> rekordi = new List<Rekord> ();
			MySqlConnection conn = null;
			MySqlCommand cmd = null;
			MySqlDataAdapter adapter = new MySqlDataAdapter();
			DataSet ds = new DataSet();
			DataRow[] rows;
			int i;
			int max;

			try
			{
				conn = new MySqlConnection (connectionString);
				conn.Open ();
				string query = "SELECT * FROM rekordi ORDER BY broj_sekundi ASC;";
				cmd = new MySqlCommand (query, conn);
				adapter.SelectCommand = cmd;
				adapter.Fill (ds, "rekordi");
				rows = ds.Tables["rekordi"].Select();

				if (br == null || br > ds.Tables["rekordi"].Rows.Count)
					max = ds.Tables["rekordi"].Rows.Count;
				else
					max = (int) br;

				for(i = 0; i < max; i++)
				{
					rekordi.Add(new Rekord(
						int.Parse(rows[i]["id"].ToString()),
						int.Parse(rows[i]["broj_pogresnih_slova"].ToString()),
						long.Parse(rows[i]["broj_sekundi"].ToString()),
						rows[i]["ime_korisnika"].ToString()));
				}
			} catch (MySqlException ex)
			{
				Console.WriteLine (ex);
			} finally
			{
				//ds.Dispose ();
				adapter.Dispose ();
				cmd.Dispose ();
				conn.Close ();
				//conn.Dispose ();
			}

			return rekordi;
		}
	}
}

