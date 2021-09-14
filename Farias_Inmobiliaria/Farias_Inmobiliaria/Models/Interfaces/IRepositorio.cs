using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models.Interfaces
{
    public interface IRepositorio<T>
    {
        int Alta(T e);
        int Baja(int id);
        int Modificacion(T e);

        IList<T> ObtenerTodos();
        T ObtenerPorId(int id);
    }
}
