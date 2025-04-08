using Grido.Models;

namespace ApiForGrido.DataBase
{
    public class DataBasePoint
    {
        private static DataBasePoint inst;
        public static DataBasePoint Instance { get => inst ??= new(); }

        internal bool AddMap(Map map)
        {
            throw new NotImplementedException();
        }

        internal bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        internal User AuthUser(User user)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteMap(Map map)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        internal bool EditMap(Map map)
        {
            throw new NotImplementedException();
        }

        internal bool EditUser(User user)
        {
            throw new NotImplementedException();
        }

        internal byte[] GetDefaultPhoto()
        {
            throw new NotImplementedException();
        }

        internal List<Map> GetManyMaps()
        {
            throw new NotImplementedException();
        }

        internal List<Map> GetManyUsers()
        {
            throw new NotImplementedException();
        }

        internal Map GetOneMap(int id)
        {
            throw new NotImplementedException();
        }

        internal User GetOneUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
