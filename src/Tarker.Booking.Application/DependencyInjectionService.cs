using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;


namespace Tarker.Booking.Application;
public static class DependencyInjectionService
{
    /// <summary>
    /// Configura y registra los servicios de la aplicación en el contenedor de dependencias.
    /// </summary>
    /// <param name="services">Colección de servicios donde se registrarán las dependencias</param>
    /// <returns>La colección de servicios configurada</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile(new MapperProfile());
        });

        // Registra el AutoMapper como un servicio singleton
        // Singleton: Se crea una única instancia que se reutiliza durante toda la vida de la aplicación
        services.AddSingleton(mapper.CreateMapper());

        // Registra los comandos de usuario como servicios transient
        // Transient: Se crea una nueva instancia cada vez que se solicita el servicio
        // Esto asegura que cada operación tenga su propia instancia limpia del comando

        // Comando para crear usuarios
        services.AddTransient<ICreateUserCommand, CreateUserCommand>();

        // Comando para actualizar usuarios
        services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();

        // Comando para eliminar usuarios
        services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();

        return services;
    }
}