using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem.src.Models;

public enum Status
{
    Pending = 1,
    Confirmed = 2,
    CheckedIn = 3,
    CheckedOut = 4,
    Cancelled = 5
}
public class Reservation
{
    public Reservation(int reservationId,Guest guest, Room room, DateTime checkInDate, DateTime checkOutDate)
    {
        if (checkOutDate <= checkInDate)
            throw new ArgumentException("Check-out date must be after check-in date.");

        ReservationId = reservationId;
        Guest = guest;
        Room = room;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Status = Status.Pending;

    }

    public int ReservationId { get; }
    public Guest Guest { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public Room Room { get; }
    public Status Status { get; private set; }


    public void Confirm()
    {
        if (Status != Status.Pending)
            throw new InvalidOperationException("Reservation cannot be confirmed.");

        Status = Status.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != Status.Confirmed)
            throw new InvalidOperationException("Reservation must be confirmed first.");

        Status = Status.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != Status.CheckedIn)
            throw new InvalidOperationException("Reservation must be checked in first.");

        Status = Status.CheckedOut;
    }

    public void Cancel()
    {
        if (Status != Status.Pending && Status != Status.Confirmed)
            throw new InvalidOperationException("Reservation cannot be cancelled.");

        Status = Status.Cancelled;
    }

    public double TotalCost()
    {
        TimeSpan numberOfDays = CheckOutDate - CheckInDate;
        double cost = numberOfDays.Days * Room.NightlyRate;

        return cost;
    }
}
