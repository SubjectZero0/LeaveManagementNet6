﻿using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await GetAsync(id);

            if (entity is not null)
            {
                context.Set<T>().Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int? id)
        {
            var entity = await GetAsync(id);

            if (entity is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id is null)
            {
                throw new Exception("Not found");
            }
            var entity = await context.Set<T>().FindAsync(id); //set<T>() is a generic table relative to T. Any table used with this method

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}