using System.Runtime.CompilerServices;

namespace employee_manager
{
    public interface IComputeEmpWage
    {
        public void addCompany(string company, int empRatePerHour, int maxDays, int maxHours);
        public void computeWage();
        public int getTotal(string company);
    }
    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHour;
        public int maxDays;
        public int maxHours;
        public int totalEmpWage;
        public CompanyEmpWage(string company, int empRatePerHour, int maxDays, int maxHours)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.maxDays = maxDays;
            this.maxHours = maxHours;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage=totalEmpWage;
        }
    }
    public class EmpWageBuilder: IComputeEmpWage
    {
        public const int PART_TIME = 1;
        public const int FULL_TIME = 2;
        public const int NO_WORK = 0;
        private List<CompanyEmpWage> companyList;
        private Dictionary<string, CompanyEmpWage> mapping;
        public EmpWageBuilder()
        {
            this.companyList = new List<CompanyEmpWage>();
            this.mapping = new Dictionary<string, CompanyEmpWage>();
        }
        public void addCompany(string company, int empRatePerHour, int maxDays, int maxHours)
        {
            CompanyEmpWage comp=new CompanyEmpWage(company,empRatePerHour,maxDays,maxHours);
            this.companyList.Add(comp);
            this.mapping.Add(company, comp);
        }
        public void computeWage()
        {
            foreach(CompanyEmpWage comp in this.companyList) 
            {
                comp.setTotalEmpWage(this.computeWage(comp));
                Console.WriteLine($"wage for company {comp.company} is {comp.totalEmpWage} ");
            }
        }
        private int computeWage(CompanyEmpWage comp)
        {
            int empHours = 0, empDays = 0;
            while (empHours < comp.maxHours && empDays < comp.maxDays)
            {
                empDays++;
                Random random = new Random();
                int chk = random.Next(0, 3);
                if (chk == FULL_TIME)
                {
                    empHours += 8;
                }
                else if (chk == NO_WORK)
                {

                }
                else
                {
                    empHours += 4;
                }
            }
            return empHours*comp.empRatePerHour;
        }
        public int getTotal(string company)
        {
            return this.mapping[company].totalEmpWage;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is employee wage calculator");
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.addCompany("Reliance",20,4,20);
            empWageBuilder.addCompany("ge", 20, 2, 10);
            empWageBuilder.computeWage();
            Console.WriteLine($"Total wage for reliance is {empWageBuilder.getTotal("Reliance")} ");
            Console.WriteLine($"Total wage for ge is {empWageBuilder.getTotal("ge")} ");

        }
    }
}