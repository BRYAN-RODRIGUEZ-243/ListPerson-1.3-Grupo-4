using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListPerson_1._3_Grupo__4.Models;
using SQLite;

namespace ListPerson_1._3_Grupo__4.Controllers
{
    public class PersonasControllers
    {
        SQLiteAsyncConnection _connection;
       
        //Constructor Vacio
        public PersonasControllers() { }

        //Conexion a la base de datos
       public async Task Init()
            
        {
            if(_connection is not null)
            {
                return;
            }

            SQLiteOpenFlags extenciones = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPersonas"), extenciones);
            var creacion = await _connection.CreateTableAsync<Personas>();

        }
        //METODOS CRUD
        //CREAR
        public async Task<int> StorePerson(Personas personas)
        {
            await Init();
            if (personas.Id == 0)
            {
                return await _connection.InsertAsync(personas);
            }
            else
            {
                return await _connection.UpdateAsync(personas);
            }
        }

    }
}
