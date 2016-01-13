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
		* Metoda vraca listu Rekordas <br\>
		* 	id - broj rekorda za preuzimanje,
		*		ako je null vraca sve rekorde
		*/
		public List<Rekord> preuzmiRekorde(int? br)
		{
			return Data.preuzmiRekorde (br);
		}
	}
}

