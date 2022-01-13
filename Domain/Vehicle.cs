using System;

namespace Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }       
        public short Year { get; set; } 
        public string Make { get; set; }
        public string Model { get; set; }          
    }
}
