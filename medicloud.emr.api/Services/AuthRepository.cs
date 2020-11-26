using medicloud.emr.api.Data;
using medicloud.emr.api.DTOs;
using medicloud.emr.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace medicloud.emr.api.Services
{
    public interface IAuthRepository
    {
        Task<UserDTO> LoginUser(string username, string password);
        Task RegisterUser(Register model);
        Task<bool> UniqueUsername(string username);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> LoginUser(string username, string password)
        {
            var user = await _context.ApplicationUser.Include(l => l.Location).SingleOrDefaultAsync(u => u.Username == username);
            if (user is null || !BC.Verify(password, user.Passwordhash)) return null;

            var returnedUser = new UserDTO
            { 
                Id = user.Appuserid,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone1,
                Image = user.Image,
                Location = user.Location?.Locationname ?? "",
                Username = user.Username
            };


            return returnedUser;
        }

        public async Task RegisterUser(Register model)
        {
            var personnel = new ApplicationUser
            {
                Username = model.Username,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Middlename = model.Middlename,
                Phone1 = model.Mobile,
                Phone2 = model.Phone,
                Email = model.Email,
                Locationid = Convert.ToInt16(model.Location),
                Image = model.ImageLocation,
                Passwordhash = BC.HashPassword(model.Password)
                 
            };

            _context.ApplicationUser.Add(personnel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UniqueUsername(string username)
        {
            var user = await _context.ApplicationUser.SingleOrDefaultAsync(u => u.Username == username);

            return user == null;
        }
    }
}
