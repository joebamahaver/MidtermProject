namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int,Student> studentDictionary=new Dictionary<int, Student>();
        StreamReader studentsCSV= new StreamReader("student_data.csv");
        while(studentsCSV.EndOfStream==false)
        {
            try
            {
                string studentLine=studentsCSV.ReadLine()!;
                String[] seperatedInfo=studentLine.Split(",")!;
                studentDictionary.Add(int.Parse(seperatedInfo[0]),makeStudent(studentLine));
            }
            catch
            {
                Console.WriteLine("ERROR:While loop for student initialization in the dictionary");
                throw new Exception("ERROR:While loop for student initialization in the dictionary");
            }
        }
        StreamReader studentScores= new StreamReader("scores.csv");
        while(studentScores.EndOfStream==false)
        {
            try
            {
                string scoreLine=studentScores.ReadLine()!;
                String[] seperatedInfo=scoreLine.Split(",")!;
                int id=int.Parse(seperatedInfo[0]);
                if(studentDictionary.ContainsKey(id))
                {
                    int i=1;
                    while(i<seperatedInfo.Length)
                    {
                        studentDictionary[id].addTestScores(float.Parse(seperatedInfo[i]));
                        i++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("ERROR: adding scores to student object in dictionary failed");
                throw new Exception("ERROR: adding scores to student object in dictionary failed");
            }
        }
        using(StreamWriter report=new StreamWriter("report.txt"))
        {
            int count=0;
            report.WriteLine("--------------Student Grade Report--------------\n------------------------------------------------");
            foreach(KeyValuePair<int,Student> person in studentDictionary)
            {
                //count is here for debugging, it is not writing all students currently
                //fixed with using a using block(ironic)
                count++;
                report.WriteLine();
                report.WriteLine($"ID: {person.Key}: {person.Value.giveFullName()}: {person.Value.getClassStatus()}({person.Value.getMajor()})");
                report.WriteLine("----------Scores----------");
                foreach(string test in person.Value.giveTestScores())
                {
                    report.WriteLine(test);
                }
                report.WriteLine();
                report.WriteLine($"Average Score: {person.Value.getAverageScore():N2}% -- Grade: {person.Value.getLetterGrade()}");
            }
        }
        using(StreamReader report=new StreamReader("report.txt"))
        {
            while(report.EndOfStream==false)
            {
                Console.WriteLine(report.ReadLine());
            }
        }
    }
    /* Function that takes the entire csv line in and
    gives out a student object*/
    static Student makeStudent(string studentInfo)
    {
        String[] seperatedInfo=studentInfo.Split(",");
        try
        {
            int id=int.Parse(seperatedInfo[0]);
            string firstName=seperatedInfo[1];
            string lastName=seperatedInfo[2];
            int creditHours=int.Parse(seperatedInfo[3]);
            string major=seperatedInfo[4];
            Student yes=new Student(id,firstName,lastName,major,creditHours);
            yes.calculateClassStatus();
            return yes;
        }
        catch
        {
            Console.WriteLine("ERROR: makeStudentFucntion");
            throw new Exception("ERROR: makeStudentFucntion");
        }
    }
}
