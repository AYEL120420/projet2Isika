using System.Text;
using System;
using _001JIMCV.Models.Classes;
using System.Security.Cryptography;
using System.Linq;

namespace _001JIMCV.Models.Dals
{
    public class LoginDal : IDisposable
    {
        private BDDContext _bddContext;
        //Constructeur
        public LoginDal()
        {
            _bddContext = new BDDContext();
        }
        public int AddUser(string email, string password)
        {
            string passwordEncoded = _bddContext.EncodeMD5(password);
            User user = new User() { Email = email, Password = passwordEncoded };
            this._bddContext.Users.Add(user);
            this._bddContext.SaveChanges();
            return user.Id;
        }

        public User Authentify(string email, string password)
        {
            string passwordEncoded = _bddContext.EncodeMD5(password);
            User user = this._bddContext.Users.FirstOrDefault(u => u.Email == email && u.Password == passwordEncoded);
            return user;
        }

        public User GetUser(int id)
        {
            return this._bddContext.Users.Find(id);
        }

        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUser(id);
            }
            return null;
        }

        
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
