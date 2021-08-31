using System;

namespace DepositApp
{
    public enum DepositType
    {
        Standart,
        Capital,
        Premium
    }
    class Deposit
    {
        private double baseDeposit;
        private DepositType type;
        private double rate;
        private int period;
        private double capitalizationRate;
        private Client client;

        // Изначальная сумма вклада.
        public double BaseDeposit 
        { 
            get => baseDeposit; 
            private set => baseDeposit = (value < 1000) ? throw new Exception("Min deposit value is 1000") : Math.Round(value, 2) ; }
        public DepositType DepositType { get => type; }

        // В условии сказано что депозит может быть оформлен только на лицо старше 16 лет
        public Client Client 
        { 
            get => client; 
            private set => client = DateTime.Today.Subtract(value.Birthday).Days / 365 < 16 ? throw new ArgumentException("You are too young.") : value; 
        }
        public double Rate { get => rate; }
        public int Period { get => period; }
        public double CapitalizationRate { get => capitalizationRate; }

        // Для создания достаточно знать начальную сумму, тип депозита и клиента на которого он оформляется.
        public Deposit(double baseDeposit, DepositType type, Client client)
        {
            BaseDeposit = baseDeposit;        
            this.type = type;
            Client = client;

            // Назначаем ставку, период начисления процентов, процент капитализации в зависимости от типа депозита.
            switch (type)
            {
                case DepositType.Standart:
                    {
                        rate = 0.21;
                        period = 12;
                        capitalizationRate = 0;
                        break;
                    }
                case DepositType.Capital:
                    {
                        rate = 0.14;
                        period = 1;
                        capitalizationRate = 1;
                        break;
                    }
                case DepositType.Premium:
                    {
                        rate = 0.17;
                        period = 1;
                        capitalizationRate = 0.6;
                        break;
                    }
            }
        }

        // Метод для расчета ожидаемой прибыли по депозиту за {month} месяцев. Возвращает массив с ожидаемым баллансом по месяцам.
        public double[] ExpectedBallance(uint month)
        {
            double[] ballance = new double[month];
            
            // Производим расчет в зависимости от выбранного плана.
            switch(type)
            {
                case DepositType.Standart:
                    {
                        for (int i = 0; i < ballance.Length; i++)
                        {
                            ballance[i] = Math.Round(baseDeposit + baseDeposit * rate * ((i + 1) / period), 2);
                        }
                        break;
                    }
                case DepositType.Capital:
                    {
                        double tempDepositValue = baseDeposit;

                        for (int i = 0; i < ballance.Length; i++)
                        {
                            double monthProfit = tempDepositValue * (rate / 12);

                            ballance[i] = Math.Round(tempDepositValue + monthProfit, 2);

                            tempDepositValue += monthProfit * capitalizationRate;
                        }
                        break;
                    }
                case DepositType.Premium:
                    {
                        double tempDepositValue = baseDeposit;
                        double capitalizationProfit = 0;

                        for (int i = 0; i < ballance.Length; i++)
                        {
                            double monthProfit = tempDepositValue * (rate / 12);
                            capitalizationProfit += monthProfit * (1 - capitalizationRate);

                            ballance[i] = Math.Round(tempDepositValue + monthProfit * capitalizationRate + capitalizationProfit, 2);

                            tempDepositValue += monthProfit * capitalizationRate;                           
                        }
                        break;
                    }
            }

            return ballance;
        }
    }
}
