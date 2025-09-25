// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace myGuestBook {
    
    class Guest {
        public string guest {get; set;} = ""; // Gästen, property istället för fält
        public string message {get; set;} = ""; // Meddelandet, property istället för fält

        public Guest() {} // Tom standardkonstruktör för JSON-omvandling
        public Guest(string guest, string message) // Slå ihop namn med meddelandet
        {
            this.guest = guest; // Spara gästens namn
            this.message = message; // Spara meddelandet
        }
    }
    class GuestBook {
        
        // Lista som håller alla inlägg
        static List<Guest> guests = new List<Guest>();
        // Filväg där inläggen i gästboken sparas som JSON
        static string filePath = "guestbook.json";
        public static void Main(string[] args)
    {
        // Läs in tidigare inlägg om filen finns
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            // Läs in gästbok och omvandla JSON från filen tillbaka till listan med objekt
            guests = JsonSerializer.Deserialize<List<Guest>>(json) ?? new List<Guest>();
        }
        
        while (true)
        {
        Console.WriteLine("Gästbok");
        Console.WriteLine("Välj ett alternativ: ");
        Console.WriteLine("1. Lägg till inlägg");
        Console.WriteLine("2. Visa alla inlägg");
        Console.WriteLine("3. Ta bort inlägg");
        Console.WriteLine("4. Avsluta");

        var choice = Console.ReadLine(); // Val av alternativ

        // Alternativ 1 - Lägg till inlägg
        if (choice == "1") {

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
            guests.Add(newGuest);

            // Spara och omvandla inlägg till fil
            string json = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            Console.WriteLine(); // Tom rad
            Console.WriteLine($"Tack för ditt besök {newGuest.guest}, ditt meddelande är sparat:");
            Console.WriteLine(newGuest.message);
            Console.WriteLine(); 
            Console.WriteLine("Tryck Enter för att återgå till menyn.");
            Console.ReadLine(); // Väntar på att användaren trycker Enter
            Console.Clear(); // Rensa skärmen
        }
        // Alternativ 2 - Visa alla inlägg
        if (choice == "2") {
            Console.WriteLine("Alla inlägg i gästboken:");

            if (guests.Count > 0) { // Om det finns inlägg att visa
                // Loopa igenom listan så att varje objekt skrivs ut
                for (int i = 0; i < guests.Count; i++) {
                     Console.WriteLine($"{i + 1}. {guests[i].guest}: {guests[i].message}");
                }
            } else { // Inga inlägg att visa
                Console.WriteLine("Det finns inga inlägg att visa");
            }
            Console.WriteLine(); 
            Console.WriteLine("Tryck Enter för att återgå till menyn.");
            Console.ReadLine(); // Väntar på att användaren trycker Enter
            Console.Clear(); // Rensa skärmen
        }
        // Alternativ 3 - Ta bort inlägg
        if (choice == "3") {

        } 
        // Alternativ 4 - Avsluta program
        if (choice == "4") break;
    }

    }
}
}
