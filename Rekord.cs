using System;
using System.Runtime.Serialization;

namespace Hangman
{
	/**
	 * Rekord <br\>
	 * 	Klasa predstavlja jedan red iz tabele rekordi
	 */
	[DataContract]
	public class Rekord
	{
		/*
		 * Globalne promenjive
		 */

		private int? id;
		private int brojPogresnihSlova;
		private long brojSekundi;
		private String imeKorisnika;

		/*
		 * Polja
		 */

		/**
		 * Polje Id <br\>
		 * 	nalazi se u bazi podataka <br\>
		 * 	omoguceno je samo citanje
		 */
		[DataMember]
		public int? Id
		{
			get { return id; }
			private set { id = value; }
		}

		/**
		 * Polje BrojPogresnihSlova <br\>
		 * 	broj slova koja je korisnik pogresio <br\>
		 * 	prilikom resavanja "problema"
		 */
		[DataMember]
		public int BrojPogresnihSlova
		{
			get { return brojPogresnihSlova; }
			set { brojPogresnihSlova = value; }
		}

		/**
		 * Polje BrojSekundi <br\>
		 * 	broj sekundi za koje je igrac resio "problem" <br\>
		 * 	omoguceno je citanje i pisanje
		 */
		[DataMember]
		public long BrojSekundi
		{
			get { return brojSekundi; }
			set { brojSekundi = value; }
		}

		/**
		 * Polje ImeKorisnika <br\>
		 * 	ime korisnika koji je dostigao rekord <br\>
		 * 	moguce je citanje i pisanje
		 */
		[DataMember]
		public String ImeKorisnika
		{
			get { return imeKorisnika; }
			set { imeKorisnika = value; }
		}

		/*
		 * Konstruktori
		 */

		/**
		 * Prima tri argumenta <br\>
		 * 	id - iz baze ili null <br\>
		 *	brojPogresnihSlova - broj slova koje je korisnik pograsio <br\>
		 * 	brojSekundi - broj sekundi za koje je korisnika resio "problem" <br\>
		 * 	imeKorisnika - ime korisnika koji je dostigao rekors
		 */
		public Rekord (int? id, int brojPogresnihSlova, long brojSekundi, String imeKorisnika)
		{
			Id = id;
			BrojPogresnihSlova = brojPogresnihSlova;
			BrojSekundi = brojSekundi;
			ImeKorisnika = imeKorisnika;
		}

		/*
		 * Javne metode
		 */

		/*
		 * Privatne metode
		 */
	}
}

