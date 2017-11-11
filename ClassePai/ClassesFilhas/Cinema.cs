using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas {
    public class Cinema : Evento {

        public DateTime[] Sessao { get; set; }
        public string Genero { get; set; }

        public Cinema () {

        }

        public Cinema (string Titulo, string Local, int Lotacao, DateTime Data, string Duracao, int Classificacao, DateTime[] Sessao, string Genero) {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Data = Data;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            this.Sessao = Sessao;
            this.Genero = Genero;
        }

        public override bool Cadastrar () {
            bool efetuado = false;
            StreamWriter arquivo = null;                      
            
            try {
                arquivo = new StreamWriter ("arquivo.csv", true);
                //string laco = "";

                //for()

                arquivo.WriteLine (Titulo + ";" + Local + ";" + Lotacao + ";" + Data + ";" + Duracao + ";" + Classificacao + ";" + Genero);
                efetuado = true;
            } catch (Exception ex) {
                throw new Exception ("Erro ao cadastrar. " + ex.Message);
            } finally {
                arquivo.Close ();
            }
            return efetuado;
        }
        public override string Pesquisar (string Titulo) {
            string resultado = "Título não encontrado";
            StreamReader ler = null;

            try {
                ler = new StreamReader ("arquivo.csv", Encoding.Default);
                string linha = "";

                while ((linha = ler.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    if (dados[0] == Titulo) {
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao ler arquivo " + ex.Message;
            } finally {
                ler.Close ();
            }
            return resultado;
        }

        public override string Pesquisar (DateTime Data) {
            string resultado = "Título não encontrado";
            StreamReader ler = null;

            try {
                ler = new StreamReader ("arquivo.csv", Encoding.Default);
                string linha = "";

                while ((linha = ler.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    if (dados[3] == Data.ToString()) {
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao ler arquivo " + ex.Message;
            } finally {
                ler.Close ();
            }
            return resultado;
        }
    }
}