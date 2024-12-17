using _2._2_dars.Models;
using System.Text.Json;

namespace _2._2_dars.Services;

public class TeacherService
{
    private string teacherFilePath;
    private List<Teacher> _teachers;

    public TeacherService()
    {
        teacherFilePath = "../../../Data/Teacher.json";
        if (File.Exists(teacherFilePath)is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
        _teachers = new List<Teacher>();
        _teachers = GetAllTeacher();
    }
    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id= Guid.NewGuid();
        _teachers.Add(teacher);
        SaveData();
        return teacher;
    }
    public Teacher GetById(Guid teacherId)
    {
        foreach(var teacher  in _teachers)
        {
            if(teacher.Id == teacherId)
            {
                return teacher;
            }
            
        }
        return null;
    }
    public bool DeletedTeacher(Guid teacherId)
    {
        var teacher = GetById(teacherId);
        if(teacher is null)
        {
            return false;
        }
        _teachers.Remove(teacher);
        SaveData();
        return true;
    }
    public bool UpdatedTeacher(Teacher updatingTeacher)
    {
        var teacherFromDb=GetById(updatingTeacher.Id);
        if(teacherFromDb is null)
        {
            return false;
        }
        var index=_teachers.IndexOf(teacherFromDb);
        _teachers[index] = updatingTeacher;
        SaveData();
        return true;
    }
    public List<Teacher> GetAllTeacher()
    {
        return GetTeachers();
    }
    public void SaveData()
    {
        var teacherJson = JsonSerializer.Serialize(_teachers);
        File.WriteAllText(teacherFilePath,teacherJson);
    }
    public List<Teacher> GetTeachers()
    {
        var teacherJson=File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teacherJson);
        return teachers;
    }
}
