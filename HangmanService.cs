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

		private Film film;
		private int brojPokusaja;
		private char[] nazivFilma;
		private DateTime vremeStart;
		private int brojSlova;
		EStatusIgre status;

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
		public int[] PokreniIgru ()
		{
			brojPokusaja = 0;
			vremeStart = DateTime.Now;
			brojSlova = 0;
			status = EStatusIgre.IGRA_AKTIVNA;
			List<int> result = new List<int> ();

			using (DataBase data = new DataBase ())
			{
				int brojFilmova;
				int rbFilma;
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
				}
			}

			result.Add (nazivFilma.Length);
			for (int i = 0; i < nazivFilma.Length; i++)
				if (nazivFilma [i] == ' ')
				{
					result.Add (i);
					nazivFilma [i] = '\0';
				}

			return result.ToArray ();
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
			int i;

			if (status != EStatusIgre.IGRA_AKTIVNA || slovo[0] == '\0')
				return result;

			for (index = 0; index < nazivFilma.Length; index++)
				if (nazivFilma [index] == slovo [0])
				{
					result.Add (index);
					nazivFilma [index] = '\0';
				}

			if (result.Count <= 0)
				if (++brojPokusaja >= 6)
					status = EStatusIgre.IGRA_ZAVRSENA_PORAZ;

			for (i = 0; i < nazivFilma.Length; i++)
				if (nazivFilma [i] != '\0')
					break;
			if (i == nazivFilma.Length)
				status = EStatusIgre.IGRA_ZAVRSENA_POBEDA;

			return result;
		}

		/**
		 * Metoda koja vraca broj preostalih zivota
		 */
		public int BrojPokusaja ()
		{
			return brojPokusaja;
		}

		/**
		 * Metoda koja vraca status igre\n
		 * 	- enumeraciju EStatusIgre
		 */
		[OperationContract]
		public EStatusIgre Status ()
		{
			return status;
		}

		/**
		 * Metoda koja vraca trenutno vreme igra
		 */
		[OperationContract]
		public long Vreme ()
		{
			TimeSpan ukupnoVreme;
			DateTime vremeEnd = DateTime.Now;
			ukupnoVreme = DateTime.Now - vremeStart;
			long vreme = ukupnoVreme.Seconds +			// Pretvara vreme u sekunde
				ukupnoVreme.Minutes * 60 +
				ukupnoVreme.Hours * 3600;
			return vreme;
		}

		/**
		 * Metoda koja vraca zadatu rec (film) kao listu karaktera
		 */
		[OperationContract]
		public char[] Resenje ()
		{
			char[] result;

			if (status == EStatusIgre.IGRA_AKTIVNA)
				status = EStatusIgre.IGRA_ZAVRSENA_PORAZ;
			result = film.Naziv.ToUpper ().ToCharArray ();

			return result;
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
			long vreme = Vreme ();
			using (DataBase data = new DataBase ())
			{
				data.Open ();
				data.NoviRekord (ime, brojSlova, vreme);
			}
		}
	}
}

