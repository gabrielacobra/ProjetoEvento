using System;

namespace ProjetoEvento.ClassePai
{
    public abstract class Evento
    {
        public string Titulo { get; set; }
        public string Local { get; set; }
        public int Lotacao { get; set; }
        public DateTime Data { get; set; } //utilizaremos array para cinema e teatro pois pode ocorrer em diversas datas diferentes (sessões de cinema e espetáculos) 
        public string Duracao { get; set; }
        public int Classificacao { get; set; }


        public virtual bool Cadastrar() //usamos o virtual pq ele é passível de ser subscrito
        {
            return false; //return false pois estamos utilizando bool
        }
        public virtual string Pesquisar(DateTime DataEvento)
        {
            return null;
        }

        public virtual string Pesquisar(string TituloEvento)
        {
            return null;
        }
    }
}