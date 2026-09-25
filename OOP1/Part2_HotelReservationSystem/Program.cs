using Part2_HotelReservationSystem.src.Models;
using Part2_HotelReservationSystem.src.Services;

#region Create guests
Guest guest = new Guest(1,"Malak Eslam","01012345678");
Guest secondGuest = new Guest(2, "Ahmed Ali", "01112345678");
#endregion

#region Create rooms
Room room;
Room secondRoom = new Room(102, RoomType.Double, 2000);
Room thirdRoom = new Room(103, RoomType.Suite, 3000);
#endregion

#region Test invalid nightly rate
try
{ 
    room = new Room(101, RoomType.Single, -1500);
}

catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    room = new Room(101, RoomType.Single, 1500);
}
#endregion

#region Create reservation service
ReservationService reservationService = new ReservationService();
#endregion

#region Try to create a reservation for a room under maintenace

// Test room maintenance
room.StartMaintenance();

try
{
    // Try to create a reservation for a room under maintenace
    Reservation reservation = reservationService.CreateReservation( guest, room, new DateTime(2026, 9, 25), new DateTime(2026, 9, 28));

    reservation.Confirm();
    reservation.CheckIn();
    reservation.CheckOut();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
#endregion

#region Test updating room price
room.UpdatePrice(2000);

Console.WriteLine($"New Nightly Rate: {room.NightlyRate}");
#endregion

#region Create second reservation 
try
{
    Reservation secondReservation = reservationService.CreateReservation( secondGuest, secondRoom, new DateTime(2026, 10, 5),new DateTime(2026, 10, 8));
    secondReservation.Confirm();

}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
#endregion

#region Create third reservation 
//Create another valid reservation for the same guest but a different room.
// This verifies that a guest can have multiple reservations.
try
{
    Reservation thirdreservation = reservationService.CreateReservation(secondGuest, thirdRoom, new DateTime(2026, 10, 12), new DateTime(2026, 10, 18));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
#endregion

#region Test overlapping reservation
// Try to reserve the same room for the same dates while it is already reserved. 
// The reservation should be rejected because the dates overlap.
try
{
    Reservation Fourthreservation = reservationService.CreateReservation(guest, thirdRoom, new DateTime(2026, 10, 12), new DateTime(2026, 10, 18));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
#endregion

#region Display all reservations
// Display all successfully created reservations 
// to verify their guest, room, status, and total cost.
Console.WriteLine("All Reservations:");

foreach (Reservation reservationItem in reservationService.GetReservations())
{
    Console.WriteLine($"Reservation ID: {reservationItem.ReservationId}");
    Console.WriteLine($"Guest: {reservationItem.Guest.FullName}");
    Console.WriteLine($"Room: {reservationItem.Room.RoomNumber}");
    Console.WriteLine($"Status: {reservationItem.Status}");
    Console.WriteLine($"Total Cost: {reservationItem.TotalCost()}");
    Console.WriteLine();
}

#endregion
