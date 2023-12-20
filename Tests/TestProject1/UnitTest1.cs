using Microsoft.Data.SqlClient;
using System.Data;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DataSet ds = new();
            ds.ReadXmlSchema(@"W:\C#\PocotaNew3\Tests\Generated\Framework\ServerStuff\DataSetSchema.xml");
            SqlConnection conn = new("Server=.\\sqlexpress;Database=master;Trusted_Connection=True;Encrypt=no;");
            conn.Open();
        }
    }
}