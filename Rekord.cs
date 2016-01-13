/*
* Project name:
* 	Hangman
* Description:
* 	Projekat za CMT (Schnider Electric DMS)
* 
* File:
* 	Rekord.cs
* 
* Author: Milos Zivlak (zivlakmilos@gmail.com, zi@zivlakmilos.ddns.net)
* Date: 2016-01-09
* 
* Changes (format: "name", "date", "reasone"):
* 	Milos Zivlak, 2016-01-13, "Dodat privatni seter za Id"
* 
* ToDo (fromat: "task", "[date]", "[name]"):
* 
* Notes (format: "name", "date", "note"):
*/

using System;

namespace Hangman
{
	/**
	 * Rekord
	 * 	Klasa predstavlja jedan red iz tabele rekordi
	 */
	public class Rekord
	{
		/*
		 * Globalne promenjive
		 */

		private int? id;
		private long brojSekundi;
		private String imeKorisnika;

		/*
		 * Polja
		 */

		/**
		 * Polje Id
		 * 	nalazi se u bazi podataka
		 * 	omoguceno je samo citanje
		 */
		public int? Id
		{
			get { return id; }
			private set { id = value; }
		}

		/**
		 * Polje BrojSekundi
		 * 	broj sekundi za koje je igrac resio "problem"
		 * 	omoguceno je citanje i pisanje
		 */
		public long BrojSekundi
		{
			get { return brojSekundi; }
			set { brojSekundi = value; }
		}

		/**
		 * Polje ImeKorisnika
		 * 	ime korisnika koji je dostigao rekord
		 * 	moguce je citanje i pisanje
		 */
		public String ImeKorisnika
		{
			get { return imeKorisnika; }
			set { imeKorisnika = value; }
		}

		/*
		 * Konstruktori
		 */

		/**
		 * Prima dva argumenta
		 * 	id - iz baze ili null
		 * 	brojSekundi - broj sekundi za koje je korisnika resio "problem"
		 * 	imeKorisnika - ime korisnika koji je dostigao rekors
		 */
		public Rekord (int? id, long brojSekundi, String imeKorisnika)
		{
			Id = id;
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

