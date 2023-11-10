using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ColaboradorRepository : Master, IColaboradorRepository
    {
        public async Task<Colaborador> GetByCedula(string cedula)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT Cedula,Nombre,Apellidos,Estado 
                                        FROM Colaboradors
                                        WHERE Cedula = @Cedula";
                    cmd.Parameters.Add("@Cedula", SqlDbType.NVarChar).Value = cedula;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Colaborador()
                            {
                                Cedula = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                Apellidos = reader.GetString(2),
                                Estado = reader.GetString(3)
                            };
                        }
                    }
                }

                return null;
            }
        }

        public async Task Add(Colaborador colaborador)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO Colaboradors(Cedula,Nombre,Apellidos,FechaRegistro,Estado)
                                        VALUES(@Cedula,@Nombre,@Apellidos,@FechaRegistro,@Estado)";
                    cmd.Parameters.Add("@Cedula", SqlDbType.NVarChar, 128).Value = colaborador.Cedula;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = colaborador.Nombre;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 80).Value = colaborador.Apellidos;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = colaborador.Estado;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
