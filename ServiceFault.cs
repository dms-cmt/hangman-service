using System;
using System.Runtime.Serialization;

namespace Hangman
{
	/**
	 * ServiceFault \n
	 * 	Predstavlja klasu koja se salje kao
	 * 	fault exception klijentu
	 */
	[DataContract]
	public class ServiceFault
	{
		/*
		 * Globalne promenjive
		 */

		private string errorMessage;
		private string errorDetail;

		/*
		 * Polja
		 */

		/**
		 * Poruka o gresci
		 */
		public string ErrorMessage
		{
			get { return errorMessage; }
			private set { errorMessage = value; }
		}

		/**
		 * Detalji o gresci
		 */
		public string ErrorDetail
		{
			get { return errorDetail; }
			private set { errorDetail = value; }
		}

		/*
		 * Konstruktori
		 */
		
		/**
		 * Dafault konstruktor\n
		 * 	bez argumenata, samo kreira objekat
		 */
		public ServiceFault ()
		{
		}

		/**
		 * Prima dva argumenta:\n
		 * 	errorMeesage - poruka o gresci\n
		 *  errorDetail - detalji o gresci
		 */
		public ServiceFault (string errorMessage, string errorDetail = "")
		{
			ErrorMessage = errorMessage;
			ErrorDetail = errorDetail;
		}
	}
}

