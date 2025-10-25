using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using APPUCENM.Models;

namespace APPUCENM.Controllers
{
    public class PersonasController
    {
        readonly SQLiteAsyncConnection _connection;


        // Constructor
        public PersonasController()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBUCENM.db3"), extensiones);

            _connection.CreateTableAsync<Personas>();

        }

        // CRUD - DML

        // CREATE  - UPDATE
        public async Task<int> GuardarPersona(Models.Personas personas)
        {
            if (personas.Id == 0)
            {
                return await _connection.InsertAsync(personas);
            }
            else 
            {
                return await _connection.UpdateAsync(personas);
            }
        }


        // GET
        public async Task<List<Models.Personas>> GetListaPersonas() 
        {
            return await _connection.Table<Models.Personas>().ToListAsync();
        }

        //GET
        public async Task<Models.Personas> GetPersona(int pid)
        {
            return await _connection.Table<Models.Personas>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        //DELETE
        public async Task<int> EliminarPersona(Models.Personas personas)
        {
            return await _connection.DeleteAsync(personas);
        }

    }
}
