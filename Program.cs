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

				/*
				Console.WriteLine ("Type [CR] to stop ...");
				Console.ReadKey ();
				*/

				/* Demon */
				UnixSignal sigint = new UnixSignal (Signum.SIGINT);
				UnixSignal sigterm = new UnixSignal (Signum.SIGTERM);
				UnixSignal sighup = new UnixSignal (Signum.SIGHUP);
				UnixSignal sigusr2 = new UnixSignal (Signum.SIGUSR2);
				UnixSignal [] signals = new UnixSignal[]
					{
						sigint,
						sigterm,
						sighup,
						sigusr2
					};

				bool exit = false;
				while (!exit)
				{
					int id = UnixSignal.WaitAny (signals);

					if (id >= 0 && id < signals.Length)
					{
						if (sigint.IsSet || sigterm.IsSet)
						{
							sigint.Reset ();
							sigterm.Reset ();
							exit = true;
						} else if (sighup.IsSet)
							sighup.Reset ();
						else if (sigusr2.IsSet)
							sighup.Reset ();

					}
				}
				/* Domon */

				host.Close ();
			}

			return 0;
		}
	}
}
