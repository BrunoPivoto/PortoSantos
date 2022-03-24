using System.Collections.Generic;

namespace Porto.Domain.Entities{
    public abstract class Base {
        public long Id { get; set; }
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors; //assim quem ta de fora nao coonsegue manipular o _erros, somente eu, pois está apenas refletindo

        public abstract bool Validate(); //autovalidação pra evitar exceptions
    }
}