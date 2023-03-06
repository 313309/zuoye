using ConsoleApplication3delegate;

namespace ConsoleApplication3delegate
{
    class DepositCard
    {
        public int amount;

        public void Display()
        {
            Console.WriteLine("储蓄卡余额为：{0}", amount);
        }
        public void Account(int balance,int payday )
        {
            amount += balance;
            Console.WriteLine("今天是本月的{0}号，取款{1}元，储蓄卡余额为：{2}元。", DateTime.Today.Day, balance, amount);
        }
    }

    class CreditCard
    {
        private int billamount;
        private int repaymentday;

        public CreditCard(int billamount, int repaymentday)
        {
            this.billamount = billamount;
            this.repaymentday = repaymentday;
        }

        public int Getbillamount() { return billamount; }

        public int Getrepaymentday() { return repaymentday; }

        public void Display() { Console.WriteLine("信用卡余额为：{0}", billamount); }


    }

    class CreditCardDelegate
    {
        
        public delegate void DelegatePay(int bill, int day);
        public event DelegatePay EventPay;
        public int billamount;
        public int repaymentday;
        public void Notify()
        {
            Console.WriteLine("今天是{0}年{1}月{2}号", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            // 如果事件不为 null
            if (DateTime.Today.Day == repaymentday)
            {
                EventPay(billamount, repaymentday);
                // 触发事件
                Console.WriteLine("还款成功！");
            }
            else Console.WriteLine("未到还款日，无需还款！");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DepositCard depositCard = new DepositCard();
            depositCard.amount = 10000;
            CreditCard creditCard1 = new CreditCard(-2000, 6);
            CreditCard creditCard2 = new CreditCard(-3000, 13);
            CreditCard creditCard3 = new CreditCard(-5000, 29);
            depositCard.Display(); Console.WriteLine("");
            List<CreditCard> Cards = new List<CreditCard>();
            Cards.Add(creditCard1); Cards.Add(creditCard2); Cards.Add(creditCard3);

            foreach (CreditCard card in Cards)
            {
                Console.WriteLine("信用卡开始执行委托还款。。。。。。");
                CreditCardDelegate delegate1 = new CreditCardDelegate();
                delegate1.billamount = card.Getbillamount();
                delegate1.repaymentday = card.Getrepaymentday();
                delegate1.EventPay += new CreditCardDelegate.DelegatePay(depositCard.Account);
                delegate1.Notify();
                depositCard.Display();
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}