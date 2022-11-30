using CyberResilience.DAL.CustomRepositories;
using Register2.dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = Register2.dal.Entities.Database;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        public readonly Database _context = new Database();
        //public AspNetRoleRepository Roles
        //{
        //    get
        //    {
        //        return new AspNetRoleRepository(this);
        //    }
        //}
        //public AspNetUserLoginRepository AspNetUserLogin
        //{
        //    get
        //    {
        //        return new AspNetUserLoginRepository(this);
        //    }
        //}
        public AspNetUserRepository AspNetUsers
        {
            get
        {
               return new AspNetUserRepository(this);
           }
        }
        //public LogRepository Logs
        //{
        //    get
        //    {
        //        return new LogRepository(this);
        //    }
        //}
        public UserRepository Students
        {
            get
            {
                return new UserRepository(this);
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //you are not implement this function , 
        public void Save()
        {
            try
            {
                _context.ChangeTracker.DetectChanges();
                var modifiedEntities = _context.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                var now = DateTime.UtcNow;

                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = change.OriginalValues[prop];
                        var currentValue = change.CurrentValues[prop];
                        if (originalValue != null && originalValue.ToString() != currentValue.ToString())
                        {
                            //Tracer.Information($"Database change - entity: {entityName}, Key: {primaryKey}, originalValue: {originalValue}, CurrentValue : {currentValue}");
                        }
                    }
                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException exp)
            {
                ThrowEnhancedValidationException(exp);
            }
        }
        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this._context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

    }
}
