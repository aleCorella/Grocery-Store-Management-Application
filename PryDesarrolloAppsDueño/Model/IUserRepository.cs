using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PryDesarrolloAppsDueño.Model
{
    public interface IUserRepository
    {
        bool AunthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);// devuelve info del usuario mediante el id
        UserModel GetByUsernname(string username);// devuelve info del usuario mediante el nombre
        IEnumerable<UserModel> GetByAll();//devuelve todo
    }
}
