using System;

namespace MySql_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new DBAccess.BlueBirdDBContext("server=localhost;User Id=root;Database=BLueBirdDB;Port=3306;").Database.EnsureCreated();
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
        }
    }
}
