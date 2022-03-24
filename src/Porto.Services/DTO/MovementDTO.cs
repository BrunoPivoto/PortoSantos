namespace Porto.Services.DTO{
    public class MovementDTO{
        public long IdMovement { get; set;}
        public string TypeMovement { get; set; } //embarque, descarga, gate in, gate out, reposicionamento, pesagem e scanner
        public string DateInitial { get; set; } //data do inicio
        public string HourInitial { get; set; } //hora do inicio
        public string DateFinish { get; set; } //data do fim
        public string HourFinish { get; set; } //hora do fim
        

        //EF
        protected MovementDTO(){ } //deixar a entidade fechada

        public MovementDTO(long idMovement, string typeMovement, string dateInitial, string hourInitial, string dateFinish, string hourFinish)
        {
            IdMovement = idMovement;
            TypeMovement = typeMovement;
            DateInitial = dateInitial;
            HourInitial = hourInitial;
            DateFinish = dateFinish;
            HourFinish = hourFinish;
        }
    }
}