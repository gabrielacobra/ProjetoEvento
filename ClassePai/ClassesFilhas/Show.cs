using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas {
    public class Show : Evento {
        public string Atracao { get; set; }
        public string GeneroMusical { get; set; }

        public Show () {

        }

        public Show (string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string Atracao, string GeneroMusical) {

            base.Titulo = Titulo; //base.Titulo, este titulo é da classe pai e o = Titulo é o dado que iremos atribuir
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Atracao = Atracao;
            this.GeneroMusical = GeneroMusical;

        }

        public override bool Cadastrar () //uso o override para sobrescrever, utilizar os atributos também da classe pai e utilizar também os atributos da própria classe (atracao e genero)
        {
            bool efetuado = false;
            StreamWriter arquivo = null;

            try {
                arquivo = new StreamWriter ("show.csv", true);
                arquivo.WriteLine (Titulo + ";" + Local + ";" + Lotacao + ";" + Duracao + ";" + Classificacao + ";" + Data.ToShortDateString() + ";" + Atracao + ";" + GeneroMusical);
                efetuado = true;
            } catch (Exception ex) {
                throw new Exception ("Erro ao tentar salvar o arquivo! " + ex.Message);
            } finally {
                arquivo.Close ();
            }
            return efetuado;
        }

        public override string Pesquisar (string Titulo) {
            string resultado = "Título não encontrado!";
            StreamReader ler = null;

            try {
                ler = new StreamReader ("show.csv", Encoding.Default); //default usa os caracteres utilizados pelo sistema operacional

                string linha = ""; //preparar a leitura do arquivo para ler do início ao fim ou parar até encontrar o item desejado, neste caso, a busca pelo título

                while ((linha = ler.ReadLine ()) != null) { //leitura do arquivo do começo até o fim
                    string[] dados = linha.Split (';'); //criando um array para utilizarmos a posição dos elementos entre os ponto e vírgulas e coloca dentro na posição do array
                    if (dados[0].ToLower() == Titulo.ToLower()) { //se dados na posição 0 for igual ao título pesquisado, então o resultado será a linha inteira (titulo, data, lotacao...)
                        resultado = linha;
                        break; //finaliza o laço, quebra o while
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao tentar ler o arquivo. " + ex.Message;
            } finally {
                ler.Close ();
            }
            return resultado;
        }

        public override string Pesquisar (DateTime Data) {
            string resultado = "Data não encontrada!";
            StreamReader ler = null;

            try {
                ler = new StreamReader ("show.csv", Encoding.Default);
                string linha = "";

                while ((linha = ler.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    if (dados[5] == Data.ToString ()) { //incluído o ToString pois DateTime não engloba este tipo de caracter
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao tentar ler o arquivo. " + ex.Message;
            } finally {
                ler.Close ();
            }

            return resultado;
        }
    }
}