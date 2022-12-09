using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAO
{
    public class UsuarioDAO
    {
        public IList<Usuario> Lista()
        {
            using(var context=new DBEstoque())
            {
                return context.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using(var context=new DBEstoque())
            {
                return context.Usuarios.Find(id);
            }
        }

        public void Adiciona(Usuario usuario)
        {
            using(var context=new DBEstoque())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using(var context=new DBEstoque())
            {
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Deleta(Usuario usuario)
        {
            using(var context=new DBEstoque())
            {
                context.Entry(usuario).State=System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Usuario Login(string nome, string senha)
        {
            using(var context=new DBEstoque())
            {
                return context.Usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
            };
        }
    }
}