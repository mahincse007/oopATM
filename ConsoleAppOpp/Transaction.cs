using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpp
{
    public interface ITransaction
    {
        void Start();
        void PinChkeck();
        void Display();
        void BalanceChk();
        void Deposit();
        void Withdrawal();
    }

    class Transaction : ITransaction
    {
        int userCard;
        int userIndex;
        List<Accunt> accountList = new List<Accunt> {};

        public Transaction()
        {
            for(int i=1; i <= 10; i++)
            {
                Accunt AcObj = new Accunt();

                AcObj.cardNo = i;
                AcObj.pinNo = i;
                AcObj.balance = 50000;
                AcObj.noOfTnx = 0; 
                accountList.Add(AcObj);
            }
            Start();
        }

        public void Start()
        {
            Console.WriteLine("\nEnter UR Card ");
            var inputCard = Int32.Parse(Console.ReadLine());
            userIndex = accountList.FindIndex(item => item.cardNo == inputCard);

            if (userIndex < 0)
            {
                Console.WriteLine("\nNo Card Found, please try again\n");
                Start();
            }

            userCard = inputCard;
            PinChkeck();
            Display();
        }

        public void PinChkeck()
        {
            Console.WriteLine("\nEnter UR PIN ");
            var inputPin = Int32.Parse(Console.ReadLine());

            if(accountList[userIndex].pinNo == inputPin)
            {
                return;
            }

            Console.WriteLine("\nWrong PIN, Please try again\n");
            PinChkeck();
        }

        public void Display()
        {
            Console.WriteLine("\nEnter your choise : ");
            Console.WriteLine("\n1 Balance Check \n2 Deposit \n3 Withdrawal \n0 Exit");
            var choise = Int32.Parse(Console.ReadLine());

            if (choise == 1) { BalanceChk(); }
            else if (choise == 2) { Deposit(); }
            else if (choise == 3) { Withdrawal(); }
            else if (choise == 0) { Start(); }

            Display();
        }

        public void BalanceChk()
        {
            Console.WriteLine( "\nYour Current Balance is "+ accountList[userIndex].balance );
        }

        public void Deposit()
        {
            Console.WriteLine("\nEnter your amount : ");
            double amount = Int32.Parse(Console.ReadLine());

            accountList[userIndex].balance += amount;

            Console.WriteLine("\nYour balance has been updated");
            BalanceChk();
        }

        public void Withdrawal()
        {
            Console.WriteLine("\nEnter your amount : ");
            double amount = Int32.Parse(Console.ReadLine());

            if (accountList[userIndex].balance < amount)
            {
                Console.WriteLine("\nDont have sufficient balance, try again");
                Withdrawal();
            }

            if(accountList[userIndex].noOfTnx > 2)
            {
                Console.WriteLine("\nYour daily withdrawal limit reached");
                Start();
            }

            accountList[userIndex].balance -=  amount;
            accountList[userIndex].noOfTnx ++;

            Console.WriteLine("\nYour balance has been updated" + accountList[userIndex].noOfTnx);
            BalanceChk();
        }
    }
}
