using Grido.Models;

namespace ApiForGrido.DataBase
{
    public class DataBasePoint
    {
        private static DataBasePoint inst;
        public static DataBasePoint Instance { get => inst ??= new(); }
        private QwertyContext _context = new();


        public bool AddMap(Map map)
        {
            if (map is null)
                return false;
            _context.Maps.Add(map);
            return _context.Maps.Contains(map);
        }

        public bool AddUser(User user)
        {
            if (user is null)
                return false;
            _context.Users.Add(user);
            return _context.Users.Contains(user);
        }

        internal User AuthUser(User user)
        {
            return user;
        }

        public bool DeleteMap(Map map)
        {
            if (map is null || !_context.Maps.Contains(map))
                return false;
            _context.Maps.Remove(map);
            return !_context.Maps.Contains(map);
        }

        public bool DeleteUser(User user)
        {
            if (user is null || !_context.Users.Contains(user))
                return false;
            _context.Users.Remove(user);
            return !_context.Users.Contains(user);
        }

        public bool EditMap(Map map)
        {
           if (map is null || _context.Maps.FirstOrDefault(s => s.Id == map.Id) is null)
                return false;

            _context.Maps.Update(map);
            return true;
        }

        public bool EditUser(User user)
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
