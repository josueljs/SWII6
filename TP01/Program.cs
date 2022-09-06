using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace TP01
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();
            
            Console.WriteLine("Executando o método ToString");
            Console.WriteLine();
            Console.WriteLine(_repo.Library.ToString());
            Console.WriteLine("||||||||");
            Console.WriteLine();

            Console.WriteLine("Executando o método getAuthorNames");
            foreach(var Book in _repo.Library.Books)
            {
                Console.WriteLine($"Título: {Book.getName()}");
                Console.WriteLine(Book.getAuthorNames());
                Console.WriteLine("");
            }
            Console.WriteLine("||||||||");
            Console.WriteLine();

            IWebHost host = new WebHostBuilder()
            .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
