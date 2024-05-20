using Blog.Domain.CategoryAgg.Repository;
using Blog.Domain.CommentAgg.Repository;
using Blog.Domain.PostAgg.Repository;
using Blog.Domain.RoleAgg.Repository;
using Blog.Domain.UserAgg.Repository;
using Blog.Infrastructure._Utilities.MediatR;
using Blog.Infrastructure.Persistent.Dapper;
using Blog.Infrastructure.Persistent.Ef;
using Blog.Infrastructure.Persistent.Ef.Category;
using Blog.Infrastructure.Persistent.Ef.Comment;
using Blog.Infrastructure.Persistent.Ef.Post;
using Blog.Infrastructure.Persistent.Ef.Role;
using Blog.Infrastructure.Persistent.Ef.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddSingleton<ICustomPublisher, CustomPublisher>();

            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}