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

        // Проверяем что клиент ввел имя. 
        public string Name 
        { 
            get => name; 
            private set => name = string.IsNullOrWhiteSpace(value) ? throw new Exception("Name can`t be blank!") : value.Trim() ; }
        // Проверяем дату рождения на корректность. Так как особых требовоний к клиенту у нас нет, проверяем что дата рождения не больше сегодняшней.
        public DateTime Birthday
        {
            get => birthday;
            private set => birthday = (value > DateTime.Today) ? throw new Exception("Incorrect date") : value; }
        public Sex Sex { get => sex; private set => sex = value; }

        public Client(string name, DateTime birthday, Sex sex)
        {
            Name = name;
            Birthday = birthday;
            Sex = sex;
        }
    }
}
