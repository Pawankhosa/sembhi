using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Admin2.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext() : base("dbcontext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext, Sembhi.Migrations.Configuration>("dbcontext"));
        }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.slider> sliders { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.News> News { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Campuslife> Campuslives { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Tour> Tours { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Pages> Pages { get; set; }

        

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Gallery> Galleries { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<LLRM.Areas.Auth.Models.Service> Services { get; set; }
    }
}