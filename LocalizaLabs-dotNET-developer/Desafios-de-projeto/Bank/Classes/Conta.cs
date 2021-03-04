using System;

namespace Bank
{
    public class Conta
    {
        private TipoConta tipoConta;

        private string nome;
        private double saldo;
        private double credito;


        public Conta(TipoConta tipo, string nome, double saldo, double credito)
        {
            this.tipoConta = tipo;
            this.nome = nome;
            this.saldo = saldo;
            this.credito = credito;
        }


        public bool Sacar(double valor)
        {
            // Validação de saldo suficiente
            if ((this.saldo - valor) < (this.credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.saldo -= valor;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é de {this.saldo}.");
            return true;
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é de {this.saldo}.");
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }


        public override string ToString()
        {
            string str = "";
            str += "TipoConta " + this.tipoConta + " | ";
            str += "Nome " + this.nome + " | ";
            str += "Saldo " + this.saldo + " | ";
            str += "Credito " + this.credito + " | ";
            return str;
        }
    }
}