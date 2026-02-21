using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore
{

    //clase de negocio con validaciones y acciones
    public class UserManager : BaseManager
    {

        //Metodo que crea el usuario, validar que este sea mayor de edad
        //Envia un correo de bienvenida al usuario
        public void Create(User u)
        {
            try
            {
                //valida que el usuario sea mayor de edad
                if (IsOver18(u))
                {
                    var uCrud = new UserCrudFactory();
                    uCrud.Create(u);

                    //una vez creado envia el mail de bienvenida
                    EmailManager.SendWolcomeEmail(u);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private bool IsOver18(User u)
        {
            return true;
        }
    }
}