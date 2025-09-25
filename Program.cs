// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http.Headers;

namespace myGuestBook {
    
    class Guest {
        public string guest; // Gästen
        public string message; // Meddelandet

        public Guest(string guest, string message) // Slå ihop namn med meddelandet
        {
            this.guest = guest; // Spara gästens namn i fältet
            this.message = message; // Spara meddelandet i fältet
        }
    }
    class GuestBook {
        public static void Main(string[] args)
    {
        // Fråga efter namn
        Console.WriteLine("Ange ditt namn:");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name)) // Kontrollerar att användaren skrivit något
        {
        Console.WriteLine("Fel: Inget namn angivet.");
        return; // Om felkod stoppa koden
        }

        // Fråga efter meddelande
        Console.WriteLine("Skriv något om ditt besök:");
        var message = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(message)) // Kontrollerar att användaren skrivit något
        {
        Console.WriteLine("Fel: Inget meddelande angivet.");
        return; // Om felkod stoppa koden
        }

        // Slå ihop namn och meddelande och skriv ut det i konsollen
        var newGuest = new Guest(name, message);
        Console.WriteLine(); // Tom rad
        Console.WriteLine($"Tack för ditt besök {newGuest.guest}, ditt meddelande är sparat:");
        Console.WriteLine(newGuest.message);
    }
    }
}
