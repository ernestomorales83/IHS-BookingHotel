using System;
using System.Collections.Generic;
using System.Linq;


namespace Booking
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = new DateTime(2012, 3, 28);

            IBookingManager bm = new Booking();

            bm.InitializeHotelData();
      
            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs true

            bm.AddBooking("Patel", 101, today);

            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs false

            Console.WriteLine(string.Join("\t", bm.getAvailableRooms(today))); // Print list of available rooms

            bm.AddBooking("Li", 101, today); // throws an Exception

            Console.ReadLine();
        }
    }


    public class Booking : IBookingManager
    {
        public static List<Room> lstRooms { get; set; }
        public static List<Reservation> lstReservations { get; set; }

        public void InitializeHotelData() 
        {
            lstRooms = new List<Room>();
            lstRooms.Add(new Room { Id = 101, Price = 100 });
            lstRooms.Add(new Room { Id = 102, Price = 120 });
            lstRooms.Add(new Room { Id = 201, Price = 130 });
            lstRooms.Add(new Room { Id = 202, Price = 140 });

            lstReservations = new List<Reservation>();
        }

        public void AddBooking(string guest, int room, DateTime date)
        {
            if (IsRoomAvailable(room, date))
            {
                lstReservations.Add(new Reservation { Id = lstReservations.Count + 1, RoomId = room, ClientId = guest, Date = date });
            }
            else {
              //  throw new Exception("This room is already booked.");
            }
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            return !lstReservations.Any(x => x.RoomId == room && x.Date == date);        
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            var roomIds = lstReservations.Where(r => r.Date == date).Select(p => p.RoomId);
            return lstRooms.Where(x => !roomIds.Contains(x.Id)).Select(r=> r.Id).AsEnumerable();
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public float Price { get; set; }

    }

    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
    }

    public interface IBookingManager
    {
        /**
       * Iniatialize hotel data
       */
       void InitializeHotelData();

       /**
       * Return true if there is no booking for the given room on the date,
       * otherwise false
*/
        bool IsRoomAvailable(int room, DateTime date);
        /**
        * Add a booking for the given guest in the given room on the given
        * date. If the room is not available, throw a suitable Exception.
*/
        void AddBooking(string guest, int room, DateTime date);

        /**
        * Return a list of all the available room numbers for the given date
        */
        IEnumerable<int> getAvailableRooms(DateTime date);
    }
}
