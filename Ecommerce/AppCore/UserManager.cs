using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;

namespace AppCore
{
    //clase de negocio con validaciones y acciones
    public class UserManager : BaseManager
    {
        private readonly EmailManager _emailManager;

        // Inyectamos EmailManager en el constructor
        public UserManager(EmailManager emailManager)
        {
            _emailManager = emailManager;
        }

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

                    _emailManager.SendWelcomeEmail(u);
                }
                else
                {
                    throw new Exception("El usuario no cumple con la edad minima para registrase en el sistema");
                }
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public void Update(User u)
        {
            try
            {
                if (IsOver18(u))
                {
                    var uCrud = new UserCrudFactory();
                    uCrud.Update(u);
                }
                else
                {
                    throw new Exception("El usuario no cumple con la edad minima para registrase en el sistema");
                }
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public void Delete(User u)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                uCrud.Delete(u);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            var list = new List<User>();
            try
            {
                var uCrud = new UserCrudFactory();
                list = uCrud.RetrieveAll<User>();
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
            return list;
        }

        public User RetriveUserById(int id)
        {
            var user = new User();
            try
            {
                var uCrud = new UserCrudFactory();
                user = uCrud.RetrieveById<User>(id);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
            return user;
        }

        private bool IsOver18(User u)
        {
            if (u.BirthDate == DateTime.MinValue)
                throw new Exception("La fecha de nacimiento es requerida para validar la edad.");

            var today = DateTime.Today;
            var age = today.Year - u.BirthDate.Year;

            if (u.BirthDate.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }


    }
}
