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

    }
}
