using Backend.Dbo;
using Backend.Model;
using System.Collections.Generic;

namespace Backend.DataAccess
{
    public static class DataAccessTest
    {
        public static Test GetData(int id, AppDb db)
        {
            return new Test();
        }

        public static IEnumerable<Test> GetAllData(AppDb db)
        {
            List<Test> tamere = new List<Test>();
            return tamere;
        }

    }
}
