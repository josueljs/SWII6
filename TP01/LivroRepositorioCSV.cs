using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TP01
{
    class LivroRepositorioCSV:ILivroRepositorio
    {
        private static readonly string nomeArquivoCSV = "D:\\IFSP\\SWII6\\TP01\\books.csv";

        private Library _library;

        public LivroRepositorioCSV()
        {
            var arrayBooks=new List<Book>();

            using (var file = File.OpenText(LivroRepositorioCSV.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textoLivro=file.ReadLine();
                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }
                    var infoLivro=textoLivro.Split(';');
                    Author author1=new Author(infoLivro[1],infoLivro[2],char.Parse(infoLivro[3]));
                    Author author2 = new Author(infoLivro[4], infoLivro[5], char.Parse(infoLivro[6]));
                    Author[] authors = {author1,author2};
                    var livro = new Book(infoLivro[0], authors, Convert.ToDouble(infoLivro[7]), Convert.ToInt32(infoLivro[8]));
                    arrayBooks.Add(livro);
                }
            }

            _library = new Library(arrayBooks.ToArray());
        }

        public Library Library => _library;

        public IEnumerable<Book> All => _library.Books;
    }
}
