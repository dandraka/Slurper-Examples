using System;
using System.Reflection;
using Dandraka.Slurper;

internal class Program
{
    private static void Main(string[] args)
    {
        doJsonSimple1();
        doJsonSimple2();
        doJsonSimple3();
        doJsonNested1();
        doJsonNested2();
        //doJsonComplex1();
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

    private static void doJsonSimple3()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("simple3Array.json"));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine((string)jsonObj.List[i].List[j].ToString());    
            }
        }
    }        

    private static void doJsonNested1()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("nested1.json"));
        Console.WriteLine((string)jsonObj.image.url);
        Console.WriteLine((int)jsonObj.image.width);
    }

    private static void doJsonNested2()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("nested2WithArray.json"));
        // TODO fails
        Console.WriteLine((string)jsonObj.data.dataList[0].categories.categories[0].CategoryName);
        //Console.WriteLine((int)jsonObj.image.width);
    }

    private static void doJsonComplex1()
    {
        var jsonObj = JsonSlurper.ParseFile(getDataFilePath("complex1.json"));
        // TODO seems that somehow nodes get doubled?
        //Console.WriteLine(jsonObj.problems.problems.Diabetes.Diabetes.labs);
        //Console.WriteLine(jsonObj.problems.Asthma);
    }
}