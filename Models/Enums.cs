namespace BujairiTic.Models
{
    public class Enums
    {
        public enum ItemType
        {
            Restaurant,
            DiriyahPass
        }

        public enum OrderStatus
        {
            Draft = 0,          
            Checkout = 1,       
            CardEntered = 2,    
            OtpStage = 3,       
            PendingAdmin = 4,   
            Completed = 5,      
            Rejected = 6        
        }

    }
}
