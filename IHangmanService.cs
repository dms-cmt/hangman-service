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
		List<Rekord> PreuzmiRekorde(int? br);
	}
}
