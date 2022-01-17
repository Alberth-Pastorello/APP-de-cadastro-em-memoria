using System.Collections.Generic;

namespace Media.Library.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T retornaPorID(int id);
        void insere(T entidade);
        void exclui(int id);
        void atualiza(int id, T entidade);
        int proximoID();
    }
}