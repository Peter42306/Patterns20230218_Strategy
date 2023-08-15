using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns20230218_Strategy
{
    // Интерфейс стратегии управления расходами    
    interface IExpenseStrategy
    {
        double CalculateExpenses(double income);
    }

    // Конкретные стратегии управления расходами
    class LowExpenseStrategy : IExpenseStrategy
    {
        public double CalculateExpenses(double income)
        {
            return income * 0.2; // Низкие расходы (20% от доходов)
        }
    }

    class MediumExpenseStrategy : IExpenseStrategy
    {
        public double CalculateExpenses(double income)
        {
            return income * 0.4; // Средние расходы (40% от доходов)
        }
    }

    class HighExpenseStrategy : IExpenseStrategy
    {
        public double CalculateExpenses(double income)
        {
            return income * 0.6; // Высокие расходы (60% от доходов)
        }
    }

    // Класс, использующий стратегию управления расходами на примере компании
    class Company
    {
        private IExpenseStrategy _expenseStrategy;

        public Company(IExpenseStrategy expenseStrategy)
        {
            _expenseStrategy = expenseStrategy;
        }

        public void ManageExpenses(double income)
        {
            double expenses = _expenseStrategy.CalculateExpenses(income);
            Console.WriteLine($"Managing expenses for income {income:N} USD: Expenses are {expenses:N} USD");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов стратегий управления расходами
            IExpenseStrategy lowExpenseStrategy = new LowExpenseStrategy();
            IExpenseStrategy mediumExpenseStrategy = new MediumExpenseStrategy();
            IExpenseStrategy highExpenseStrategy = new HighExpenseStrategy();

            // Создание объектов компаний с разными стратегиями управления расходами
            Company company1 = new Company(lowExpenseStrategy);
            Company company2 = new Company(mediumExpenseStrategy);
            Company company3 = new Company(highExpenseStrategy);

            // Управление расходами компаний с разными стратегиями
            company1.ManageExpenses(10000);
            company2.ManageExpenses(50000);
            company3.ManageExpenses(80000);
        }
    }
}

//Managing expenses for income 10 000,00 USD: Expenses are 2 000,00 USD
//Managing expenses for income 50 000,00 USD: Expenses are 20 000,00 USD
//Managing expenses for income 80 000,00 USD: Expenses are 48 000,00 USD
//Press any key to continue . . .
