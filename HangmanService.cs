using System;
using System.Collections.Generic;
using System.Timers;
using System.ServiceModel;

using Hangman;

namespace HangmanService
{
	[ServiceBehavior (InstanceContextMode = InstanceContextMode.PerSession)]
	public class HangmanService : IHangmanService
	{
		/*
		 * Konstante
		 */

		//public static readonly int MAX_ZIVOT		= 6;	// Maksimalan broj zvota

		/*
		 * Globalne promenjive
		 */

		private int brojPokusaja;
		private char[] nazivFilma;
		private DateTime vremeStart;
		private int brojSlova;

		/*
		 * Konstruktori
		 */

		public HangmanService ()
		{
		}

		/*
		 * Igra
		 */

		/**
		* Metoda koja pokrece igru \n
		* 	sve setuje na nulu i snima trenutno
		*	vreme
		*	na serveru
		*/
		public int PokreniIgru ()
		{
			brojPokusaja = 0;
			vremeStart = DateTime.Now;
			brojSlova = 0;

			using (DataBase data = new DataBase ())
			{
				int brojFilmova;
				int rbFilma;
				Film film;
				Random random = new Random ();
				try
				{
					data.Open ();
					brojFilmova = data.BrojFilmova ();
					rbFilma = random.Next (brojFilmova);
					film = data.PreuzmiFilm (rbFilma);
					nazivFilma = film.Naziv.ToUpper ().ToCharArray ();
				} catch (Exception ex)
				{
					return -1;
				}
			}

			return nazivFilma.Length;
		}

		/**
		 * Metoda koja proverava da li se
		 * 	zadato slovo nalazi u imenu filma \n
		 * 	vraca listu indexa na kojima se nalazi slovo,
		 * 	a ako slova nema, praznu listu
		 */
		public List<int> Provera (char[] slovo)
		{
			List<int> result = new List<int> ();
			int index;

			if (brojPokusaja >= 6)
				return result;

			for (index = 0; index < nazivFilma.Length; index++)
				if (nazivFilma [index] == slovo[0])
					result.Add (index);

			if (result.Count <= 0)
				brojPokusaja++;

			return result;
		}

		/**
		 * Metoda koja vraca broj preostalih zivota
		 */
		public int BrojPokusaja ()
		{
			return brojPokusaja;
		}

		/*
		 * Rekordi
		 */

		/**
		 * Metoda vraca listu Rekorda \n
		 * 	id - broj rekorda za preuzimanje,
		 *		ako je null vraca sve rekorde,
		 *		default vrednost je null
		 */
		public List<Rekord> PreuzmiRekorde (int? br = null)
		{
			List<Rekord> rekordi;
			using (DataBase data = new DataBase ())
			{
				data.Open ();
				rekordi = data.PreuzmiRekorde (br);
			}

			return rekordi;
		}

		/**
		 * Metoda dodaje rekord u bazu \n
		 * 	ime - ime korisnika koji je resavao sudoku
		 */
		public void SnimiRekord (String ime)
		{
			TimeSpan ukupnoVreme;
			DateTime vremeEnd = DateTime.Now;
			ukupnoVreme = DateTime.Now - vremeStart;
			int vreme = ukupnoVreme.Seconds +			// Pretvara vreme u sekunde
				ukupnoVreme.Minutes * 60 +
				ukupnoVreme.Hours * 3600;
			using (DataBase data = new DataBase ())
			{
				data.Open ();
				data.NoviRekord (ime, brojSlova, vreme);
			}
		}
	}
}

