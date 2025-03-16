namespace MidtermProject;
public class Student
{
    private int id;
    private string firstName;
    private string lastName;
    private string major;
    private int creditHours;
    private List<float> testScores;
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
    public void calculateClassStatus(int creditHours)
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
        int totalHours=(this.creditHours+additionalHours);
        this.creditHours=totalHours;
        calculateClassStatus(this.creditHours);
    }
    public void addTestScores(float testScore)
    {
        (this.testScores).Add(testScore);
    }
    public List<string> giveTestScores()
    {
        List<string> testScores=new List<string>();
        int i=1;
        foreach(float score in this.testScores)
        {
            testScores.Add($"Test{i}: {score}");
        }
        return testScores;
    }
}