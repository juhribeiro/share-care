using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareCare.Infra.Context
{
    public class ShareContextFactory : IDesignTimeDbContextFactory<ShareCareContext>
    {
        public ShareCareContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShareCareContext>();
            optionsBuilder.UseSqlServer("Server=tcp:megahacka.database.windows.net,1433;Initial Catalog=ShareCare;Persist Security Info=False;User ID=megahacka;Password=$02kahagame09;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ShareCareContext(optionsBuilder.Options);
        }
    }
}
