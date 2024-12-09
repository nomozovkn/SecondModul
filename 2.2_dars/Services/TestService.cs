using _2._2_dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2_dars.Services;

public class TestService
{
    private string testFilePath;
    private List<Test> _tests;
    public TestService ()
    {
        testFilePath = "../../../Data/Test.json";
        if(File.Exists (testFilePath))
        {
            File.WriteAllText(testFilePath, "[]");
        }
        _tests = new List<Test> ();
        _tests=GetAllTests ();
    }
    public Test AddTest (Test test)
    {
        test.Id= Guid.NewGuid ();
        _tests.Add (test);
        SaveData ();
        return test;
    }
    public Test GetById(Guid testId)
    {
        foreach(var test in _tests)
        {
            if(test.Id == testId)
                return test;
        }
        return null;
    }
    public bool DeletedTest(Guid testId)
    {
        var test = GetById (testId);
        if(test is null)
        {
           return false;
        }
        _tests.Remove (test);
        SaveData ();
        return true;
    }
    public bool UpdatedTest(Test updatedTest)
    {
        var test= GetById (updatedTest.Id);
        if(test is null)
        {
            return false;
        }
        var index =_tests.IndexOf (test);
        _tests[index] = updatedTest;
        SaveData ();
        return true;
    }
    public List<Test> GetAllTests()
    {
        return GetTests();
    }
    public List<Test> RandomTests(int count)
    {
        if(count>=_tests.Count)
        {
            return _tests;
        }
        var randomTests=new List<Test> ();
        var rand=new Random();
        for(var i=0;i<count;)
        {
            var option=rand.Next(0, _tests.Count);
            if (randomTests.Contains(_tests[option]) is false)
            {
                randomTests.Add(_tests[option]);
                i++;
            }
        }
        return randomTests;
    }
    public void SaveData()
    {
        var testJson = JsonSerializer.Serialize(_tests);
        File.WriteAllText (testFilePath, testJson);
    }
    public List<Test> GetTests()
    {
        var testJson=File.ReadAllText(testFilePath);
        var tests=JsonSerializer.Deserialize<List<Test>>(testJson);
        return tests;
    }
}
