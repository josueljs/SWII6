using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    class Book
    {
        private String name;
        private Author[] authors;
        private double price;
        private int qty=0;

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string getName()
        {
            return name;
        }

        public Author[] getAuthors()
        {
            return authors;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double price)
        {
            this.price=price;
        }

        public int getQty()
        {
            return qty;
        }

        public void setQty(int qty)
        {
            this.qty=qty;
        }

        public override String ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Detalhes do livro");
            stringBuilder.AppendLine($"Título: {name}");
            stringBuilder.AppendLine("Autor(es)");
            foreach(Author author in authors)
            {
                stringBuilder.Append($"Autor: {author.Name} / ");
                stringBuilder.Append($"Email: {author.Email} / ");
                stringBuilder.AppendLine($"Gender: {author.Gender}");
            }
            stringBuilder.AppendLine($"Valor: R${price}");
            stringBuilder.AppendLine($"Quantidade disponível: {qty}");
            return stringBuilder.ToString();
        }

        public String getAuthorNames()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Autor(es): ");
            foreach(var author in authors)
            {
                stringBuilder.Append($"{author.Name}, ");
            }
            return stringBuilder.ToString().Substring(0, stringBuilder.Length-2);
        }
    }
}
