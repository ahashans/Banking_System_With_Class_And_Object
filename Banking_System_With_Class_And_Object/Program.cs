//Updating the Banking System Project with:
//1. GetType() method 
//2. adding new Class Branch
//3. chainging the property names according to C# naming convention 
//   (Property name in FirstLetterCapiral & backing field name in firstLetterSmall)




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banking_System_With_Class_And_Object
{
    class Account
    {
        //Properties and Fields
        private static int count;//counts the number of object/account has been created
        private int accountNo;
        public string AccountHolderName { get; private set; }//only can be set from inside this class
        private double accountBalance;//the backing field of the property AccountBalance.
        public double AccountBalance {
            get {
                return accountBalance;
            }
            set {
                if (value >= 2000.00)
                    accountBalance = value;
                else
                    Console.WriteLine("Balance have to be greater/equal to 2000.00");
            }
        }
        public double interestBalance { get; private set; }

        //Constructors
        static Account()
        {
            count = 0;
        }

        public Account()
        {
            accountNo = nextAccountID();
            AccountHolderName = "N/A";
            AccountBalance = 2000.00;//account opening minimum accountBalance
            interestBalance = calcInterest();
        }

        public Account(string AccountHolderName, double AccountBalance)
        {
            accountNo = nextAccountID();
            this.AccountHolderName = AccountHolderName;
            this.AccountBalance = AccountBalance;
            interestBalance = calcInterest();
        }

        //Methods
        private int nextAccountID()
        {
            return ++count;//increment by 1 and then return the value
        }
        public void showAccountInfo()
        {
            Console.WriteLine("Account No => {0}", accountNo);
            Console.WriteLine("Account Holder Name => {0}", AccountHolderName);
            Console.WriteLine("Account Balance => {0:F2}", AccountBalance);
            Console.WriteLine("Account Interest => {0:F2}", interestBalance);
        }

        private double calcInterest()
        {
            return ((5 * AccountBalance) / 100);
        }

        private void updateInterest()
        {
            interestBalance = calcInterest();
        }

        private void updateAccountHolderName()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Holder Name(Old) => {0}", AccountHolderName);
            Console.Write("Account Holder Name(New) => ");
            AccountHolderName = Console.ReadLine();
        }

        private void updateAccountBalance()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Balance(Old) => {0}", AccountBalance);
            Console.Write("Account Balance(New)[Need To be Greater or Equal to 2000.00] => ");
            AccountBalance = Convert.ToDouble(Console.ReadLine());
            updateInterest();//to recalculate the interest for the new accountBalance
        }
        public double totalBalance()//AccountBalance+interestBalance
        {
            return (AccountBalance + interestBalance);
        }


        private void withdrawMoney()
        {

            while (true)
            {
                Console.WriteLine("Account No. => {0}", accountNo);
                Console.WriteLine("Account Balance => {0}", AccountBalance);
                Console.WriteLine("Enter the Ammount You want to Withdraw =>");

                double withdrawAmmount = Convert.ToDouble(Console.ReadLine());

                if (withdrawAmmount >= 0)
                {
                    if (AccountBalance >= withdrawAmmount)
                    {
                        accountBalance = accountBalance - withdrawAmmount;//if we use AccountBalance property we always have to keep 2000 in the account
                        updateInterest();
                        break;//withdraw successfull so break out of loop
                    }
                    else
                    {
                        Console.WriteLine("You dont have sufficient accountBalance in your account for this withdrawal ");
                        Console.WriteLine("Re-Enter the Withdraw ammount");
                    }
                }
                else
                {
                    Console.WriteLine("Withdraw Ammount Need to Be Positive(+ve)");
                    Console.WriteLine("Re-Enter the Withdraw ammount");
                }
            }
        }

        private void depostMoney()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Balance => {0}", AccountBalance);
            Console.WriteLine("Enter the Ammount You want to Withdraw =>");

            double depositAmmount = Convert.ToDouble(Console.ReadLine());

            while (true)
            {
                if (depositAmmount >= 0)
                {
                    AccountBalance = accountBalance + depositAmmount;
                    updateInterest();
                    break;//withdraw successfull so break out of loop                                   
                }
                else
                {
                    Console.WriteLine("Deposit Ammount Need to Be Positive(+ve)");
                    Console.WriteLine("Re-Enter the Deposit ammount");
                }
            }
        }
        public void updateAccountInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Account Holder Name");
                Console.WriteLine("Press 2: To Change the Account Balance");
                Console.WriteLine("Press 3: To Withdraw Money");
                Console.WriteLine("Press 4: To Deposit Money");
                Console.WriteLine("Press 5: To See Total Account Balance");
                Console.WriteLine("Press 6: To See Account Information");
                Console.WriteLine("Press 7: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateAccountHolderName();
                }
                else if (updateInfo == 2)
                {
                    updateAccountBalance();
                }
                else if (updateInfo == 3)
                {
                    withdrawMoney();
                }
                else if (updateInfo == 4)
                {
                    depostMoney();
                }
                else if (updateInfo == 5)
                {
                    Console.WriteLine("Total accountBalance of the Account => {0}", totalBalance()); ;
                }
                else if (updateInfo == 6)
                {
                    showAccountInfo();
                }
                else if (updateInfo == 7)
                {
                    Console.WriteLine("You have exited the Account Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }

    }//end of Account Class


    class Employee
    {
        public static int TotalEmpCount { get; private set; }//counts total employee number in the bank

        protected int EmpID { get; private set; }
        public string EmpName { get; private set; }
        private double empSalary;
        protected double EmpSalary {
            get {
                return empSalary;
            }
            set {
                if (value >= 0)
                    empSalary = value;
                else
                    Console.WriteLine("Employe Salary Have to be Positive(+ve) value");
            }
        }
        static Employee()
        {
            TotalEmpCount = 0;
        }

        protected Employee()
        {
            EmpID = nextEmpID();
            EmpName = "N/A";
            EmpSalary = 0.0;
            TotalEmpCount++;
        }

        protected Employee(string EmpName, double EmpSalary)
        {
            EmpID = nextEmpID();
            this.EmpName = EmpName;
            this.EmpSalary = EmpSalary;
            TotalEmpCount++;
        }



        //methods
        protected virtual int nextEmpID()
        {
            return -1;//this method will not be used and always will be overriden 
        }

        protected void updateEmployeeName()
        {
            Console.WriteLine("{0} ID. => {1}", this.GetType().Name, EmpID);
            Console.WriteLine("{0} Name(Old) => {1}", this.GetType().Name, EmpName);
            Console.Write("{0} Name(New) => ", this.GetType().Name);
            EmpName = Console.ReadLine();
        }

        protected void updateEmployeeSalary()
        {
            Console.WriteLine("{0} ID. => {1}", this.GetType().Name, EmpID);
            Console.WriteLine("{0} Salary(Old) => {1}", this.GetType().Name, EmpSalary);
            Console.Write("{0} Balance(New) => ", this.GetType().Name);
            EmpSalary = Convert.ToDouble(Console.ReadLine());
        }
        protected void showEmployeeInfo()
        {
            Console.WriteLine("{0} ID => {1}", this.GetType().Name, EmpID);
            Console.WriteLine("{0} Name => {1}", this.GetType().Name, EmpName);
            Console.WriteLine("{0} Salary => {1:F2}", this.GetType().Name, EmpSalary);
        }

        public virtual void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the {0} Name", this.GetType().Name);
                Console.WriteLine("Press 2: To Change the {0} Salary", this.GetType().Name);
                Console.WriteLine("Press 3: To Show {0} Informtion", this.GetType().Name);
                Console.WriteLine("Press 4: To Exit the {0} Control", this.GetType().Name);

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("You have exited the {0} Update Control.", this.GetType().Name);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }

        public void editAccountInfo(Account[] account)
        {
            for (int i = 0; i < account.Length; i++)
            {
                Console.WriteLine("Account No. => {0}/{1}", (i + 1), account.Length);
                account[i].updateAccountInfo();
            }
        }
    }//end of Employee(Base) class
    class Accountant : Employee
    {
        private static int actCount;


        static Accountant()
        {
            actCount = 0;
        }

        public Accountant() : base()//if i dont include base() compiler will call default constructor of base class
        {
            //nothing here 
        }

        public Accountant(string actName, double actSalary) : base(actName, actSalary)
        {
            //nothing here
        }

        protected override int nextEmpID()
        {
            return ++actCount;
        }

        public override void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Accountant Name");
                Console.WriteLine("Press 2: To Change the Accountant Salary");
                Console.WriteLine("Press 3: To Show Accountant Informtion");
                Console.WriteLine("Press 4: To Show Total Employee Number");
                Console.WriteLine("Press 5: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("Total Employee Number=>{0}", TotalEmpCount);
                }
                else if (updateInfo == 5)
                {
                    Console.WriteLine("You have exited the Accountant Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }
    }//end of Accountant Class
    class Manager : Employee
    {
        private static int managerCount;


        static Manager()
        {
            managerCount = 0;
        }

        public Manager() : base()//if i dont include base() compiler will call default constructor of base class
        {
            //nothing here 
        }

        public Manager(string actName, double actSalary) : base(actName, actSalary)
        {
            //nothing here
        }

        protected override int nextEmpID()
        {
            return ++managerCount;
        }

        public override void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Manager Name");
                Console.WriteLine("Press 2: To Change the Manager Salary");
                Console.WriteLine("Press 3: To Show Manager Informtion");
                Console.WriteLine("Press 4: To Show Total Employee Number");
                Console.WriteLine("Press 5: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("Total Employee Number=>{0}", TotalEmpCount);
                }
                else if (updateInfo == 5)
                {
                    Console.WriteLine("You have exited the Manager Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }



        //public void managerUpdateInfo(Account[] account,Accountant[] accountant)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("Press 1: To Change Account Info");
        //        Console.WriteLine("Press 2: To Change Accountant Info");
        //        Console.WriteLine("Press 3: To Exit the Update Control");

        //        int updateInfo = Convert.ToInt16(Console.ReadLine());

        //        if (updateInfo == 1)
        //        {

        //            managerUpdateAccountInfo(account);
        //        }
        //        else if (updateInfo == 2)
        //        {
        //            managerUpdateAccountantInfo(accountant);
        //        }              
        //        else if (updateInfo == 3)
        //        {
        //            Console.WriteLine("You have exited the Manager Update Control.");
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Wrong Input Try again");
        //        }
        //    }
        //}


        public void editAccountantInfo(Accountant[] accountant)
        {
            for (int i = 0; i < accountant.Length; i++)
            {
                Console.WriteLine("Account No. => {0}/{1}", (i + 1), accountant.Length);
                accountant[i].updateEmployeeInfo();
            }
        }


    }//end of Manager Class


    class Branch
    {
        public static int BranchNo { get; private set; }
        private static int branchCount;
        public Account[] account = new Account[10];
        public Accountant[] accountant = new Accountant[2];
        public Manager manager;


        public string BranchAddress { get; private set; }
        public double TotalBranchBalance { get; private set; }

        static Branch()
        {
            branchCount = 0;
        }
        public Branch()
        {
            BranchNo = nextBranchNo();
            for (int i = 0; i < account.Length; i++)
            {
                account[i] = new Account();
            }
            for (int i = 0; i < accountant.Length; i++)
            {
                accountant[i] = new Accountant();
            }
            manager = new Manager();

            TotalBranchBalance = calculateTotalBranchBalance();
        }

        private int nextBranchNo()
        {
            return ++branchCount;
        }
        private double calculateTotalBranchBalance()
        {
            double temp = 0;
            for (int i = 0; i < account.Length; i++)
            {
                temp = temp + account[i].AccountBalance;
            }
            return temp;
        }

        public void showBranchAccountantInfo()
        {
            Console.WriteLine("Branch{0} Accountant's Information", BranchNo);
            for (int i = 0; i < accountant.Length; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), accountant[i].EmpName);
            }
        }
        public void showBranchManagerInfo()
        {
            Console.WriteLine("Branch{0} Manager's Information", BranchNo);
            Console.WriteLine(" {0} ", manager.EmpName);
        }
        public void showBranchInfo()
        {
            Console.WriteLine("Branch Number => {0}", BranchNo);
            Console.WriteLine("Branch Address => {0}", BranchAddress);
            Console.WriteLine("Branch Manager => {0}", manager.EmpName);
            showBranchAccountantInfo();
            showBranchManagerInfo();
            Console.WriteLine("Total Branch Balance => {0}", TotalBranchBalance);
        }




        public void editAccountInfoThroughAccountant()//***NOT SURE ABOUT THIS CODE
        {
            int accountantNo = Convert.ToInt16(Console.ReadLine());

            if (accountantNo == 1)
            {
                accountant[1].editAccountInfo(account);
            }
            else
            {
                accountant[2].editAccountInfo(account);
            }
        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            Branch branch = new Branch();
            branch.showBranchInfo();
            branch.manager.editAccountantInfo(branch.accountant);
            branch.showBranchInfo();
            Console.ReadKey();
        }
    }

}
