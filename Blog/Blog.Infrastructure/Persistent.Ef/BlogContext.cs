using Blog.Domain.CategoryAgg;
using Blog.Domain.CommentAgg;
using Blog.Domain.OrderAgg;
using Blog.Domain.PostAgg;
using Blog.Domain.RoleAgg;
using Blog.Domain.SiteEntities;
using Blog.Domain.UserAgg;
using Blog.Infrastructure._Utilities.MediatR;
using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Infrastructure.Persistent.Ef
{
    public class BlogContext : DbContext
    {
        private readonly ICustomPublisher _publisher;
        public BlogContext(DbContextOptions<BlogContext> options, ICustomPublisher publisher) : base(options)
        {
            _publisher = publisher;
            //options.UseSqlServer(("DefaultConnection"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            //    });
        }

        public DbSet<Domain.UserAgg.User> Users { get; set; }
        public DbSet<Domain.CategoryAgg.Category> Categories { get; set; }
        public DbSet<Domain.RoleAgg.Role> Roles { get; set; }
        public DbSet<Domain.PostAgg.Post> Posts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Domain.ProductAgg.Product> Products { get; set; }
        public DbSet<Domain.ProductAgg.ProductInventory> Inventory { get; set; }
        public DbSet<Domain.CommentAgg.Comment> Comments { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modifiedEntities = GetModifiedEntities();
            await PublishEvents(modifiedEntities);
            return await base.SaveChangesAsync(cancellationToken);
        }
        private List<AggregateRoot> GetModifiedEntities() =>
            ChangeTracker.Entries<AggregateRoot>()
                .Where(x => x.State != EntityState.Detached)
                .Select(c => c.Entity)
                .Where(c => c.DomainEvents.Any()).ToList();

        private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.DomainEvents;
                foreach (var domainEvent in events)
                {
                    await _publisher.Publish(domainEvent, PublishStrategy.ParallelNoWait);
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

