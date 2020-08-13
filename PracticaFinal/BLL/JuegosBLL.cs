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
    class JuegosBLL
    {

        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Juegos.Any(c => c.JuegoId == id);
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
        private static bool Insertar(Juegos juegos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Juegos.Add(juegos);
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
        public static bool Modificar(Juegos juegos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(juegos).State = EntityState.Modified;
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
        public static bool Guardar(Juegos juegos)
        {
            if (!Existe(juegos.JuegoId))
            {
                return Insertar(juegos);
            }
            else
            {
                return Modificar(juegos);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var juegos = contexto.Juegos.Find(id);

                if (juegos != null)
                {
                    contexto.Juegos.Remove(juegos);
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
        public static Juegos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Juegos juegos;

            try
            {
                juegos = contexto.Juegos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return juegos;
        }


        public static List<Juegos> GetList(Expression<Func<Juegos, bool>> juegos)
        {
            List<Juegos> lista = new List<Juegos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Juegos.Where(juegos).ToList();
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

        public static List<Juegos> GetJuegos()
        {
            Contexto contexto = new Contexto();
            List<Juegos> vendedor = new List<Juegos>();

            try
            {
                vendedor = contexto.Juegos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vendedor;
        }


    }
}
