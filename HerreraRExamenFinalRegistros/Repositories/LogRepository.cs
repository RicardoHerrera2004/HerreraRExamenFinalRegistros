using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using HerreraRExamenFinalRegistros.Models;

namespace HerreraRExamenFinalRegistros.Repositories
{
    public static class LogRepository
    {
            private static readonly string _nombreArchivo = "Herrera_25:09_2004_Log.txt";
            
            private static string ObtenerRutaArchivo()
            {
                return Path.Combine(FileSystem.AppDataDirectory, _nombreArchivo);
            }
            
            public static async Task EscribirLogAsync(Proyecto Proyecto)
            {
                string linea = $"Se incluyó el registro {Proyecto.NombreProyecto} el {DateTime.Now:dd/MM/yyyy HH:mm}";
                string path = ObtenerRutaArchivo();

                using StreamWriter writer = File.AppendText(path);
                await writer.WriteLineAsync(linea);
            }

            public static async Task<List<Log>> LeerLogsAsync()
            {
                var logs = new List<Log>();
                string path = ObtenerRutaArchivo();

                if(File.Exists(path))
                {
                    string[] lineas = await File.ReadAllLinesAsync(path);
                    foreach (var linea in lineas)
                    {
                        var log = new Log { Descripcion = linea };
                        logs.Add(log);
                    }
                }
                return logs;
            }
        }
    }
