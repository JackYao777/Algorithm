using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.JWT鉴权服务.Dtos;

namespace WebApplication1.JWT鉴权服务.Context
{
    //迁移指令:https://blog.csdn.net/m0_66746443/article/details/124002496
    //Add-Migration initial -outputdir JWT鉴权服务\Migrations
    //update-database
    public class JwtDemoDbContext : DbContext
    {
        private string _connectString;

        public DbSet<Account> Accounts { get; set; }

        public JwtDemoDbContext(DbContextOptions<JwtDemoDbContext> options) : base(options)
        {

        }

        //public JwtDemoDbContext(string connectString)
        //{
        //    _connectString = connectString;
        //}
        //public JwtDemoDbContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!string.IsNullOrEmpty(_connectString))
        //    {
        //        optionsBuilder.UseMySQL(_connectString);
        //    }
        //}
    }
}
