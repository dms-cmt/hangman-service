using System;
using System.ServiceModel;
using System.Collections.Generic;
using Hangman;

namespace HangmanService
{
	[ServiceContract]
	public interface IHangmanService
	{
		/*
		 * Igra
		 */

		/*
		 * Rekordi
		 */

		/**
		 * Metoda vraca listu Rekordas <br\>
		 * prima jedan argument koji predstavlja broj <br\>
		 * rekorda koje treba preuzeti, ako je null <br\>
		 * vraca sve rekorde
		 */
		[OperationContract]
		List<Rekord> preuzmiRekorde(int? br);
	}
}

