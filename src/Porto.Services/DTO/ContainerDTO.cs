namespace Porto.Services.DTO{
    public class ContainerDTO{
        public long Id { get; set; }
        public string ClientContainer { get;  set; } 
        public string NumContainer { get;  set; } 
        public int TypeContainer { get;  set; } 
        public string StatusContainer { get;  set; } 
        public string CategoryContainer { get;  set; } 


        public ContainerDTO()  { }

        public ContainerDTO(long id, string clientContainer, string numContainer, int typeContainer, string statusContainer, string categoryContainer)
        {
            Id = id;
            ClientContainer = clientContainer;
            NumContainer = numContainer;
            TypeContainer = typeContainer;
            StatusContainer = statusContainer;
            CategoryContainer = categoryContainer;
        }
    }
}