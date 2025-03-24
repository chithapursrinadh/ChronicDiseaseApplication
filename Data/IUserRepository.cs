﻿using ChronicDiseaseApplication.Models;

namespace ChronicDiseaseApplication.Data
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
