﻿using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Exceptions;
using TechChallenge.Domain.Interfaces.Repository;
using TechChallenge.Persistance.Context;
using TechChallenge.Persistance.QuerySupport;

namespace TechChallenge.Persistance.Repository
{
    public class BaseRepository<T>(AppDbContext context, ReadOnlyDbContext readOnlyContext) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context = context;
        private readonly DbSet<T> _table = context.Set<T>();
        private readonly DbSet<T> _tableReadOnly = readOnlyContext.Set<T>();

        public async virtual Task<T> Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async virtual Task<IEnumerable<T>> Get(T entityFilter,
            List<string>? attributesToIgnore,
            bool useLikeOperationInStrings,
            bool considerNullAttributes,
            int page,
            int pageSize)
        {
            ArgumentNullException.ThrowIfNull(entityFilter);

            var query = QueryGenerator.GenerateQueryByFilter(entityFilter, attributesToIgnore, useLikeOperationInStrings, considerNullAttributes);
            return await _tableReadOnly.Where(query)
                                .Skip((page - 1) * pageSize)
                                .Take(page)
                                .ToListAsync();
        }

        public async virtual Task<T?> GetById(Guid id)
        {
            return await _tableReadOnly.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<T> Update(Guid id, T entity)
        {
            if (!await Exists(id))
                throw new NotFoundException();

            entity.Id = id;
            _table.Update(entity);

            await _context.SaveChangesAsync();
            return entity;
        }
        public async virtual Task<T> Delete(Guid id)
        {
            T entity = await GetById(id) ?? throw new NotFoundException();
            entity.DeletedDate = DateTimeOffset.Now;
            _table.Update(entity);

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await GetById(id) != null;
        }

        public async Task<bool> Exists(T entityFilter,
            List<string>? attributesToIgnore,
            bool useLikeOperationInStrings,
            bool considerNullAttributes)
        {
            var query = QueryGenerator.GenerateQueryByFilter(entityFilter, attributesToIgnore, useLikeOperationInStrings, considerNullAttributes);
            return await _tableReadOnly.AnyAsync(query);
        }

        public async Task<int> Count(T entityFilter,
            List<string>? attributesToIgnore,
            bool useLikeOperationInStrings,
            bool considerNullAttributes)
        {
            var query = QueryGenerator.GenerateQueryByFilter(entityFilter, attributesToIgnore, useLikeOperationInStrings, considerNullAttributes);
            return await _tableReadOnly.CountAsync(query);
        }
    }
}
