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

		public static readonly int MAX_ZIVOT		= 6;	// Maksimalan broj zvota

		/*
		 * Globalne promenjive
		 */

		private int zivot;
		private Film film = null;
		DateTime vremeStart;
		int brojSlova;

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
		 * 	sve setuje na nulu i pokrece tajmer
		 */
		public int PokreniIgru ()
		{
			zivot = MAX_ZIVOT;
			vremeStart = DateTime.Now;
			brojSlova = 0;

			using (DataBase data = new DataBase ())
			{
				int brojFilmova;
				int rbFilma;
				Random random = new Random ();

				data.Open ();

				brojFilmova = data.BrojFilmova();
				rbFilma = random.Next (brojFilmova);
				try
				{
					film = data.PreuzmiFilm (rbFilma);
				} catch (Exception ex)
				{
					return -1;
				}
			}

			return film.Naziv.Length;
		}

		/**
		 * Metoda koja proverava da li se
		 * 	zadato slovo nalazi u imenu filma
		 */
		public int[] Provera (char slovo)
		{
			return null;
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

