/*
* Project name:
* 	Hangman
* Description:
* 	Projekat za CMT (Schnider Electric DMS)
* 
* File:
* 	Naziv.cs
* 
* Author: Milos Zivlak (zivlakmilos@gmail.com, zi@zivlakmilos.ddns.net)
* Date: 2015-01-09
* 
* Changes (format: "name", "date", "reasone"):
* 
* ToDo (fromat: "task", "[date]", "[name]"):
* 
* Notes (format: "name", "date", "note"):
*/

using System;

namespace Hangman
{
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

		/*
		 * Polje Id
		 * 	nalazi se u bazi podataka
		 * 	omoguceno je samo citanje
		 */
		public int? Id
		{
			get { return id; }
		}

		/*
		 * Polje Title
		 * 	sadrzi naziv filma
		 * 	omoguceno je citanje i pisanje
		 */
		public String Title
		{
			get { return title; }
			set { title = value; }
		}

		/*
		 * Konstruktori
		 */

		/*
		 * Prima dva ardumenta
		 * 	id - id naziva iz baze ili NULL
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

