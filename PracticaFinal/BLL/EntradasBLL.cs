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
    class EntradasBLL
    {

        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Entradas.Any(c => c.EntradaId == id);
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
        private static bool Insertar(Entradas Entrada)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entradas.Add(Entrada);
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
        private static bool Modificar(Entradas Entrada)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(Entrada).State = EntityState.Modified;
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
        public static bool Guardar(Entradas Entrada)
        {
            if (!Existe(Entrada.EntradaId))
            {
                return Insertar(Entrada);
            }
            else
            {
                return Modificar(Entrada);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var Entrada = contexto.Entradas.Find(id);

                if (Entrada != null)
                {
                    contexto.Entradas.Remove(Entrada);
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
        public static Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas Entrada;

            try
            {
                Entrada = contexto.Entradas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Entrada;
        }


        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> Entrada)
        {
            List<Entradas> lista = new List<Entradas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Entradas.Where(Entrada).ToList();
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
