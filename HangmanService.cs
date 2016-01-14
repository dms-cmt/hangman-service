using System;
using System.Collections.Generic;
using Hangman;

namespace HangmanService
{
	public class HangmanService : IHangmanService
	{

		public HangmanService ()
		{
		}

		/*
		 * Igra
		 */

		/*
		 * Rekordi
		 */

		/**
		* Metoda vraca listu Rekordas \n
		* 	id - broj rekorda za preuzimanje,
		*		ako je null vraca sve rekorde
		*/
		public List<Rekord> PreuzmiRekorde(int? br)
		{
			List<Rekord> rekordi;
			using (Data data = new Data ())
			{
				data.Open ();
				rekordi = data.PreuzmiRekorde (br);
			}

			return rekordi;
		}
	}
}

