using System;
namespace ProjetoOO_Bank
{
    public class Account
    {
        private TypeAccount TypeAccount {get; set;}
        private double Balance {get; set;}
        private double Credit {get; set;}
        private string Name {get; set;}

        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            this.TypeAccount = typeAccount;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double value)
        {
            if ((this.Balance - value) < (this.Credit *-1))
            {
                Console.WriteLine("Operation not allowed: Insufficent Balance");
                return false;
            }

            this.Balance -= value;

            Console.WriteLine("Operation successful!");
            Console.WriteLine("{0}'s account current balance is: {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
            Console.WriteLine("{0}'s account current balance is: {1}", this.Name, this.Balance);
        }

        public void Transfer(double value, Account recipientAccount)
        {
            if(this.Withdraw(value))
            {
                recipientAccount.Deposit(value);
            }
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Account Type: " + this.TypeAccount + " | ";
            ret += "Name: " + this.Name + " | ";
            ret += "Balance: " + this.Balance + " | ";
            ret += "Credit: " + this.Credit;
            return ret;
        }
    }
}