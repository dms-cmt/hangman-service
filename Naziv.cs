using System;
using System.Runtime.Serialization;

namespace Hangman
{
	/**
	 * Naziv <br\>
	 * 	Klasa predstavlja jedan red iz tabele naziv
	 */
	[DataContract]
	public class Naziv
	{
		/*
		 * Globalne promenjive
		 */

		private int? id;
		private String title;

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
		 * Polje Title <br\>
		 * 	sadrzi naziv filma <br\>
		 * 	omoguceno je citanje i pisanje
		 */
		[DataMember]
		public String Title
		{
			get { return title; }
			set { title = value; }
		}

		/*
		 * Konstruktori
		 */

		/**
		 * Prima dva ardumenta <br\>
		 * 	id - id naziva iz baze ili NULL <br\>
		 * 	title - naziv filma
		 */
		public Naziv (int? id, String title)
		{
			Id = id;
			Title = title;
		}

		/*
		 * Javne metode
		 */

		/*
		 * Privatne metode
		 */
	}
}

