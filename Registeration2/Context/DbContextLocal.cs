//// -----------------------------------------------------------------------
//// <copyright file="DbContextLocal.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// This is a test file created by Fluent Infrastructure in order to 
/// illustrate its operation.
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using System.Data.Entity;
using Fluent.Infrastructure.FluentDBContext;
using Registeration2.Models;

namespace Registeration2.DataBase 
{
    public class DbContextLocal : DBContext
    {
        public DbContextLocal() : base(@"data source=X509J;initial catalog=Register3;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework providerName = System.Data.SqlClient") { }

        public DbSet<Forum> Forum { get; set; }
    }
}