using System;

namespace HotelReservation
{
    // Static class to hold session information for the currently logged-in user.
    // This makes user details accessible across different forms in the application.
    public static class Session
    {
        // Property to store the active user object.
        // Set during login, cleared on logout.
        public static User CurrentUser { get; set; }
    }

    // Represents a user in the system (Admin or Customer).
    public class User
    {
        public int UserID { get; set; }        // Unique ID from database
        public string FullName { get; set; }   // User's full name
        public string Email { get; set; }      // User's email address
        public string Phone { get; set; }      // User's phone number

        // Role determines access level (e.g., "Admin" or "Customer").
        // Internal set means only code inside this assembly can modify it.
        public string Role { get; internal set; }
    }
}