using System;
using System.Collections.Generic;
using System.Text;
using ClickOficina.Data;
using ClickOficina.Model;
using SQLite;
using Xamarin.Forms;

namespace ClickOficina.Repository
{
    public class UsuarioRepository
    {
        private static SQLiteConnection database;
        private static readonly UsuarioRepository instance = new UsuarioRepository();
        public static UsuarioRepository Instance
        {
            get
            {
                if (database == null)
                {
                    database = DependencyService.Get<ClickOficinaDB>().GetConexao();
                    database.CreateTable<Usuario>();
                }
                return instance;
            }
        }

        static object locker = new object();

        public static int Salvar(Usuario usuario)
        {
            lock (locker)
            {
                return database.Insert(usuario);
            }
        }

        public static Usuario GetUsuario(string email)
        {
            lock (locker)
            {
                return database.Table<Usuario>().Where(c => c.email == email).FirstOrDefault();
            }
        }


    }
}
