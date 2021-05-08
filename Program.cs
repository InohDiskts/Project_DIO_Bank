using System;
using System.Collections.Generic;

namespace ProjetoOO_Bank
{
    class Program
    {
        static List<Account> listAccounts = new List<Account>();
        static void Main(string[] args)
        {
            string usrOpt = AquireUserInput();
            while (usrOpt.ToUpper() != "X")
            {
                switch (usrOpt)
                {
                    case "1":
                        ListAllAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                usrOpt = AquireUserInput();
            }
            Console.WriteLine("Thank you for using our services!");
        }

        private static void Transfer()
        {
            Console.Write("Please input source account: ");
            int indexSourceAccount = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Please input recipient account: ");
            int indexRecipientAccount = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Please input the transfer value: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccounts[indexSourceAccount].Transfer(transferValue, listAccounts[indexRecipientAccount]);
        }

        private static void Deposit()
        {
            Console.Write("Please input the account number: ");
            int indexAccount = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Please input the deposit value: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.Write("Please input the account number: ");
            int indexAccount = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Please input the withdraw value: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Withdraw(withdrawValue);
        }

        private static void ListAllAccounts()
        {
            Console.WriteLine("Listing Accounts");
            if (listAccounts.Count == 0)
            {
                Console.WriteLine("No accounts registered");
                return;
            }

            for (int i=0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write("#{0} - ", i+1);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new account");

            Console.Write("Type 1 for Physical Person or 2 for Juridic Person: ");
            int accountypeInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input client name");
            string nameInput = Console.ReadLine();

            Console.WriteLine("Please input initial balance");
            double balanceInput = double.Parse(Console.ReadLine());

            Console.WriteLine("Please input the credit");
            double creditInput = double.Parse(Console.ReadLine());

            Account newAccount =  new Account((TypeAccount)accountypeInput, balanceInput, creditInput, nameInput);

            listAccounts.Add(newAccount);
        }

        private static string AquireUserInput()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to DIO Bank!");
            Console.WriteLine("Please select an option below");

            Console.WriteLine("1- List accounts");
            Console.WriteLine("2- Insert new account");
            Console.WriteLine("3- Transfer");
            Console.WriteLine("4- Withdraw");
            Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Clear Screen");
            Console.WriteLine("X- Leave/Exit");
            Console.WriteLine("");

            string usrOption = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return usrOption;
        }
    }
}
