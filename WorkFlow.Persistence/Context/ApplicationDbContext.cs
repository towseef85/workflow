using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.EntityConfigurations;

namespace WorkFlow.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        private IDbContextTransaction _currentTransaction;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //try
            //{
            //    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (databaseCreator != null)
            //    {
            //        if (!databaseCreator.CanConnect()) databaseCreator.Create();
            //        if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableDetailedErrors();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void AddAuditInfo()
        {
            var timestamp = DateTime.UtcNow;


            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {

                if (entry.State == EntityState.Added)
                {

                    ((BaseEntity)entry.Entity).CreatedDate = timestamp;
                }
                else
                {
                    ((BaseEntity)entry.Entity).UpdatedDate = timestamp;
                    ((BaseEntity)entry.Entity).CreatedDate = (DateTime?)entry.Property("CreatedDate").OriginalValue;
                }

            }
        }

        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<RequestForms> RequestForms { get; set; }
        public DbSet<RequestFormControls> RequestFormControls { get; set; }
        public DbSet<RequestFormControlsData> RequestFormControlsData { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserActions> UserActions { get; set; }
        public DbSet<RequestControlConditions> RequestControlConditions { get; set; }
        public DbSet<RequestConditionOperators> RequestConditionOperators { get; set; }
        public DbSet<ControlSelectData> ControlSelectData { get; set; }
        public DbSet<RequestConditionUsers> RequestConditionUsers { get; set; }

        //public DbSet<IdentityRole> IdentityRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RequestTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestFormsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestFormControlsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConditionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestFormControlsDataEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ControlSelectDataEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ControlConditionOperatorsEntityConfiguration());
          
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
