using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAO
{
    public class ProdutoDAO
    {
        public IList<Produto> Lista()
        {
            using (var context = new DBEstoque())
            {
                return context.Produtos.ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var context = new DBEstoque())
            {
                return context.Produtos.Find(id);
            }
        }

        public void Adiciona(Produto produto)
        {
            using (var context = new DBEstoque())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var context = new DBEstoque())
            {
                context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Deleta(Produto produto)
        {
            using (var context = new DBEstoque())
            {
                context.Entry(produto).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}