namespace ConsoleApp.Settings
{
    public class SqlServerSettings
    {
        public static string ConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionarioConsoleApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; 
        }
    }
}
