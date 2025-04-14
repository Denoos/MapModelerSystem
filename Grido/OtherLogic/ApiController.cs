using Grido.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Grido.OtherLogic
{
    class ApiController
    {
        private static ApiController inst;
        public static ApiController Inst { get => inst ?? new(); }
        HttpClient _client;

        public ApiController()
         => _client = new() { BaseAddress = new Uri("http://localhost:5000/api/") };

        User User;
        public async Task<bool> Registration(User user)
        {
            user.IdRoleNavigation = new();
            user.Maps = [];
            var q = JsonSerializer.Serialize(user);

            var responce = await _client.PostAsJsonAsync("Auth/Reg", user);

            var a = responce.Content.ReadFromJsonAsync<bool>();
            return responce.Content.ToString() == "true";
        }
        public async Task<User> Authorisation(User user) //отправляет в апи, и возвращает декод от респонса
        {
            return User;
        }

        public async Task<List<Map>> GetAllMaps()
        {
            return [];
        }

        public async Task<Visibility> GetVisibility(User user, string role = "unsigned")
        {
            return Visibility.Visible;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return [];

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }
        public async Task<List<string>> GetAllRoles()
        {
            return [];

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> AddUser(User selectedUser)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> AddMap(Map selectedMap)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> EditUser(User selectedUser)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> EditMap(Map selectedMap)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> DeleteMap(Map selectedMap)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        internal async Task ConnectToGame(Map selectedMap, User loggedUser)
        {

        }

        public async Task<bool> DeleteUser(User selectedUser)
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<Role> GetRoleOne(Role selectedRole)
        {
            return new Role();
        }
    }
}
