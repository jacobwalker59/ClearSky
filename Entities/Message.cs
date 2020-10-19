namespace ClearSky.Entities
{
    public class Message
    {
        public int Id {get;set;}
        public string MessageTitle {get;set;}
        public string MessageBody {get;set;}
        public AccountHolder AccountHolder{get;set;}
        public string AccountHolderId { get; set; }
        public Property Property {get;set;}
        public int PropertyId {get;set;}
        
    }
}