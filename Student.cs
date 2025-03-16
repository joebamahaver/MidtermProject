namespace MidtermProject;
public class Student
{
    private int id;
    private string firstName;
    private string lastName;
    private string major;
    private int creditHours;
    private List<float> testScores=new List<float>();
    private classStatus classStatus;
    public Student(int id,string firstName,string lastName,string major,int creditHours){
        this.id=id;
        this.firstName=firstName;
        this.lastName=lastName;
        this.major=major;
        this.creditHours=creditHours;
    }
    public int getCreditHours()
    {
        return this.creditHours;
    }
    public void calculateClassStatus()
    {
        if(creditHours<=29)
        {
            this.classStatus=classStatus.Freshman;
        }
        else if(creditHours<=59)
        {
            this.classStatus=classStatus.Sophomore;
        }
        else if(creditHours<=89)
        {
            this.classStatus=classStatus.Junior;
        }
        else if(creditHours>=90)
        {
            this.classStatus=classStatus.Senior;
        }
        else{
            Console.WriteLine("Not an integer, calculatetatus method");
            throw new("Not an integer, calculatestatus method");
        }
    }
    public void calculateClassHours(int additionalHours)
    {
        int totalHours=this.creditHours+additionalHours;
        this.creditHours=totalHours;
        calculateClassStatus();
    }
    public void addTestScores(float testScore)
    {
        this.testScores.Add(testScore);
    }
    public List<string> giveTestScores()
    {
        List<string> testScores=new List<string>();
        int i=1;
        foreach(float score in this.testScores)
        {
            testScores.Add($"Test{i}: {score}");
            i++;
        }
        return testScores;
    }
    public int getId()
        {
            return this.id;
        }
    public string getFirstName()
    {
        return this.firstName;
    }
    public string getLastName()
    {
        return this.lastName;
    }
    public string getMajor()
    {
        return this.major;
    }
    public string giveFullName()
    {
        return$"{firstName} {lastName}";
    }
    public classStatus getClassStatus()
    {
        return this.classStatus;
    }
    public float getAverageScore()
    {
        return testScores.Average();
    }
    public string getLetterGrade()
    {
        float averageScore=this.getAverageScore();
        if(averageScore>90)
        {
            return "A";
        }
        else if(90>averageScore&&averageScore>80)
        {
            return "B";
        }
        else if(80>averageScore&&averageScore>70)
        {
            return "C";
        }
        else if(70>averageScore&&averageScore>60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
    public void printStudentInfo()
    {
        Console.WriteLine($"{this.giveFullName}: {this.classStatus}({this.major})");
        Console.WriteLine($"Average Score: {this.getAverageScore}% -- Grade: {this.getLetterGrade}");
    }
}