using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();


builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EfArticleDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();


builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<IWriterDal, EfWriterDal>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

builder.Services.AddScoped<ITagService, TagManager>();
builder.Services.AddScoped<ITagDal, EfTagDal>();

builder.Services.AddScoped<IArticleTagService, ArticleTagManager>();
builder.Services.AddScoped<IArticleTagDal, EfArticleTagDal>();

builder.Services.AddDbContext<BlogContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>().AddErrorDescriber<CustomIdentityValidator>();



builder.Services.AddControllersWithViews();


//var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

//builder.Services.AddControllersWithViews(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
//});
//builder.Services.ConfigureApplicationCookie(opts =>
//{
//    opts.LoginPath = "/Login/Index";
//    opts.AccessDeniedPath = new PathString("/Login/AccessDeniedPath");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStatusCodePages(context =>
{
    var statusCode = context.HttpContext.Response.StatusCode;
    if (statusCode == 404)
    {
        context.HttpContext.Response.Redirect("/ErrorPage/Index?code=404");
    }
    else if (statusCode == 403)
    {
        context.HttpContext.Response.Redirect("/ErrorPage/Index2?code=403");
    }
    // Add more conditions for other status codes if needed
    else
    {
        context.HttpContext.Response.Redirect("/ErrorPage/GeneralError");
    }
    return Task.CompletedTask;
});



app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
