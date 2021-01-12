using System;


namespace BookingHotel
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
    }
}
