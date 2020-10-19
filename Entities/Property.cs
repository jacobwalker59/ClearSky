using System.Collections.Generic;

namespace ClearSky.Entities
{
    public class Property
    {
        public Property()
    {
        this.Messages = new List<Message>();
    }

        public int Id {get;set;}
        public bool IsRentable {get;set;}
        public string PropertyName {get;set;}
        public int PropertyPrice {get;set;}
        public string PropertyDescription { get; set; }
        public ICollection<Message> Messages { get; set; } 
        // ideally should have a one to one between property and the person renting
    }

    
}