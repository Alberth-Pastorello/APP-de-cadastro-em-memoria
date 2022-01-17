namespace Media.Library
{
    public class Media : EntidadeBase
    {
        //atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private int Tipo { get; set; }

        //métodos
        public Media(int id, Genero genero, string titulo, string descricao, int ano, int tipo)
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Tipo = tipo;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Ínicio: " + this.Ano + Environment.NewLine;
            retorno += "ExcluÍdo: " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.ID;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public int retornaTipo()
        {
            return  this.Tipo;
        }
    }
}