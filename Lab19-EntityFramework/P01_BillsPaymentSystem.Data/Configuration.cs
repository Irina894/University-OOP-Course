using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    public static class Configuration
    {
        public const string ConnectionString =
            "Server=.\\SQLEXPRESS;Database=Payment_BillsDatabase;Integrated Security=True;TrustServerCertificate=True;";
    }
}