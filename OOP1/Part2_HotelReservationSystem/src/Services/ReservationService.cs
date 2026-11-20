using Part2_HotelReservationSystem.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem.src.Services;
public class ReservationService
{
    private List<Reservation> reservations = new List<Reservation>();
    private int nextReservationId = 1;

    public Reservation CreateReservation(Guest guest, Room room, DateTime checkIn, DateTime checkOut)
    {
        if (room.IsUnderMaintenance)
            throw new InvalidOperationException("Room is under maintenance.");

        if (checkOut <= checkIn)
            throw new ArgumentException("Check-out date must be after check-in date.");


        foreach (Reservation reservation in reservations)
        {
            if (reservation.Room.RoomNumber == room.RoomNumber)
            {
                if (reservation.CheckOutDate > checkIn && reservation.CheckInDate < checkOut)
                {
                    throw new InvalidOperationException("Room is already booked for these dates.");
                }
            }
        }


        Reservation newReservation = new Reservation(
            nextReservationId++,
            guest,
            room,
            checkIn,
            checkOut);

        reservations.Add(newReservation);
        guest.AddReservation(newReservation);

        return newReservation;
    }

      public IReadOnlyList<Reservation> GetReservations()
      {
         return reservations;
      }

}
