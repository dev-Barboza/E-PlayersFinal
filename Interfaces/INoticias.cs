using System.Collections.Generic;
using EPlayersFim.Models;

namespace EPlayersFim.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias noticias );

         List<Noticias> ReadAll();

         void Update(Noticias noticias);

         void Delete(int IdNoticia);
    }
}