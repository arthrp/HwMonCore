using HwMonCore.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwMonCoreConsole
{
    public class InMemorySettings : ISettings
    {
        private readonly Dictionary<string, string> _settings = new Dictionary<string, string>();

        public bool Contains(string name)
        {
            return _settings.ContainsKey(name);
        }

        public string GetValue(string name, string value)
        {
            if (!_settings.ContainsKey(name))
                return value;

            return _settings[name];
        }

        public void Remove(string name)
        {
            _settings.Remove(name);
        }

        public void SetValue(string name, string value)
        {
            _settings[name] = value;
        }
    }
}
