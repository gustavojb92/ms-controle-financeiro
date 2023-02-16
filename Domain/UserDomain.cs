using AutoMapper;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.User;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Domain
{
    public class UserDomain : IUser
    {
        public readonly AppDBContext _context;

        public readonly IMapper _imapper;

        public UserDomain(AppDBContext contex, IMapper imapper)
        {
            _context = contex;
            _imapper = imapper;
        }
        public IEnumerable<ReadUserDTO> GetAll()
        {
            var userList = _context.Users.ToList().OrderByDescending(user => user.Id);
            IEnumerable<ReadUserDTO> usersDTO = _imapper.Map<List<ReadUserDTO>>(userList);
            return usersDTO;
        }

        public ReadUserDTO GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            ReadUserDTO userDTO = _imapper.Map<ReadUserDTO>(user);
            return userDTO;
        }

        public ReadUserDTO Post(AddUserDTO obj)
        {
            User user = _imapper.Map<User>(obj);
            _context.Users.Add(user);
            _context.SaveChanges();
            ReadUserDTO createdUser = _imapper.Map<ReadUserDTO>(user);
            if (createdUser != null)
            {
                var balance = new Balance();
                balance.Value = 0;
                balance.UserId = createdUser.Id;
                balance.LastUpdate = DateTime.UtcNow.Date;
                _context.Balances.Add(balance);
                _context.SaveChanges();

            }
            return createdUser;
        }

        public ReadUserDTO Put(int id, AddUserDTO obj)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) return null;

            _imapper.Map(obj, user);
            _context.SaveChanges();

            ReadUserDTO userDTO = _imapper.Map<ReadUserDTO>(user);

            return userDTO;

        }

        public bool Delete(int Id)
        {
            var deleteUser = _context.Users.FirstOrDefault(x => x.Id == Id);

            if (deleteUser == null) return false;

            _context.Users.Remove(deleteUser);
            _context.SaveChanges();
            return true;

        }

        public bool Login(UserLoginDTO userLogin)
        {
            var findUser = _context.Users.FirstOrDefault(x => x.UserLogin == userLogin.UserLogin);
            if (findUser != null && findUser.Password == userLogin.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}