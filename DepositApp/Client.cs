using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositApp
{
    class Client
    {
        string name;
        DateTime birthday;
        Dictionary.Sex sex;
        Deposit deposit;

        public string Name { get => name; set => name = (value.Trim() == "") ? throw new Exception("Name can`t be blank!") : value.Trim() ; }
        public DateTime Birthday
        {
            get => birthday;
            set => birthday = (value > DateTime.Today) ? throw new Exception("Incorrect date") : 
                                                        (value < DateTime.Today.AddMonths(-120*12)) ? throw new Exception("You are too old") : value; }
        internal Dictionary.Sex Sex { get => sex; set => sex = value; }
        internal Deposit Deposit { get => deposit; set => deposit = ((DateTime.Today.Subtract(birthday).Days/365 < 16)) ? null : value; }

        public Client(string name, DateTime birthday, Dictionary.Sex sex, Deposit deposit)
        {
            Name = name;
            Birthday = birthday;
            Sex = sex;
            Deposit = deposit;
        }

        public Client(string name, DateTime birthday, Dictionary.Sex sex)
        {
            Name = name;
            Birthday = birthday;
            Sex = sex;
        }

        public void AddDeposit(Deposit deposit)
        {
            Deposit = deposit;
        }

        public double[] GetBallance(int month)
        {
            return deposit.Ballance(month);
        }
    }
}
