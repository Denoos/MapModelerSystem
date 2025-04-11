using Grido.Models;

namespace ApiForGrido.DataBase
{
    public class DataBasePoint
    {
        private static DataBasePoint inst;
        public static DataBasePoint Instance { get => inst ??= new(); }

        internal bool AddMap(Map map)
        {
            return true;
        }

        internal bool AddUser(User user)
        {
            return true;
        }

        internal User AuthUser(User user)
        {
            return user;
        }

        internal bool DeleteMap(Map map)
        {
            return true;

        }

        internal bool DeleteUser(User user)
        {
            return true;
        }

        internal bool EditMap(Map map)
        {
            return true;
        }

        internal bool EditUser(User user)
        {
            return true;
        }

        internal byte[] GetDefaultPhoto()
        {
            return [];
        }

        internal List<Map> GetManyMaps()
        {
            return [];
        }

        internal List<Map> GetManyUsers()
        {
            return [];
        }

        internal Map GetOneMap(int id)
        {
            return new();
        }

        internal User GetOneUser(int id)
        {
            return new();
        }
    }
}
