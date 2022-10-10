using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebAppMVC.Data;
using WebAppMVC.Models.EFModel;

namespace WebAppMVC.Models.Service
{
    public class RegisterService
    {
        private WebAppMVCContext db = new WebAppMVCContext();
        public void Create(Register register)
        {
            var data = db.Registers.FirstOrDefault(x => x.Email == register.Email);
            if (data != null)
            {
                throw new Exception("這個email已經報名過了");
            }

            #region
            register.CreateTime = DateTime.Now;
            #endregion
            db.Registers.Add(register);
            db.SaveChanges();
        }
        public Register Find(int id)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                throw new Exception("record not found");
            }
            return register;
        }


    }
}