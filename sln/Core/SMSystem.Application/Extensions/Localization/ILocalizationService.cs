using SMSystem.Domain.Dtos;
using System.Globalization;

namespace SMSystem.Application.Extensions.Localization
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key);

        string GetLocalizedString(string key, CultureInfo culture);

        bool AddLocalizeString(string key, List<LocalizedStringDto> languageAndValues);

        bool AddLocalizeString(string key, params KeyValuePair<string, string>[] languageAndValues);

        Task<bool> AddLocalizeStringAsync(string key, List<LocalizedStringDto> languageAndValues);

        Task<bool> AddLocalizeStringAsync(string key, params KeyValuePair<string, string>[] languageAndValues);
    }
}