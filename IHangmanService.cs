using System;
using System.ServiceModel;
using System.Runtime.Serialization;
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

		/**
		 * Metoda koja pokrece igru \n
		 * 	sve setuje na nulu i snima trenutno
		 *	vreme
		 *	na serveru
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int[] PokreniIgru ();

		/**
		 * Metoda koja proverava da li se
		 * 	zadato slovo nalazi u imenu filma \n
		 * 	vraca listu indexa na kojima se nalazi slovo,
		 * 	a ako slova nema, praznu listu
		 */
		[OperationContract]
		List<int> Provera (char[] slovo);

		/**
		 * Metoda koja vraca broj preostalih zivota
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int BrojPokusaja ();

		/**
		 * Metoda koja vraca status igre\n
		 * 	- enumeraciju EStatusIgre
		 */
		[OperationContract]
		EStatusIgre Status ();

		/**
		 * Metoda koja vraca trenutno vreme igra
		 */
		[OperationContract]
		long Vreme ();

		/**
		 * Metoda koja vraca zadatu rec (film) kao listu karaktera
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		char[] Resenje ();

		/*
		 * Rekordi
		 */

		/**
		 * Metoda vraca listu Rekordas \n
		 * prima dva argumenta \n
		 * br (int) - koji predstavlja broj
		 * rekorda koje treba preuzeti, ako je null (default)
		 * vraca sve rekorde \n
		 * tipSortiranja (ETipSortiranja) - enumeracija
		 * predstavlja tip sortiranja (default - NajboljiUkupno)
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		List<Rekord> PreuzmiRekorde (int? br = null,
			ETipSortiranja tipSortiranja = ETipSortiranja.NajboljiUkupno);

		/**
		 * Metoda dodaje rekord u bazu \n
		 * 	ime - ime korisnika koji je resavao sudoku
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		void SnimiRekord(String ime);
	}
}

