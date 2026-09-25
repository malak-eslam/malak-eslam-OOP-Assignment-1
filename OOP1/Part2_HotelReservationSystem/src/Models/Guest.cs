using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem.src.Models;
public class Guest
{
    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    private List<Reservation> reservations = new List<Reservation>();
    public IReadOnlyList<Reservation> Reservations => reservations;

    public Guest(int guestId, string fullName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        GuestId = guestId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }


    public void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }
}
