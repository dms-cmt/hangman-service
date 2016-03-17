using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Hangman
{
	public class DataBase : IDisposable
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
				string connectionString = ConfigurationManager.AppSettings["connectionString"];
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
		 * 	br - broj rekorda, ili null za sve
		 */
		public List<Rekord> PreuzmiRekorde(int? br)
		{
			List <Rekord> rekordi = new List<Rekord> ();
			MySqlCommand cmd = null;
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
			} finally
			{
				if(cmd != null)
					cmd.Dispose ();
			}
		}

		/*
		 * Peuzima film iz baze
		 * 	rb - redni broj pitanja
		 */
		public Film PreuzmiFilm(int rb)
		{
			Film film = null;
			MySqlCommand cmd = null;
			DataSet ds = new DataSet ();
			DataRow[] rows;
			string query = "SELECT * FROM nazivi";

			try
			{
				cmd = new MySqlCommand (query, conn);
				dataAdapter.SelectCommand = cmd;
				dataAdapter.Fill (ds, "nazivi");
				rows = ds.Tables["nazivi"].Select ();
				if(ds.Tables["nazivi"].Rows.Count < rb + 1)
					throw new IndexOutOfRangeException();
				film = new Film(int.Parse(rows[rb]["id"].ToString()),
								rows[rb]["naziv"].ToString());
			} catch (Exception ex)
			{
				throw ex;
			} finally
			{
				if(cmd != null)
					cmd.Dispose ();
			}

			return film;
		}

		/*
		 * Vraca broj filmova
		 */
		public int BrojFilmova()
		{
			string query = "SELECT COUNT(*) FROM nazivi";
			MySqlCommand cmd = null;
			int count = 0;

			try
			{
				cmd = new MySqlCommand (query, conn);
				count = (int)cmd.ExecuteScalar ();
			} catch (Exception ex)
			{
				throw ex;
			} finally
			{
				if(cmd != null)
					cmd.Dispose ();
			}

			return count;
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
				if(dataAdapter != null)
					dataAdapter.Dispose ();
				if(conn != null)
					conn.Dispose ();
			}
		}
	}
}

