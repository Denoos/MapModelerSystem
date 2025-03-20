using Grido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Grido.OtherLogic
{
    class ApiController
    {
        private static ApiController inst;
        public static ApiController Inst { get => inst ?? new(); }
        HttpClient _client;

        //ApiController()
        // => _client = new() { BaseAddress = new Uri("") }; //НУЖНО добавить сюда адрес апи и раскоментить

        public async Task<User> Registration(User user)
        {
            return new User();
        }
        public async Task<User> Authorisation(User user)
        {
            return new User();
        }
    }
}
