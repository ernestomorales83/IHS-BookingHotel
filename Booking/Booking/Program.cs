
using System;

namespace BookingHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = new DateTime(2012, 3, 28);

            IBookingManager bm = new BookingManager();

            bm.InitializeHotelData();
      
            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs true

            bm.AddBooking("Patel", 101, today);

            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs false

            Console.WriteLine(string.Join("\t", bm.getAvailableRooms(today))); // Print list of available rooms

            bm.AddBooking("Li", 101, today); // throws an Exception. The exception line is commented in the AddBooking method 

            Console.ReadLine();
        }
    }    
}
