using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositApp
{
    class Deposit
    {
        double baseDeposit;
        Dictionary.DepositType type;

        private double rate;
        private int period;
        private double capitalizationRate;

        public double BaseDeposit { get => baseDeposit; set => baseDeposit = (value < 1000) ? throw new Exception("Min deposit value is 1000") : Math.Round(value, 2) ; }        
               

        public Deposit(double baseDeposit, Dictionary.DepositType type)
        {
            BaseDeposit = baseDeposit;        
            this.type = type;

            switch(type)
            {
                case Dictionary.DepositType.Standart:
                    {
                        rate = 0.21;
                        period = 12;
                        capitalizationRate = 0;
                        break;
                    }
                case Dictionary.DepositType.Capital:
                    {
                        rate = 0.14;
                        period = 1;
                        capitalizationRate = 1;
                        break;
                    }
                case Dictionary.DepositType.Premium:
                    {
                        rate = 0.17;
                        period = 1;
                        capitalizationRate = 0.6;
                        break;
                    }
            }
        }

        public double[] Ballance(int month)
        {
            double[] ballance = new double[month];

            switch(type)
            {
                case Dictionary.DepositType.Standart:
                    {
                        for (int i = 0; i < ballance.Length; i++)
                        {
                            ballance[i] = Math.Round(baseDeposit + baseDeposit * rate * ((i + 1) / period), 2);
                        }
                        break;
                    }
                case Dictionary.DepositType.Capital:
                    {
                        double tempDepositValue = baseDeposit;

                        for (int i = 0; i < ballance.Length; i++)
                        {
                            double monthProfit = tempDepositValue * (rate / 12);

                            ballance[i] = Math.Round(tempDepositValue + monthProfit, 2);

                            tempDepositValue += monthProfit*capitalizationRate;
                        }
                        break;
                    }
                case Dictionary.DepositType.Premium:
                    {
                        double tempDepositValue = baseDeposit;
                        double capitalizationProfit = 0;

                        for (int i = 0; i < ballance.Length; i++)
                        {
                            double monthProfit = tempDepositValue * (rate / 12);
                            capitalizationProfit += monthProfit * (1 - capitalizationRate);

                            ballance[i] = Math.Round(tempDepositValue + monthProfit*capitalizationRate + capitalizationProfit, 2);

                            tempDepositValue += monthProfit*capitalizationRate;                            
                        }
                        break;
                    }
            }

            return ballance;
        }
    }
}
