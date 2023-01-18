using System.Runtime.CompilerServices;

namespace employee_manager
{
    internal class Program
    {
        static void attendance()
        {
            Console.WriteLine("Attendance");
            Random random = new Random();
            int chk=random.Next(0,2);
            if (chk==1)
            {
                Console.WriteLine("employee is present");
            }
            else
            {
                Console.WriteLine("employee is absent");
            }
        }
        static void daily_wage()
        {   
            Console.WriteLine("Daily Wage");
            Random random = new Random();
            int chk = random.Next(0, 2);
            int total_hours;
            int rate_per_hour = 20;
            if (chk == 1)
            {
                total_hours=8;
            }
            else
            {
                total_hours=0;
            }
            Console.WriteLine($"total wage for one day = {rate_per_hour*total_hours}");
        }
        static int daily_wage_incl_part_time()
        {
            Console.WriteLine("Daily wage including Part time");
            Random random = new Random();
            int chk = random.Next(0, 3);
            int total_hours;
            int rate_per_hour = 20;
            // if chk==1 ->full time,chk==2 -> 0, chk==0 -> part time
            if (chk == 1)
            {
                Console.WriteLine("full time");
                total_hours = 8;
            }
            else if(chk==2)
            {
                Console.WriteLine("does not work");
                total_hours = 0;
            }
            else
            {
                Console.WriteLine("part time");
                total_hours=4;
            }
            Console.WriteLine($"total wage for one day = {rate_per_hour * total_hours}");
            return total_hours*rate_per_hour;
        }
        static void daily_wage_incl_part_time_using_switch_case()
        {
            Console.WriteLine("Daily wage including Part time using switch-case");
            Random random = new Random();
            int chk = random.Next(0, 3);
            int total_hours=0;
            int rate_per_hour = 20;
            // if chk==1 ->full time,chk==2 -> 0, chk==0 -> part time
            switch (chk)
            {
                case 1:
                    total_hours= 8;
                    break;
                case 2:
                    total_hours= 0;
                    break;
                case 3:
                    total_hours= 4;
                    break;
            }
            Console.WriteLine($"total wage for one day = {rate_per_hour * total_hours}");
        }
        static void monthly_wages()
        {
            Console.WriteLine("Monthly wages");
            int total_days = 20, total_wage = 0;
            for(int i=0;i<total_days;i++)
            {
                total_wage += daily_wage_incl_part_time();
            }
            Console.WriteLine($"total wage = {total_wage}");
        }
        static void monthly_wages_criteria()
        {
            Console.WriteLine("Monthly wages calculation till working hours less than 100 and working days less than 20");
            int total_days = 0, total_wage = 0,total_hours=0,rate=20;
            while(total_hours<100 && total_days<20) 
            {
                total_days++;
                Random random = new Random();
                int chk=random.Next(0, 3);
                if (chk == 1)
                {
                    total_hours += 8;
                }else if(chk == 2)
                {

                }
                else
                {
                    total_hours += 4;
                }
            }
            total_wage = total_hours * rate;
            Console.WriteLine($"total wage ={total_wage}");
            
        }
        static void compute_Wage_Company(string company,int ratePerHr,int workingDays,int workingHours)
        {
            int empHours=0, empDays=0;
            while (empHours < workingHours && empDays < workingHours)
            {
                empDays++;
                Random random = new Random();
                int chk = random.Next(0, 3);
                if (chk == 1)
                {
                    empHours += 8;
                }
                else if (chk == 2)
                {

                }
                else
                {
                    empHours += 4;
                }
            }
            Console.WriteLine($"Total wage for employee in {company} is : {ratePerHr * empHours}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is employee manager");
            attendance();
            daily_wage();
            daily_wage_incl_part_time();
            daily_wage_incl_part_time_using_switch_case();
            monthly_wages();
            monthly_wages_criteria();
            compute_Wage_Company("GE", 20, 20, 80);
            compute_Wage_Company("TCS", 10, 15, 100);

        }
    }
}