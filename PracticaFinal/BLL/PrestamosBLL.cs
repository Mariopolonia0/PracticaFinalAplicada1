using Microsoft.EntityFrameworkCore;
using PracticaFinal.DAL;
using PracticaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace PracticaFinal.BLL
{
    class PrestamosBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(c => c.PrestamoId == id);
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
        private static bool Insertar(Prestamos prestamo)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in prestamo.PrestamoDetalle)
                {
                    Juegos juegos = JuegosBLL.Buscar(item.JuegoId);
                    juegos.Existencia -= item.Cantidad;
                    JuegosBLL.Modificar(juegos);
                }

                contexto.Prestamos.Add(prestamo);
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
        private static bool Modificar(Prestamos prestamo)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in prestamo.PrestamoDetalle)
                {
                    Juegos juegos = JuegosBLL.Buscar(item.JuegoId);
                    juegos.Existencia -= item.Cantidad;
                    JuegosBLL.Modificar(juegos);
                }

                contexto.Entry(prestamo).State = EntityState.Modified;
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
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
            {
                return Insertar(prestamo);
            }
            else
            {
                return Modificar(prestamo);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);

                if (prestamo != null)
                {
                    contexto.Prestamos.Remove(prestamo);
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
        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }


        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> prestamo)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(prestamo).ToList();
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
        //el modificar detalle es para editar la existencia para restar los juegos epretado
        public static bool ModificarDetalle(Prestamos prestamo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {   //en este parte del codigo recorro la lista del datalle
                //y luegos busco el id del juego que agregue y modifico la
                //existencia y luego llamo la bll de jueogo y lo guardo
                foreach (var item in prestamo.PrestamoDetalle)
                {
                    Juegos juegos = JuegosBLL.Buscar(item.JuegoId);
                    juegos.Existencia -= item.Cantidad;
                    JuegosBLL.Modificar(juegos);
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
            return paso;
        }
    }
}
