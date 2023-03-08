using Microsoft.EntityFrameworkCore;
using MvcCryptography.Data;
using MvcCryptography.Helpers;
using MvcCryptography.Models;

namespace MvcCryptography.Repositories
{
    public class RepositoryUsuarios
    {
        private readonly UsuariosContext _context;

        public RepositoryUsuarios(UsuariosContext context)
        {
            _context = context;
        }

        public int GetMaximo()
        {
            if (this._context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this._context.Usuarios.Max(z => z.IdUsuario) + 1;
            }
        }

        public Task RegisterUser(string nombre, string email, string password, string imagen)
        {
            string salt = HelperCryptography.GenerateSalt();

            Usuario user = new()
            {
                IdUsuario = this.GetMaximo(),
                Nombre = nombre,
                Email = email,
                Imagen = imagen,
                Salt = salt,
                Password = HelperCryptography.EncryptPassword(password, salt)
            };

            this._context.Usuarios.Add(user);
            return this._context.SaveChangesAsync();
        }

        public async Task<Usuario?> LoginUser(string email, string password)
        {
            Usuario? user = await this._context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                // Recuperamos la password cifrada de la BBDD
                byte[] userPass = user.Password;
                string salt = user.Salt;
                byte[] temp = HelperCryptography.EncryptPassword(password, salt);
                if (HelperCryptography.CompareArrays(userPass, temp))
                {
                    return user;
                }
            }
            return default;
        }
    }
}
