﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using CustomerApp.Infrastructure.Data;
using CustomerApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<MultigroupSpaceDbContext>(o => { });

            //services.AddScoped<IGroupSpaceProvider, GroupSpaceProvider>();
            // services.AddDbContext<CustomerAppContext>(option=>option.UseInMemoryDatabase("ThaDB")); //in memoryDB
            //services.AddEntityFrameworkSqlServer()
            //     .AddEntityFrameworkSqlServer()
            //     .AddDbContext<SqlServerApplicationDbContext>(options =>
            //     options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            //services.AddEntityFrameworkSqlite().AddDbContext<MultigroupSpaceDbContext>(options => options.UseSqlServer("Server=tcp:kaffeklub.database.windows.net,1433;Initial Catalog=KaffeKlubben;Persist Security Info=False;User ID=Kaffeklub;Password={Qwerty12!};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));


            services.AddEntityFrameworkSqlite().AddDbContext<CustomerAppContext>(options => options.UseSqlite("Data Source=customerApp.db"));
            services.AddEntityFrameworkSqlite().AddDbContext<MultigroupSpaceDbContext>(options => options.UseSqlite("Data Source=GroupSpace.db"));

            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<IFineService, FineService>();

            services.AddScoped<IFineTypeRepository, FineTypeRepository>();
            services.AddScoped<IFineTypeService, FineTypeService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("https://kaffeklubben-5fd40.firebaseapp.com", "http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //for in memorydb
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CustomerAppContext>();
                    DBseed.SeedDB(ctx);
                    var ctx1 = scope.ServiceProvider.GetService<MultigroupSpaceDbContext>();
                    SeedSpaces.SeedSpacesNow(ctx1);
                }
            }
            else
            {
                app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx1 = scope.ServiceProvider.GetService<MultigroupSpaceDbContext>();
                    SeedSpaces.SeedSpacesNow(ctx1);
                    var ctx = scope.ServiceProvider.GetService<CustomerAppContext>();
                    DBseed.SeedDB(ctx);
                }
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
