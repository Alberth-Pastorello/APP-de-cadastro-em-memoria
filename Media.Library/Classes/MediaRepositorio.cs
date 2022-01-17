using System;
using System.Collections.Generic;
using Media.Library.Interfaces;

namespace Media.Library.Classes
{
    public class MediaRepositorio : IRepositorio<Media>
    {
        private List<Media> listaMedia = new List<Media>();
        public void atualiza(int id, Media objeto)
        {
            listaMedia[id] = objeto;
        }

        public void exclui(int id)
        {
            listaMedia[id].excluir();
        }

        public void insere(Media objeto)
        {
            listaMedia.Add(objeto);
        }

        public List<Media> Lista()
        {
            return listaMedia;
        }

        public int proximoID()
        {
            return listaMedia.Count;
        }

        public Media retornaPorID(int id)
        {
            return listaMedia[id];
        }

    }
}