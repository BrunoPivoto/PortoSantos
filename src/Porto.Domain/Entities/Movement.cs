using Porto.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Porto.Domain.Entities{
    public class Movement : Base{
        //PROPRIEDADES
        public string TypeMovement { get; private set; } //embarque, descarga, gate in, gate out, reposicionamento, pesagem e scanner
        public string DateInitial { get; private set; } //data do inicio
        public string HourInitial { get; private set; } //hora do inicio
        public string DateFinish { get; private set; } //data do fim
        public string HourFinish { get; private set; } //hora do fim
        

        //EF
        protected Movement(){ } //deixar a entidade fechada

        public Movement(string typeMovement, string dateInitial, string hourInitial, string dateFinish, string hourFinish)
        {
            TypeMovement = typeMovement;
            DateInitial = dateInitial;
            HourInitial = hourInitial;
            DateFinish = dateFinish;
            HourFinish = hourFinish;
            _errors = new List<string>();

            Validate();
        }



        //COMPORTAMENTOS
        public void ChangeTypeMovement(string typeMovement){ 
            TypeMovement = typeMovement;
            Validate();
        }
        public void ChangeDateInitial(string dateInitial){ 
            DateInitial = dateInitial;
            Validate();
        }
        public void ChangeHourInitial(string hourInitial){ 
            HourInitial = hourInitial;
            Validate();
        }
        public void ChangeDateFinish(string dateFinish){ 
            DateFinish = dateFinish;
            Validate();
        }
        public void ChangeHourFinish(string hourFinish){ 
            HourFinish = hourFinish;
            Validate();
        }

        //AUTOVALIDAÇÃO
        public override bool Validate() //implementando a função de validação
        {
            var validator = new MovementValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos" + _errors[0]);  
            }

        return true;
        }
    }
}