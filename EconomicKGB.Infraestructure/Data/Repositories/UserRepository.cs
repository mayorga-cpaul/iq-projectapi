using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using Dapper;
using System.Text.RegularExpressions;
using SmartSolution.Domain.Entities.EntitiesBase;
using System.Runtime.InteropServices;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly EconomicKGBContext repository;
        public UserRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public override async Task<Int32> CreateAsync(User entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                if (!ExistEmailAsync(entity.Email).Result && entity.Password != null)
                {
                    string pass = Encoding.Default.GetString(bytes: entity.Password);

                    using (var connection = repository.Database.GetDbConnection())
                    {
                        var result = await connection.ExecuteAsync("sp_Registras", new
                        {
                            name = entity.Name,
                            email = entity.Email,
                            profileImage = entity.ProfileImage,
                            phoneNumber = entity.PhoneNumber,
                            dni = entity.Dni,
                            password = Encoding.Default.GetString(entity.Password)

                        }, commandType: CommandType.StoredProcedure);

                        return 1;
                    }
                }
                else
                {
                    throw new Exception("Por favor intente con otro correo electrónico");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //TODO: No se ocupa el name
        public async Task<bool> AccessToAppAsync(string email, string name, string password)
        {
            try
            {
                return await Task.FromResult((ExistEmailAsync(email).Result 
                    ? (password.Equals(DescryptPassword(email)) 
                    ? true : false) 
                    : throw new Exception("Contraseña incorrecta")));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string DescryptPassword(string email)
        {
            try
            {
                using (var connection = repository.Database.GetDbConnection())
                {
                    _ = GetByEmailAsync(email);
                    var result = connection.Query<RecoverPassword>("Recover", new { email = email }, commandType: CommandType.StoredProcedure);
                    return Regex.Replace(result.ToList()[0].Password!, @"\0", "");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            try
            {
                var data = await GetByEmailAsync(email);

                return (data is null) ? false : true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                if (repository.Usuarios.FirstOrDefaultAsync(p => p.Email.Equals(email)).Result is null)
                {
                    throw new Exception("El usuario no existe");
                }
                var data = (await repository.Usuarios.FirstOrDefaultAsync(p => p.Email.Equals(email)));

                if (data is null)
                {
                    throw new Exception("El usuario no existe");
                }

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByNameAsync(string name)
        {
            try
            {
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var data = (await repository.Usuarios.FirstOrDefaultAsync(p => p.Name.Equals(name)));

                if (data is null)
                {
                    throw new Exception("Error");
                }

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario)
        {
            try
            {
                var data = repository.Usuarios.FirstOrDefaultAsync(e => e.Id == usuario);
                if (data is null)
                {
                    throw new Exception("");
                }

                return await Task.FromResult(repository.Solutions.Where(e => e.UserId == data.Id));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<string> RecoveryPasswordAsync(string email)
        {
            //TODO: Method With API 
            throw new NotImplementedException();
        }


    }
}
