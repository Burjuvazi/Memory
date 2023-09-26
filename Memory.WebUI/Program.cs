using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Memory.Business.AutoMapper;
using Memory.Business.DependencyResolvers;
using Memory.DataAccess.Concrete.EntityFrameWork.Context;
using Memory.Entities.Concrete;
using Memory.WebUI.BasketTransaction;
using Memory.WebUI.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




//AUTOFAC
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BusinessModule()));

//MAPPER
MapperConfiguration mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

//IDENTITY
builder.Services.AddIdentity<AppIdentityUser,AppIdentityRole>().AddEntityFrameworkStores<MemoryContext>();

//CONTEXT
builder.Services.AddDbContext<MemoryContext>();
builder.Services.AddTransient<IBasketTransaction, BasketTransaction>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //Kimlik Doðrulama

app.UseAuthorization(); //Yetki Doðrulama

//app.UseMiddleware<LoginMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=Index}/{id?}");

app.Run();
