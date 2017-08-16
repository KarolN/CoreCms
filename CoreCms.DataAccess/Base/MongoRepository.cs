using System;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Model.Base;
using CoreCms.Common.Utils.Helpers;
using CoreCms.DataAccess.Contract;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CoreCms.DataAccess.Base
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly IMongoDatabase _db;
        
        public MongoRepository(IMongoDatabase db)
        {
            _db = db;
            var hasDeriveredTypes = RegisterDeriveredTypes();
            if (!hasDeriveredTypes)
            {
                BsonClassMap.LookupClassMap(typeof(T));
            }
        }

        private bool RegisterDeriveredTypes()
        {
            var type = typeof(T);
            var deriveredTypes = ReflectionHelper.GetDeriveredTypesInAssembly(type);
            foreach (var deriveredType in deriveredTypes)
            {
                BsonClassMap.LookupClassMap(deriveredType);
            }
            return deriveredTypes.Count > 0;
        }
        
        public IQueryable<T> GetQueryable()
        {
            var instance = new T();
            return _db.GetCollection<T>(instance.CollectionName).AsQueryable();
        }

        public Guid Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            _db.GetCollection<T>(entity.CollectionName).InsertOne(entity);
            return entity.Id;
        }

        public void Update(T entity)
        {
            _db.GetCollection<T>(entity.CollectionName).ReplaceOne(x => x.Id ==  entity.Id, entity);
        }

        public void Remove(Guid id)
        {
            var instance = new T();
            _db.GetCollection<T>(instance.CollectionName).DeleteOne(x => x.Id == id);
        }

        public async Task<Guid> InsertAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await _db.GetCollection<T>(entity.CollectionName).InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            await _db.GetCollection<T>(entity.CollectionName).ReplaceOneAsync(x => x.Id ==  entity.Id, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var instance = new T();
            await _db.GetCollection<T>(instance.CollectionName).DeleteOneAsync(x => x.Id == id);
        }
    }
}