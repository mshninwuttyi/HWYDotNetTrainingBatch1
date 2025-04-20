// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//string name = "C";
//if(name == "A")
//{
//    Console.WriteLine("Run");
//}
//else if(name == "B")
//{
//    Console.WriteLine("Sleep");
//}
//else if (name == "C")
//{
//    Console.WriteLine("Eat");
//}
//else
//{
//    Console.WriteLine("Nothing");
//}

//switch (name)
//{
//    case "A":
//        Console.WriteLine("Run");
//        break;
//    case "B":
//        Console.WriteLine("Sleep");
//        break;
//    case "C":
//        Console.WriteLine("Eat");
//        break;
//    default:
//        Console.WriteLine("Nothing");
//        break;
//}

//string[] str = { "A", "B", "C", "D" };

////for(int i=0; i<str.Length ; i++)
////{
////    Console.WriteLine(i);
////}

//foreach (string item in str)
//{
//    Console.WriteLine(item);
//}

//Console.ReadLine();

//Resume resume = new Resume();
Resume resume = new Resume("Mg Mg", 18);
//resume.Name = "Mg Mg";
//resume.Age = 18;
//var result = resume.Is18Year();
resume.SetAge(16);
Console.WriteLine(resume.Name);
Console.WriteLine(resume.Age);
Console.WriteLine(resume.Is18);
//Console.WriteLine(result);  


Resume resume2 = new Resume();
resume2.Name = "Ma Ma";
//resume.Age = 25;

public class Resume
{
    public Resume()
    {
        Name = "None";
    }
    public Resume(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; private set; }
    public bool Is18 {
        get { return Age > 18; }
            }

    public void SetAge(int age)
    {
        Console.WriteLine($"Before {Age}");
        Age = age;
        Console.WriteLine($"Before {Age}");
    }
    //public bool Is18Year()
    //{
    //    return Age > 18;  
    //}
}

