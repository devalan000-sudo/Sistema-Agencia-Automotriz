using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.Services;
using SistemaAgenciaAutomotriz.Dominio.Validators;
using SistemaAgenciaAutomotriz.Presentacion.Formularios;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;

namespace SistemaAgenciaAutomotriz.Presentacion;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);
        
        using var serviceProvider = services.BuildServiceProvider();
        
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SeedUsuarioAdmin(context);

        var loginForm = serviceProvider.GetRequiredService<FormLogin>();
        
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            var username = loginForm.Username;
            var password = loginForm.Password;
            
            var authService = serviceProvider.GetRequiredService<IAuthServicio>();
            var usuario = authService.ValidarLoginAsync(username, password).GetAwaiter().GetResult();
            
            if (usuario != null)
            {
                SesionActual.UsuarioLogueado = usuario;
                
                var mainForm = serviceProvider.GetRequiredService<FormPrincipal>();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SistemaAgenciaAutomotriz;Trusted_Connection=True;TrustServerCertificate=True"));
        
        services.AddSingleton<IVentaCalculadora, VentaCalculadora>();
        services.AddSingleton<IVentaDominio>(sp => new VentaDominio(sp.GetRequiredService<IVentaCalculadora>()));
        services.AddSingleton<IInventarioDominio>(sp => new InventarioDominio(sp.GetRequiredService<IVentaCalculadora>()));
        services.AddSingleton<ICuentaPorCobrarDominio, CuentaPorCobrarDominio>();
        
        services.AddSingleton<IValidador<Cliente>, ClienteValidador>();
        services.AddSingleton<IValidador<Vehiculo>, VehiculoValidador>();
        
        services.AddSingleton<IValidadorService, ValidadorService>();
        
        services.AddScoped<IAuthServicio, AuthServicio>();
        services.AddScoped<IUsuarioServicio, UsuarioServicio>();
        services.AddScoped<ICategoriaServicio, CategoriaServicio>();
        services.AddScoped<IProductoServicio, ProductoServicio>();
        services.AddScoped<IVehiculoServicio, VehiculoServicio>();
        services.AddScoped<IVentaServicio, VentaServicio>();
        services.AddScoped<IClienteServicio, ClienteServicio>();
        services.AddScoped<ICuentaPorCobrarServicio, CuentaPorCobrarServicio>();
        
        services.AddTransient<FormLogin>();
        services.AddTransient<FormPrincipal>();
    }

    static void SeedUsuarioAdmin(ApplicationDbContext context)
    {
        if (!context.Usuarios.Any(u => u.Username == "admin"))
        {
            var admin = new Usuario
            {
                Username = "admin",
                PasswordHash = "admin123",
                Nombre = "Administrador",
                Rol = RolUsuario.Admin,
                Activo = true,
                FechaAlta = DateTime.Now
            };
            context.Usuarios.Add(admin);
            context.SaveChanges();
        }
    }
}