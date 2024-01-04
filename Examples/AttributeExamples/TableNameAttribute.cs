namespace AttributeExamples;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class TableNameAttribute : Attribute
{
    public TableNameAttribute(string mssqlName, string mysqlName, string postgresName)
    {
        MssqlName = mssqlName;
        MysqlName = mysqlName;
        PostgresName = postgresName;
    }

    public string PostgresName { get; }
    public string MysqlName { get; }
    public string MssqlName { get; }
}