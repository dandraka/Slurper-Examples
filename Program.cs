using System;
using System.Reflection;
using Dandraka.Slurper;

internal class Program
{
    private static void Main(string[] args)
    {
        doJsonSimple1();
        doJsonSimple2();
    }

    private static string getDataFilePath(string fileName)
    {
        string curDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string path = Path.Combine(curDir, "data", fileName);
        return path;
    }

    private static void doJsonSimple1()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("simple1.json"));
        Console.WriteLine((string)jsonObj.Sample);
        Console.WriteLine((int)jsonObj.Id);
    }

    private static void doJsonSimple2()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("simple2Array.json"));
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine((string)jsonObj.List[i].ToString());    
        }
    }    

    private static void doJsonComplex1()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("complex1.json"));
        Console.WriteLine(jsonObj.problems.problems.Diabetes.labs);
        Console.WriteLine(jsonObj.problems.Asthma);
    }
}