namespace SistemaDePedidos
{
    public static class Settings
    {
        public static string SqlServerConnectionString { get; set; } = 
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CursoEfCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
