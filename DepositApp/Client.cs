using System;

namespace DepositApp
{
    public enum Sex
    {
        Female,
        Male
    }
    class Client
    {
        string name;
        DateTime birthday;
        Sex sex;
        Deposit deposit;

        public string Name 
        { 
            get => name; 
            private set => name = string.IsNullOrWhiteSpace(value) ? throw new Exception("Name can`t be blank!") : value.Trim() ; }
        public DateTime Birthday
        {
            get => birthday;
            private set => birthday = (value > DateTime.Today) ? throw new Exception("Incorrect date") : value; }
        public Sex Sex { get => sex; private set => sex = value; }
        public Deposit Deposit { get => deposit; private set => deposit = value; }

        public Client(string name, DateTime birthday, Sex sex)
        {
            Name = name;
            Birthday = birthday;
            Sex = sex;
        }

        public void AddDeposit(double sum, DepositType type)
        {
            Deposit = new Deposit(sum, type, this);
        }

        public double[] GetBallance(int month)
        {
            return deposit.Ballance(month);
        }
    }
}
