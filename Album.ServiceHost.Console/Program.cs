using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Musicalog.Business.Bootstrapper;
using Musicalog.Business.Entities;
using Musicalog.Business.Managers;
using Core.Common.Core;
using SM = System.ServiceModel;
using System.Threading;
using System.Security.Principal;
using System.Transactions;

namespace Album.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("Starting up services...");
            Console.WriteLine("");

            SM.ServiceHost hostIAlbumManager = new SM.ServiceHost(typeof(AlbumManager));
          
            StartService(hostIAlbumManager, "AlbumManager");


            //System.Timers.Timer timer = new System.Timers.Timer(10000);
            ////timer.Elapsed += OnTimerElapsed;
            //timer.Start();

            Console.WriteLine("Reservation monitor started.");

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
            Console.WriteLine();

            //timer.Stop();

            Console.WriteLine("Reservaton mointor stopped.");

            StopService(hostIAlbumManager, "InventoryManager");
        }

        //static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    AlbumManager albumManager = new AlbumManager();

        //    Reservation[] reservations = albumManager.GetDeadReservations();
        //    if (reservations != null)
        //    {
        //        foreach (Reservation reservation in reservations)
        //        {
        //            using (TransactionScope scope = new TransactionScope())
        //            {
        //                rentalManager.CancelReservation(reservation.ReservationId);
        //                scope.Complete();
        //            }
        //        }
        //    }
        //}

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();
            Console.WriteLine("Service '{0}' started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine(string.Format("Listening on endpoint:"));
                Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Console.WriteLine("Service '{0}' stopped.", serviceDescription);
        }
    }
}
