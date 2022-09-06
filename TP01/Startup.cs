using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder=new RouteBuilder(app);
            builder.MapRoute("Livro/Nome/{name}", NomeLivro);
            builder.MapRoute("Livro/Descricao/{name}", DescricaoLivro);
            builder.MapRoute("Livro/Autores/{name}", NomesAutores);
            builder.MapRoute("Livro/ApresentarLivro",ApresentarLivro);

            var rotas = builder.Build();
            app.UseRouter(rotas);
            //app.UseRouter(Roteamento);
        }

        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livro/Nome/{name}", NomeLivro },
                {"/Livro/Descricao/{name}",DescricaoLivro},
                {"/Livro/Autores/{name}", NomesAutores },
                { "Livro/ApresentarLivro",ApresentarLivro}
            };
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente");
        }

        public Task NomeLivro(HttpContext context)
        {
            try
            {
                var _repo = new LivroRepositorioCSV();
                var bookname = context.GetRouteValue("name").ToString();
                var retorno = _repo.Library.buscaLivroNome(bookname).getName();
                return context.Response.WriteAsync(retorno);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }

        public Task DescricaoLivro (HttpContext context)
        {
            try
            {
                var _repo = new LivroRepositorioCSV();
                var bookname = context.GetRouteValue("name").ToString();
                var retorno = _repo.Library.buscaLivroNome(bookname).ToString();
                return context.Response.WriteAsync(retorno);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }

        public Task NomesAutores(HttpContext context)
        {
            try
            {
                var _repo = new LivroRepositorioCSV();
                var bookname = context.GetRouteValue("name").ToString();
                var retorno = _repo.Library.buscaLivroNome(bookname).getAuthorNames();
                return context.Response.WriteAsync(retorno);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }

        public Task ApresentarLivro(HttpContext context)
        {
            try
            {
                var _repo = new LivroRepositorioCSV();
                return context.Response.WriteAsync(_repo.Library.ToString());
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }
    }
}
