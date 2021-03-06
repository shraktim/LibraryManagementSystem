﻿using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.BLL.Contract;
using LibraryManagementSystem.BLL.Manager;
using LibraryManagementSystem.DbContext.AppDbContext;
using LibraryManagementSystem.Models.EntityModels;
using LibraryManagementSystem.Repositories.Contract;
using LibraryManagementSystem.Repositories.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.AppConfigure.AppConfigure
{
   public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ApplicationDbContext"),
                b => b.MigrationsAssembly("LibraryManagementSystem.DbContext")));

            services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();
            services.AddTransient<IBookCategoryManager, BookCategoryManager>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookManager, BookManager>();
            services.AddTransient<IAuthorManager,AuthorManager>();
            services.AddTransient<IAuthorRepository,AuthorRepository>();
            services.AddTransient<IIssueManager,IssueManager>();
            services.AddTransient<IIssueRepository,IssueRepository>();
            services.AddTransient<ILanguageManager,LanguageManager>();
            services.AddTransient<ILanguageRepository,LanguageRepository>();
            services.AddTransient<IMemberManager,MemberManager>();
            services.AddTransient<IMemberRepository,MemberRepository>();
            services.AddTransient<IPublisherManager,PublisherManager>();
            services.AddTransient<IPublisherRepository,PublisherRepository>();
            services.AddTransient<IReturnManager,ReturnManager>();
            services.AddTransient<IReturnRepository,ReturnRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

    }
}
