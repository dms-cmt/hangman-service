using System;
using System.Runtime.Serialization;

namespace Hangman
{
	/**
	 * Rekord \n
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
		 * Polje Id \n
		 * 	nalazi se u bazi podataka \n
		 * 	omoguceno je samo citanje
		 */
		[DataMember]
		public int? Id
		{
			get { return id; }
			private set { id = value; }
		}

		/**
		 * Polje BrojPogresnihSlova \n
		 * 	broj slova koja je korisnik pogresio \n
		 * 	prilikom resavanja "problema"
		 */
		[DataMember]
		public int BrojPogresnihSlova
		{
			get { return brojPogresnihSlova; }
			set { brojPogresnihSlova = value; }
		}

		/**
		 * Polje BrojSekundi \n
		 * 	broj sekundi za koje je igrac resio "problem" \n
		 * 	omoguceno je citanje i pisanje
		 */
		[DataMember]
		public long BrojSekundi
		{
			get { return brojSekundi; }
			set { brojSekundi = value; }
		}

		/**
		 * Polje ImeKorisnika \n
		 * 	ime korisnika koji je dostigao rekord \n
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
		 * Prima tri argumenta \n
		 * 	id - iz baze ili null \n
		 *	brojPogresnihSlova - broj slova koje je korisnik pograsio \n
		 * 	brojSekundi - broj sekundi za koje je korisnika resio "problem" \n
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

