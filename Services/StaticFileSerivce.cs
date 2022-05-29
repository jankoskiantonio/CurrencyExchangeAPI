
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI.Services
{
    public class StaticFileService
    {
        private readonly Assembly _assembly;
        public StaticFileService()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _cache = new();

        }

        private readonly Dictionary<string, byte[]> _cache;

        public async Task<Stream> GetFile(string name)
        {
            if (_cache.ContainsKey(name))
            {
                return new MemoryStream(_cache[name]);
            }
            else
            {
                var memoryStream = new MemoryStream();
                await using var stream = _assembly.GetManifestResourceStream("CurrencyExchangeAPI." + name);
                await stream.CopyToAsync(memoryStream);
                await memoryStream.FlushAsync();
                _cache.Add(name, memoryStream.ToArray());
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    }
}