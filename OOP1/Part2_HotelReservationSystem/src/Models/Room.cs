using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem.src.Models;

public enum RoomType
{
    Single = 1,
    Double = 2,
    Suite = 3
}
public class Room
{
    public Room(int roomNumber, RoomType roomType, double nightlyRate)
    {
        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be greater than zero.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
    }

    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public double NightlyRate { get; private set; }    // private set only
    public bool IsUnderMaintenance { get; private set; }  // private set only

   
    public void UpdatePrice(double nightlyRate)
    {
        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be greater than zero.");

        NightlyRate = nightlyRate;
    }

  

    public void StartMaintenance()
    {
        if(IsUnderMaintenance)
        {
            throw new InvalidOperationException("Room is already under maintenance.");
        }
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        if (!IsUnderMaintenance)
        {
            throw new InvalidOperationException("Room is not under maintenance.");
        }
        IsUnderMaintenance = false;
    }
}
