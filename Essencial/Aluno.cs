using System;
using System.IO;
using System.Text;


namespace Atividade.Essencial
{
    public class Aluno
    {
        public int id{get;set;}
        public string Nome{get;set;}
        public string Email{get;set;}
        public int Idade{get;set;}
        public Endereco End{get;set;}


        public Aluno()
        {
          
        }
        public Aluno(int id,string nome,string email,int idade, Endereco endereco)
        {
            this.id=id;
            this.Nome=nome;
            this.Email=email;
            this.Idade=idade;
            this.End=endereco;
        }

        public string Salvar(){
            string msg="";
            StreamWriter arquivo=null;
            try{
                arquivo=new StreamWriter("Aluno.csv",true);
                arquivo.WriteLine(
                    Idade+","+
                    Nome+","+
                    Email+";"+
                    Idade+";"+
                    End.Logradouro+";"+
                    End.Numero+";"+
                    End.Complemento+";"+
                    End.Bairro+";"+
                    End.Cidade
                );
                msg="Dados salvo com sucesso!";

            }
            catch(Exception ex){
                msg="Erro ao tentar salvar o arquivo"+ex.Message;
            }
            finally{
                arquivo.Close();
            }
            return msg;
            }

            public Aluno Pesquisar(int id){
                Aluno aluno=null;
                Endereco endereco=null;
                StreamReader arquivo=null;
                try{
                    aluno=new Aluno();

                    endereco = new Endereco();
                    arquivo = new StreamReader("Alunos.csv",Encoding.Default);
                    string linha="";
                    while((linha=arquivo.ReadLine())!=null){
                        string[] dados=linha.Split(';');
                        if(dados[0]==id.ToString()){
                            aluno.Idade=int.Parse(dados[0]);
                            aluno.Nome=dados[1];
                            aluno.Email=dados[2];
                            aluno.Idade=int.Parse(dados[3]);
                            endereco.Logradouro=dados[4];
                            endereco.Numero=dados[5];
                            endereco.Complemento=dados[6];
                            endereco.Bairro=dados[7];
                            endereco.Cidade=dados[8];
                            aluno.End=endereco;

                            break;
                        }
                    }

                }
                catch(Exception ex){
                    throw new Exception("Erro ao tentar ler o arquivo"+ex.Message);
                }
                finally{
                    arquivo.Close();
                }
                return aluno;
            }
    }
}  
                
            
        


    
