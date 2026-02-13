using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var uc = new UserCrudFactory();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n MENU CUD ");
            Console.WriteLine("1. Crear usuario");
            Console.WriteLine("2. Actualizar usuario");
            Console.WriteLine("3. Eliminar usuario");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var user = new User();
                    Console.WriteLine("Ingrese: nombre, apellido, contraseña, email, fecha nacimiento (yyyy-MM-dd), estado - separados por coma:");
                    var text = Console.ReadLine();
                    var vals = text.Split(",");

                    user.Name = vals[0];
                    user.LastName = vals[1];
                    user.Password = vals[2];
                    user.Email = vals[3];
                    user.BirthDate = DateTime.Parse(vals[4]);
                    user.Status = vals[5];

                    uc.Create(user);
                    Console.WriteLine("Usuario creado correctamente.");
                    break;

                case "2":
                    var updUser = new User();
                    Console.WriteLine("Ingrese: id, nombre, apellido, contraseña, email, fecha nacimiento (yyyy-MM-dd), estado - separados por coma:");
                    var updText = Console.ReadLine();
                    var updVals = updText.Split(",");

                    updUser.id = int.Parse(updVals[0]);
                    updUser.Name = updVals[1];
                    updUser.LastName = updVals[2];
                    updUser.Password = updVals[3];
                    updUser.Email = updVals[4];
                    updUser.BirthDate = DateTime.Parse(updVals[5]);
                    updUser.Status = updVals[6];

                    uc.Update(updUser);
                    Console.WriteLine("Usuario actualizado correctamente.");
                    break;

                case "3":
                    var delUser = new User();
                    Console.Write("Ingrese el ID del usuario a eliminar: ");
                    delUser.id = int.Parse(Console.ReadLine());
                    uc.Delete(delUser);
                    Console.WriteLine("Usuario eliminado correctamente.");
                    break;

                case "4":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
