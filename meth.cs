using System.Security.Cryptography.X509Certificates;

namespace MidtermProject;
public class Methods
{
    public static classStatus calculateClassStatus(int creditHours)
    {
        if(creditHours<=29)
        {
            return classStatus.Freshman;
        }
        else if(creditHours<=59)
        {
            return classStatus.Sophomore;
        }
        else if(creditHours<=89)
        {
            return classStatus.Junior;
        }
        else if(creditHours>=90)
        {
            return classStatus.Senior;
        }
        else{
            Console.WriteLine("Not an integer, getstatus method");
            throw new("Not an integer, getstatus method");
        }
    }
    public static void calculateClassHours(int additionalHours,Student student)
    {
        
    }
}