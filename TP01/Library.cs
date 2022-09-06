using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    class Library
    {
        private List<Book> _books;

        public Library(params Book[] books)
        {
            _books=books.ToList();
        }

        public IEnumerable<Book> Books
        {
            get { return _books; }
        }

        public Book buscaLivroNome(string nome)
        {
            foreach (var livro in Books)
                if (livro.getName() == nome) { return livro; }
            return null;
        }

        public override string ToString()
        {
           var linhas=new StringBuilder();
            foreach (var book in Books)
            {
                linhas.AppendLine(book.ToString());
            }
            return linhas.ToString();
        }
    }
}
