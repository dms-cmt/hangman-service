using System;
using MySql.Data.MySqlClient;

namespace Hangman
{
	public class Data
	{
		private static readonly string connectionString = "" +
			"Server=localhost;" +
			"Database=hangman;" +
			"User ID=cmt;" +
			"Password=cmt2#" +
			"Pooling=false";

		public Data ()
		{
		}
	}
}

