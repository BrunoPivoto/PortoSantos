using Porto.Core.Exceptions;
using Porto.Domain.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Porto.Domain.Entities{
    public class Container : Base{

        //PROPRIEDADES
        public string ClientContainer { get; private set; } //private set - dados passados somente por construtores e metodos para mellhor segurança e validação
        public string NumContainer { get; private set; } //4 letras 7 numeros
        public int TypeContainer { get; private set; } // 20/40
        public string StatusContainer { get; private set; } // cheio/vazio
        public string CategoryContainer { get; private set; } //importação/exportação
        
        //EF
        public Container(){ }
        public Container(string clientContainer, string numContainer, int typeContainer, string statusContainer, string categoryContainer)
        {
            ClientContainer = clientContainer;
            NumContainer = numContainer;
            TypeContainer = typeContainer;
            StatusContainer = statusContainer;
            CategoryContainer = categoryContainer;
            _errors = new List<string>();

            Validate();
        }


        //COMPORTAMENTOS
        public void ChangeClientContainer(string clientContainer){ 
            ClientContainer = clientContainer;
            Validate();
        }
        public void ChangeNumContainer(string numContainer){ 
            NumContainer = numContainer;
            Validate();
        }
        public void ChangeTypeContainer(int typeContainer){ 
            TypeContainer = typeContainer;
            Validate();
        }
        public void ChangeStatusContainer(string statusContainer){ 
            StatusContainer = statusContainer;
            Validate();
        }
        public void ChangeCategoryContainer(string categoryContainer){ 
            CategoryContainer = categoryContainer;
            Validate();
        }

        //AUTOVALIDAÇÃO
        public override bool Validate() //implementando a função de validação
        {
            var validator = new ContainerValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos", _errors);  
            }

        return true;
        }
    }
}