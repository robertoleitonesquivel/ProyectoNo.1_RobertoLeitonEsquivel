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
    public class HerramientaRepository : Master, IHerramientaRepository
    {

        public async Task<Herramienta> GetHerramientas(int codigo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT Codigo,Nombre,Description 
                                        WHERE Codigo = @Codigo";
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Herramienta()
                            {
                                Codigo = reader.GetInt16(0),
                                Nombre = reader.GetString(1),
                                Description = reader.GetString(2),
                            };
                        }
                    }
                }

                return null;
            }
        }

        public async Task Prestar(List<PrestarHerramienta> prestarHerramientas)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    foreach (var prestamo in prestarHerramientas)
                    {
                        cmd.CommandText = @"INSERT INTO PrestarHerramientas(Cedula,Codigo,FechaPrestamo,FechaRegreso)
                                            VALUES(@Cedula,@Nombre,@Apellidos,@FechaRegistro,@Estado)";
                        cmd.Parameters.Add("@Cedula", SqlDbType.NVarChar, 128).Value = prestamo.Cedula;
                        cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = prestamo.Codigo;
                        cmd.Parameters.Add("@FechaPrestamo", SqlDbType.DateTime).Value = prestamo.FechaPrestamo;
                        cmd.Parameters.Add("@FechaRegreso", SqlDbType.DateTime).Value = prestamo.FechaRegreso;
                        await cmd.ExecuteNonQueryAsync();
                    }

                }
            }
        }

        public async Task Add(Herramienta herramienta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO Herramientas(Codigo,Nombre,Description)
                                        VALUES(@Codigo,@Nombre,@Description)";
                    cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 128).Value = herramienta.Codigo;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = herramienta.Nombre;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 80).Value = herramienta.Description;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
