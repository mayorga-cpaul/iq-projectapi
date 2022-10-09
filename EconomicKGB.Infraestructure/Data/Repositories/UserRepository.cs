using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using Dapper;
using System.Text.RegularExpressions;
using SmartSolution.Domain.Entities.EntitiesBase;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

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

                if (! await ExistEmailAsync(entity.Email) && entity.Password != null)
                {
                    string pass = Encoding.Default.GetString(bytes: entity.Password);

                    using (var connection = repository.Database.GetDbConnection())
                    {
                        var result = await connection.ExecuteAsync("sp_Registras", new
                        {
                            name = entity.Name,
                            email = entity.Email,
                            phoneNumber = entity.PhoneNumber,
                            dni = entity.Dni,
                            password = Encoding.Default.GetString(entity.Password),
                            estado = entity.State,
                            creacion = entity.Creation,

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
        public async Task<bool> AccessToAppAsync(string email, string password)
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
                bool exist = await repository.Usuarios.
                    AnyAsync(e => e.Email.Equals(email));

                return exist;
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
                if (!await ExistEmailAsync(email))
                    throw new Exception($"No existe un usuario con {email} en nuestra base de datos");

                var data = await repository.Usuarios.FirstOrDefaultAsync(p => p.Email.Equals(email));

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

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 userId)
        {
            try
            {
                bool data = await repository.Usuarios.AnyAsync(e => e.Id == userId);
                
                if (!data)
                {
                    throw new Exception($"El usuario con id {userId} no existe");
                }

                return await Task.FromResult(repository.Solutions.Where(e => e.UserId == userId));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> RecoveryPasswordAsync(string e_mail)
        {
            try
            {
                if (await ExistEmailAsync(e_mail))
                {
                    var get = await GetByEmailAsync(e_mail);
                    IMailRepository mailRepository = new MailRepository();
                    mailRepository.SendMail(subject: "SYSTEM: Password recovery request",
                    body: "Hi, " + get.Name + "\nYou Requested to Recover your password.\n" +
                    "your current password is: " + $" {DescryptPassword(e_mail)}" +
                    "\nHowever, we ask that you change your password inmediately once you enter the system.",
                    recipientMail: new List<string> { get.Email });
                    return "Hi, " + get.Name + "\nYou Requested to Recover your password.\n" +
                    "Please check your mail: " + get.Email +
                    "\nHowever, we ask that you change your password inmediately once you enter the system.";
                }
                else
                {
                    return "Sorry, you do not have an account with that mail or username";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsyncWithSp(User entity)
        {
            //[sp_Update]

            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                if (!await ExistEmailAsync(entity.Email) && entity.Password != null)
                {
                    string pass = Encoding.Default.GetString(bytes: entity.Password);

                    using (var connection = repository.Database.GetDbConnection())
                    {
                        var result = await connection.ExecuteAsync("sp_Update", new
                        {
                            name = entity.Name,
                            email = entity.Email,
                            phoneNumber = entity.PhoneNumber,
                            dni = entity.Dni,
                            password = Encoding.Default.GetString(entity.Password),
                            estado = entity.State,
                            creacion = entity.Creation,

                        }, commandType: CommandType.StoredProcedure);

                        return true;
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
     }
}
