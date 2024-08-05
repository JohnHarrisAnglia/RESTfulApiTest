﻿using CandidateAssignment.Domain.Models.Entities;

namespace CandidateAssignment.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity>  where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
