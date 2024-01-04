// See https://aka.ms/new-console-template for more information

using AttributeExamples;

var attribute = (TableNameAttribute)Attribute.GetCustomAttribute(typeof(Student), typeof(TableNameAttribute));
Console.WriteLine(attribute.MssqlName);
Console.WriteLine(attribute.MysqlName);
Console.WriteLine(attribute.PostgresName);