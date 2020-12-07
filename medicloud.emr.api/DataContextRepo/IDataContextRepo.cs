using medicloud.emr.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace medicloud.emr.api.DataContextRepo
{
    public interface IDataContextRepo<T>
    {
       // bool SaveChanges();
        bool AddNew(T entity);
        void AddMultiples(T[] entities);
        bool Update(T entity);
        T GetSingle(Func<T, bool> filter);
        IQueryable<T> GetAll(Func<T, bool> filter);
        IEnumerable<T> GetAll();
        bool Delete(Func<T, bool> filters);
        int count();
        int count(Func<T, bool> filter);
        bool Delete(T entity);
        IQueryable<T> ExecuteRawSql(string query);
        void CloseConnection();
        void ExecutStoredProcedure(string procedureName, out string result);
    }

    public class DataContextRepo<T> : IDataContextRepo<T> where T : class
    {
        private DbSet<T> dbSet;
        private Data.DataContext _dbContext;
        public DataContextRepo()
        {
            _dbContext = new Data.DataContext();
            dbSet = _dbContext.Set<T>();
        }
        public bool AddNew(T entity)
        {
            dbSet.Add(entity);
            return SaveChanges();
        }

        public bool Delete(Func<T, bool> filters)
        {
            var single = GetSingle(filters);
            if(single == null)
            {
                return false;
            }
            dbSet.Remove(single);

            return SaveChanges();
        }

        public bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return SaveChanges();
        }

        public IQueryable<T> GetAll(Func<T, bool> filter)
        {
            return dbSet.Where(filter).AsQueryable<T>();
        }

        public void ExecutStoredProcedure(string procedureName, out string result)
        {
            SQLDataManager sql = new SQLDataManager(false);
           // {
                sql.ExecuteStoredProcedure(procedureName, out var dataReader);
                string returnedResult = "";
                if(dataReader.HasRows)
                {
                    int i = 0;
                    while (dataReader.Read())
                    {
                        returnedResult = "";
                        returnedResult += dataReader[i].ToString();
                        //result += "\t";
                        i++;    
                        //return;
                    }
                }

               result = returnedResult;
               
           // }
        }

        public IEnumerable<T> GetAll()
        {
            
            return dbSet.AsEnumerable<T>();
        }

        public T GetSingle(Func<T, bool> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        private bool SaveChanges()
        {
            bool changesSaved = _dbContext.SaveChanges() > 0;
            CloseConnection();
            return changesSaved;
        }

        public bool Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            //dbSet.Update(entity);
            return SaveChanges();
        }

        public IQueryable<T> ExecuteRawSql(string query)
        {

            var result = dbSet.FromSqlRaw(query);
          //  result.Include(x => x.)
            return result;
        }

        public void CloseConnection()
        {
            _dbContext.Database.CloseConnection();
        }

        public void AddMultiples(T[] entities)
        {
            foreach(var t in entities)
            {
                AddNew(t);
                
            }
        }

        public int count()
        {
            return dbSet.Count();
        }

        public int count(Func<T, bool> filter)
        {
            return dbSet.Count(filter);
        }
    }
}
