using System;
using System.Collections.Generic;
using System.Timers;
using Hangman;

namespace HangmanService
{
	public class HangmanService : IHangmanService
	{
		/*
		 * Konstante
		 */

		public static readonly int MAX_HELTH		= 6;	// Maksimalan broj zvota

		/*
		 * Globalne promenjive
		 */

		private int helth;
		private int time;
		private Timer timer;
		private Film film = null;

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
			helth = MAX_HELTH;
			time = 0;

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

			//timer.Elapsed += ElapsedEventHandler (TimerTick);
			timer.Interval = 1000;
			//timer.Enabled = true;

			return film.Naziv.Length;
		}

		/*
		 * Privatni TimerTick handler
		 * koristi se za brojanje sekundi
		 */
		private void TimerTick (object source, ElapsedEventArgs e)
		{
			time++;
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
		}
	}
}

