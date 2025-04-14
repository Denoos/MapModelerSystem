using Grido.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            if (user.IdRole == 0)
            {
                user.IdRole = 1;
                user.IdRoleNavigation = _context.Roles.FirstOrDefault(s => s.Id == user.IdRole);
            }

            _context.Users.Add(user);
            return _context.Users.Contains(user);
        }

        public User AuthUser(User user)
        {
            if (user is null || string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
                return user;

            var result = _context.Users.FirstOrDefault(s => s.Id == user.Id);
            return result ??= new();
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
            if (user is null || _context.Users.FirstOrDefault(s => s.Id == user.Id) is null)
                return false;

            _context.Users.Update(user);
            return true;
        }

        public byte[] GetDefaultPhoto()
            
            => File.ReadAllBytes("Resources\\1.jpg");

        public List<Map> GetManyMaps()
            => [.. _context.Maps];

        public List<User> GetManyUsers()
            => [.. _context.Users];
        
        public List<Role> GetManyRoles()
            => [.. _context.Roles];

        public Map GetOneMap(int id)
            => _context.Maps.FirstOrDefault(s => s.Id == id);

        public User GetOneUser(int id)
            => _context.Users.FirstOrDefault(s => s.Id == id);
    }
}
