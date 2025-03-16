
public class Student
{
    private int id;
    private string firstName;
    private string lastName;
    private string major;
    private int creditHours;
    private List<float> testScores;
    public Student(int id,string firstName,string lastName,string major,int creditHours){
        this.id=id;
        this.firstName=firstName;
        this.lastName=lastName;
        this.major=major;
        this.creditHours=creditHours;
    }
}