namespace AttributeExamples;

[TableName("mssqlStudent", "mysqlStudent", "postgresStudent")]
public class Student
{
    public string StudentName { get; set; }
    public string StudentID { get; set; }
}

[TableName("mssqlTeacher", "mysqlTeacher", "postgresTeacher")]
public class Teacher
{
    public string Gender { get; set; }
    public int Age { get; set; }
}