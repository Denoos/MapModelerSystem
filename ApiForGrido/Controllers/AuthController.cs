﻿using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForGrido.Controllers
{
    public class AuthController : Controller
    {
        DataBasePoint _db;

        AuthController()
            => _db = DataBasePoint.Instance;


        [HttpPost]
        public bool Reg(User user) => _db.AddUser(user);
        [HttpPut]
        public bool Upd(User user) => _db.EditUser(user);
        [HttpDelete]
        public bool Rem(User user) => _db.DeleteUser(user);
        [HttpGet]
        public User Auth(User user) => _db.AuthUser( user);
    }
}
