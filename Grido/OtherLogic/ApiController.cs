﻿using Grido.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Grido.OtherLogic
{
    class ApiController
    {
        private static ApiController inst;
        public static ApiController Inst { get => inst ?? new(); }
        HttpClient _client;

        //ApiController()
        // => _client = new() { BaseAddress = new Uri("") }; //НУЖНО добавить сюда адрес апи и раскоментить

        User User;
        public async Task<bool> Registration(User user) //отправляет в апи, и возвращает 1 если user ==  декод от респонса else 0
        {
            User = user;
            return true;
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
        public async Task<List<Role>> GetAllRoles()
        {
            return [];

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> AddUser()
        {
            return true;

            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам
            //сделать ограничение доступа путем возврата нового списка пользователей и списка ролей только администраторам

        }

        public async Task<bool> DeleteMap(Map selectedMap)
        {
            return true;
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
    }
}
