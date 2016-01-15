using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using Hangman;

namespace HangmanService
{
	class MainClass
	{
		public static int Main (string[] args)
		{
			using (ServiceHost host = new ServiceHost (typeof (HangmanService)))
			{
				host.Open ();

				Console.WriteLine ("Type [CR] to stop ...");
				Console.ReadKey ();
				host.Close ();
			}
			return 0;
		}
	}
}
