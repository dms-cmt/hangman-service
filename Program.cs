using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Mono.Unix;
using Mono.Unix.Native;
using Hangman;

namespace HangmanService
{
	class MainClass
	{
		public static int Main (string[] args)
		{
			using (ServiceHost host = new ServiceHost (typeof (HangmanService)))
			{
				var security = new SecurityMode ();
				host.AddServiceEndpoint (
					typeof(IHangmanService),
					new WSHttpBinding (security, true),
					"http://localhost:8325/");

				host.Open ();

				Console.WriteLine ("Type [CR] to stop ...");
				Console.ReadKey ();

				/*
				/* Demon
				UnixSignal [] signals = new UnixSignal[]
					{
						new UnixSignal (Signum.SIGINT),
						new UnixSignal(Signum.SIGTERM)
					};

				bool exit = false;
				while (!exit)
				{
					int id = UnixSignal.WaitAny (signals);

					if (id >= 0 && id < signals.Length)
					{
						if (signals [id].IsSet)
						{
							signals [id].Reset ();
							exit = true;
						}
					}
				}
				/* Domon */

				host.Close ();
			}

			return 0;
		}
	}
}
