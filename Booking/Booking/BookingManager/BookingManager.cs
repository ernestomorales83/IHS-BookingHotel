using System;
using System.Collections.Generic;
using System.Linq;


namespace BookingHotel
{
    public class BookingManager : IBookingManager
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
            else
            {
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
            return lstRooms.Where(x => !roomIds.Contains(x.Id)).Select(r => r.Id).AsEnumerable();
        }
    }
}
