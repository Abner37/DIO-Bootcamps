using System;

namespace ApiCatalogoJogos.Controllers.CicloDeVidaTeste.Services
{
    public interface IExemploGeral
    {
        public Guid Id { get; }
    }

    public interface IExemploSingleton : IExemploGeral
    { }
    public interface IExemploScoped : IExemploGeral
    { }
    public interface IExemploTransient : IExemploGeral
    { }
}
