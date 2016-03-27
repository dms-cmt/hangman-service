﻿using System;
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
		 * 	sve setuje na nulu i pokrece tajmer
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int PokreniIgru ();

		/**
		 * Metoda koja proverava da li se
		 * 	zadato slovo nalazi u imenu filma
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int[] Provera (char slovo);

		/*
		 * Rekordi
		 */

		/**
		 * Metoda vraca listu Rekordas \n
		 * prima jedan argument koji predstavlja broj \n
		 * rekorda koje treba preuzeti, ako je null \n
		 * vraca sve rekorde
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		List<Rekord> PreuzmiRekorde (int? br = null);

		/**
		 * Metoda dodaje rekord u bazu \n
		 * 	ime - ime korisnika koji je resavao sudoku
		 */
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		void SnimiRekord(String ime);
	}
}

