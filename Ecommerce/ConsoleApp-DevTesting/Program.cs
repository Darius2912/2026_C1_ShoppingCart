using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var uc = new UserCrudFactory();
        var pc = new ProductCrudFactory();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n MENU PRINCIPAL ");
            Console.WriteLine("1. CRUD Usuario");
            Console.WriteLine("2. CRUD Producto");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuUsuario(uc);
                    break;

                case "2":
                    MenuProducto(pc);
                    break;

                case "3":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    private static void MenuUsuario(UserCrudFactory uc)
    {
        bool salirUsuario = false;
        while (!salirUsuario)
        {
            Console.WriteLine("\n MENU CRUD USUARIO ");
            Console.WriteLine("1. Crear usuario");
            Console.WriteLine("2. Actualizar usuario");
            Console.WriteLine("3. Eliminar usuario");
            Console.WriteLine("4. Listar todos los usuarios");
            Console.WriteLine("5. Consultar usuario por ID");
            Console.WriteLine("6. Volver al menú principal");
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
                    user._LastName = vals[1];
                    user.Password = vals[2];
                    user.Email = vals[3];
                    user.BirthDate = DateTime.Parse(vals[4]);
                    user.Status = vals[5];

                    uc.Create(user);
                    Console.WriteLine("Usuario creado correctamente.");
                    break;

                case "2": 
                    Console.WriteLine("Ingrese: id, nombre, apellido, contraseña, email, fecha nacimiento (yyyy-MM-dd), estado - separados por coma:");
                    var updText = Console.ReadLine();
                    var updVals = updText.Split(",");

                    var idUpd = int.Parse(updVals[0]);
                    var existingUser = uc.RetrieveById<User>(idUpd);

                    if (existingUser == null)
                    {
                        Console.WriteLine($"No se encontró un usuario con el ID {idUpd}.");
                    }
                    else
                    {
                        var updUser = new User
                        {
                            Id = idUpd,
                            Name = updVals[1],
                            _LastName = updVals[2],
                            Password = updVals[3],
                            Email = updVals[4],
                            BirthDate = DateTime.Parse(updVals[5]),
                            Status = updVals[6]
                        };

                        uc.Update(updUser);
                        Console.WriteLine("Usuario actualizado correctamente.");
                    }
                    break;

                case "3": 
                    Console.Write("Ingrese el ID del usuario a eliminar: ");
                    int idDel = int.Parse(Console.ReadLine());
                    var userToDelete = uc.RetrieveById<User>(idDel);

                    if (userToDelete == null)
                    {
                        Console.WriteLine($"No se encontró un usuario con el ID {idDel}.");
                    }
                    else
                    {
                        uc.Delete(userToDelete);
                        Console.WriteLine("Usuario eliminado correctamente.");
                    }
                    break;

                case "4":
                    var usuarios = uc.RetrieveAll<User>();
                    Console.WriteLine("\n--- Lista de Usuarios ---");
                    foreach (var u in usuarios)
                    {
                        Console.WriteLine($"ID: {u.Id}, Nombre: {u.Name} {u._LastName}, Email: {u.Email}, Estado: {u.Status}, Fecha Nacimiento: {u.BirthDate.ToShortDateString()}");
                    }
                    break;

                case "5":
                    Console.Write("Ingrese el ID del usuario a consultar: ");
                    int idUser = int.Parse(Console.ReadLine());
                    var usuario = uc.RetrieveById<User>(idUser);
                    if (usuario != null)
                    {
                        Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Name} {usuario._LastName}, Email: {usuario.Email}, Estado: {usuario.Status}, Fecha Nacimiento: {usuario.BirthDate.ToShortDateString()}");
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                    break;

                case "6":
                    salirUsuario = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    private static void MenuProducto(ProductCrudFactory pc)
    {
        bool salirProducto = false;
        while (!salirProducto)
        {
            Console.WriteLine("\n MENU CRUD PRODUCTO ");
            Console.WriteLine("1. Crear producto");
            Console.WriteLine("2. Actualizar producto");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Listar todos los productos");
            Console.WriteLine("5. Consultar producto por ID");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var product = new Product();
                    Console.WriteLine("Ingrese: nombre, descripción, precio, cantidad, categoría - separados por coma:");
                    var pText = Console.ReadLine();
                    var pVals = pText.Split(",");

                    product.Name = pVals[0];
                    product.Description = pVals[1];
                    product.Price = decimal.Parse(pVals[2].Trim()); 
                    product.Quantity = int.Parse(pVals[3].Trim());
                    product.Category = pVals[4];

                    pc.Create(product);
                    Console.WriteLine($"Producto creado correctamente con precio {product.Price:C}.");
                    break;

                case "2":
                    var updProduct = new Product();
                    Console.WriteLine("Ingrese: id, nombre, descripción, precio, cantidad, categoría - separados por coma:");
                    var updPText = Console.ReadLine();
                    var updPVals = updPText.Split(",");

                    updProduct.Id = int.Parse(updPVals[0]);
                    updProduct.Name = updPVals[1];
                    updProduct.Description = updPVals[2];
                    updProduct.Price = decimal.Parse(updPVals[3].Trim());
                    updProduct.Quantity = int.Parse(updPVals[4]);
                    updProduct.Category = updPVals[5];

                    pc.Update(updProduct);
                    Console.WriteLine($"Producto actualizado correctamente con precio {updProduct.Price:C}.");
                    break;

                case "3":
                    var delProduct = new Product();
                    Console.Write("Ingrese el ID del producto a eliminar: ");
                    delProduct.Id = int.Parse(Console.ReadLine());
                    pc.Delete(delProduct);
                    Console.WriteLine("Producto eliminado correctamente.");
                    break;

                case "4":
                    var productos = pc.RetrieveAll<Product>();
                    Console.WriteLine("\n--- Lista de Productos ---");
                    foreach (var p in productos)
                    {
                        Console.WriteLine($"ID: {p.Id}, Nombre: {p.Name}, Descripción: {p.Description}, Precio: {p.Price}, Cantidad: {p.Quantity}, Categoría: {p.Category}");
                    }
                    break;

                case "5":
                    Console.Write("Ingrese el ID del producto a consultar: ");
                    int idProduct = int.Parse(Console.ReadLine());
                    var producto = pc.RetrieveById<Product>(idProduct);
                    if (producto != null)
                    {
                        Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Name}, Descripción: {producto.Description}, Precio: {producto.Price}, Cantidad: {producto.Quantity}, Categoría: {producto.Category}");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                    break;

                case "6":
                    salirProducto = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
