using _2._2_dars.Models;
using System.Text.Json;

namespace _2._2_dars.Services;

public class StudentService
{
    private string studentFilePath;
    private List<Student> _students;
    public StudentService()
    {
        studentFilePath = "../../../Data/Student.json";
        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
        _students = new List<Student>();
        _students = GetAllStudents();
    }
    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        _students.Add(student);
        return student;
    }
    public Student GetById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
            {
                return student;
            }

        }
        return null;
    }
    public bool DeletedStudent(Guid studentId)
    {
        var student = GetById(studentId);
        if(student is null)
        {
            return false;
        }
        _students.Remove(student);
        SaveData();
        return true;
    }
    public bool UpdatedStudent(Student updatingStudent)
    {
        var student=GetById(updatingStudent.Id);
        if(student is null)
        {
            return false;
        }
        var index =_students.IndexOf(student);
        _students[index] = updatingStudent;
        SaveData();
        return true;
    }
    
    private List<Student> GetAllStudents()
    {

        return GetStudents();
    }
    private void SaveData()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(studentFilePath, studentJson);
    }
    private List<Student> GetStudents()
    {
        var studentJson = File.ReadAllText(studentFilePath);
        var students = JsonSerializer.Deserialize<List<Student>>(studentJson);
        return students;
    }
}


