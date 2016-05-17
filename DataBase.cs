using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

using HangmanService;

namespace Hangman
{
	public class DataBase : IDisposable
	{
		/*
		 * Global variables
		 */

		/*
		private stati8c readonly string connectionString = "" +
			"Server=localhost;" +
			"Database=hangman;" +
			"User ID=cmt;" +
			"Password=cmt2#;" +
			"Pooling=false;";
		*/

		private MySqlConnection conn = null;

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
			} catch (Exception ex)
			{
				throw ex;
			}
		}

		/*
		 * Preuzima rekorde iz baze
		 * 	br - broj rekorda, ili null za sve
		 * 	d
		 */
		public List<Rekord> PreuzmiRekorde(int? br, ETipSortiranja tipSortiranja)
		{
			List <Rekord> rekordi = new List<Rekord> ();
			MySqlCommand cmd;
			MySqlDataReader reader;
			string query;

			switch (tipSortiranja)
			{
			case ETipSortiranja.NajboljiPoBrojuSlova:
				query = "SELECT * FROM rekordi ORDER BY broj_pogresnih_slova ASC";
				break;
			case ETipSortiranja.NajboljiPoVremenu:
				query = "SELECT * FROM rekordi ORDER BY broj_sekundi ASC";
				break;
			default:
				query = "SELECT * FROM rekordi ORDER BY broj_pogresnih_slova+broj_sekundi ASC";
				break;
			}

			using (cmd = new MySqlCommand (query, conn))
			{
				try
				{
					reader = cmd.ExecuteReader ();

					while (reader.Read () && (br != null ? br-- > 0 : true))
					{
						int id = reader.GetInt32 (0);
						int brojPogresnihSlova = reader.GetInt32 (1);
						long vreme = reader.GetInt64 (2);
						string ime = reader.GetString (3);
						rekordi.Add (new Rekord(id, brojPogresnihSlova,
												vreme, ime));
					}
				} catch (Exception ex)
				{
						throw ex;
				}
			}

			return rekordi;
		}

		/*
		 * Peuzima film iz baze
		 * 	rb - redni broj pitanja
		 */
		public Film PreuzmiFilm(int rb)
		{
			Film film;
			MySqlCommand cmd;
			MySqlDataAdapter dataAdapter;
			DataSet ds = new DataSet ();
			DataRow[] rows;
			string query = "SELECT * FROM nazivi";

			using (cmd = new MySqlCommand (query, conn))
			{
				using(dataAdapter = new MySqlDataAdapter ())
				{
					try
					{
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
					}
				}
			}

			return film;
		}

		/*
		 * Vraca broj filmova
		 */
		public int BrojFilmova()
		{
			string query = "SELECT COUNT(*) FROM nazivi";
			MySqlCommand cmd;
			int count;

			using (cmd = new MySqlCommand (query, conn))
			{
				try
				{
					count = Int32.Parse(cmd.ExecuteScalar ().ToString ());
				} catch (Exception ex)
				{
					throw ex;
				}
			}

			return count;
		}

		/*
		 * Snima podatke o takmicaru u bazu podataka
		 */
		public void NoviRekord (String ime, int brojSlova, long vreme)
		{
			string query = "INSERT INTO rekordi (ime_korisnika, broj_pogresnih_slova, broj_sekundi)" +
				"VALUES (@ime, @brojSlova, @vreme)";
			using (MySqlCommand cmd = new MySqlCommand (query, conn))
			{
				try
				{
					cmd.Parameters.Add ("@ime", MySqlDbType.VarChar).Value = ime;
					cmd.Parameters.Add ("@brojSlova", MySqlDbType.Int32).Value = brojSlova;
					cmd.Parameters.Add ("@vreme", MySqlDbType.Int64).Value = vreme;
					cmd.ExecuteNonQuery ();
				} catch (MySqlException ex)
				{
					throw ex;
				}
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
				if(conn != null)
					conn.Dispose ();
			}
		}
	}
}

