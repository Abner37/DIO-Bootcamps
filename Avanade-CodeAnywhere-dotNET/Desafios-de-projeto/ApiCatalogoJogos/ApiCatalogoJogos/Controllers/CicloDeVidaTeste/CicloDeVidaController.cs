using ApiCatalogoJogos.Controllers.CicloDeVidaTeste.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.CicloDeVidaTeste
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloDeVidaController : ControllerBase
    {
        private readonly IExemploSingleton _exemploSingleton1;
        private readonly IExemploSingleton _exemploSingleton2;

        private readonly IExemploScoped _exemploScoped1;
        private readonly IExemploScoped _exemploScoped2;

        private readonly IExemploTransient _exemploTransient1;
        private readonly IExemploTransient _exemploTransient2;


        public CicloDeVidaController(
            IExemploSingleton exemploSingleton1,
            IExemploSingleton exemploSingleton2,
            IExemploScoped exemploScoped1,
            IExemploScoped exemploScoped2,
            IExemploTransient exemploTransient1,
            IExemploTransient exemploTransient2
            )
        {
            _exemploSingleton1 = exemploSingleton1;
            _exemploSingleton2 = exemploSingleton2;

            _exemploScoped1 = exemploScoped1;
            _exemploScoped2 = exemploScoped2;

            _exemploTransient1 = exemploTransient1;
            _exemploTransient2 = exemploTransient2;
        }


        [HttpGet]
        public Task<string> Get()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Singleton 1: {_exemploSingleton1.Id}");
            sb.AppendLine($"Singleton 2: {_exemploSingleton2.Id}");
            sb.AppendLine();
            sb.AppendLine($"Scoped 1: {_exemploScoped1.Id}");
            sb.AppendLine($"Scoped 2: {_exemploScoped2.Id}");
            sb.AppendLine();
            sb.AppendLine($"Transient 1: {_exemploTransient1.Id}");
            sb.AppendLine($"Transient 2: {_exemploTransient2.Id}");

            return Task.FromResult(sb.ToString());
        }
    }
}
