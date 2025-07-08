using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace MHerreraProgreso3.Services
{
    class LoggerService
    {
        private readonly string _logPath;
        public LoggerService()
        {
            _logPath = Path.Combine(FileSystem.AppDataDirectory,"log.txt");
        }
        public async Task RegistrarAccionAsync(String mensaje)
        {
            string log = $"{DateTime.Now}:{mensaje}{Environment.NewLine}";
            await File.AppendAllTextAsync(_logPath, log);
        }
    }
}
