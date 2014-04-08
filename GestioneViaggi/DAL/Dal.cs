using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.IO;
using System.Diagnostics;

namespace GestioneViaggi.DAL
{
    public class Dal
    {
        public static void ensureDb()
        {
            if (!File.Exists(App.Default.DBName))
            {
                SQLiteConnection.CreateFile(App.Default.DBName);
                _createTables();
            }
        }

        private static SQLiteConnection _connection = null;
        public static SQLiteConnection connection {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(String.Format("Data Source={0};Version=3",App.Default.DBName));
                }
                return _connection;
            }
        }

        private static Db _db = null;
        public static Db db
        {
            get
            {
                if (_db == null)
                {
                    _db = Db.Init(Dal.connection, 10);
                }
                return _db;
            }
        }

        private static void _createTables()
        {
            FileInfo creation = new FileInfo(App.Default.DBCreationSQL);
            if (!creation.Exists)
            {
                FileInfo dbfile = new FileInfo(App.Default.DBName);
                dbfile.Delete();
                throw new Exception(String.Format("{0} non esiste!", App.Default.DBCreationSQL));
            }
            StreamReader sr = creation.OpenText();
            String cmds = sr.ReadToEnd();
            Dal.connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(cmds, Dal.connection);
            cmd.ExecuteNonQuery();
            Dal.connection.Close();
        }
    }
}
