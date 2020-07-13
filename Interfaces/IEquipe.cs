using System.Collections.Generic;
using EPlayersFim.Models;


namespace EPlayersFim.Interfaces


{
    public interface IEquipe
    {
         void Create(Equipe e );
         List<Equipe> ReadAll();

         void Update(Equipe e );

         void Delete(int IdEquipe);
    }
}