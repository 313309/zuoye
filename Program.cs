public class Student : IComparable
{
    public double mygrade;
    public string mysubject, myID;
    public Student() { }
    public Student(double grade, string subject, string id)
    {
        mygrade = grade;
        mysubject = subject;
        myID = id;
    }
   int IComparable.CompareTo(object obj)
    {
        if (obj is Student)
        {
            Student stu = (Student)obj;      //stu是取的一个object的值
            if (this.mygrade > stu.mygrade) return -1;
            else if (this.mygrade < stu.mygrade) return 1;
            else return 0;
        }
        throw new ArgumentException("object is not a Student");

    }
}

internal class Program
{

    private static void Main(string[] args)
    {
        Student[] students = new Student[5];
        students[0] = new Student(50.0, "windows程序设计", "001");
        students[1] = new Student(90.0, "windows程序设计", "002");
        students[2] = new Student(100.0, "windows程序设计", "003");
        students[3] = new Student(70.0, "windows程序设计", "004");
        students[4] = new Student(80.0, "windows程序设计", "005");
        Array.Sort(students);
        foreach (Student s in students)
        {
            Console.WriteLine(s.mygrade + " " + s.mysubject + " " + s.myID);
        }
    }

}