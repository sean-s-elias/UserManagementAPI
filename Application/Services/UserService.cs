using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> CreateUser(User request)
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(
                x => x.UserName == request.UserName 
                    || x.Mobile == request.Mobile
                    || x.Email  == request.Email);

            if (checkUser == null) return Result<Unit>.Failure("User exists");

            var user = new User
            {
                    UserName = request.UserName,
                    Passsword = request.Passsword,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    Phone = request.Phone,
                    Mobile = request.Mobile
            };

            _context.Users.Add(user);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create the user");

            return Result<Unit>.Success(Unit.Value);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (userExist == null) return false;// Result<Unit>.Failure("User Id doesn't exsist");

            _context.Remove(userExist);

            var result = await _context.SaveChangesAsync() > 0;

            //return Result<Unit>.Success(Unit.Value);
            return true;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Result<Unit>> UpdateUser(User request)
        {
            //Need to test when the UI is developed
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null) return Result<Unit>.Failure("Couldn't find the user");

            var d = _mapper.Map(request, user);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update  user");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
