using Microsoft.EntityFrameworkCore;
using PracticaFinal.DAL;
using PracticaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PracticaFinal.BLL
{
    class AmigosBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Amigos.Any(c => c.AmigoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        //Metodo Insertar.
        private static bool Insertar(Amigos amigo)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Amigos.Add(amigo);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        //Metodo Modificar.
        private static bool Modificar(Amigos amigo)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(amigo).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        //Metodo Guardar.
        public static bool Guardar(Amigos amigo)
        {
            if (!Existe(amigo.AmigoId))
            {
                return Insertar(amigo);
            }
            else
            {
                return Modificar(amigo);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var amigo = contexto.Amigos.Find(id);

                if (amigo != null)
                {
                    contexto.Amigos.Remove(amigo);
                    key = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }


        //Metodo Buscar.
        public static Amigos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Amigos amigo;

            try
            {
                amigo = contexto.Amigos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return amigo;
        }


        public static List<Amigos> GetList(Expression<Func<Amigos, bool>> productos)
        {
            List<Amigos> lista = new List<Amigos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Amigos.Where(productos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
