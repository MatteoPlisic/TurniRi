using System.Globalization;
using System.Resources;
using TurniRi.Application.DTOs;
using TurniRi.Application.Interfaces;
using TurniRi.Infrastructure.Resources.ProjectResources;

namespace TurniRi.Infrastructure.Resources.Services
{
    public class Translator : ITranslator
    {

        private readonly ResourceManager resourceMessages = new(typeof(ResourceMessages).FullName, typeof(ResourceMessages).Assembly);
        private readonly ResourceManager resourceGeneral = new(typeof(ResourceGeneral).FullName, typeof(ResourceGeneral).Assembly);

        public string this[string name] => resourceGeneral.GetString(name, CultureInfo.CurrentCulture) ?? name;

        public string GetString(string name)
        {
            return resourceMessages.GetString(name, CultureInfo.CurrentCulture) ?? name;
        }

        public string GetString(TranslatorMessageDto input)
        {
            var value = resourceMessages.GetString(input.Text, CultureInfo.CurrentCulture) ?? input.Text.Replace("_", " ");
            return string.Format(value, input.Args);
        }
    }
}
