using Microsoft.Extensions.Caching.Memory;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.LocalizationRepos;
using SMSystem.Domain.Dtos;
using System.Globalization;

namespace SMSystem.Infrastructure.Localization
{
    public class DbLocalizationService : ILocalizationService
    {
        private readonly ILocalizationReadRepository _localizationReadRepository;
        private readonly ILocalizationWriteRepository _localizationWriteRepository;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKeyPrefix = "Localization_";

        public DbLocalizationService(ILocalizationReadRepository localizationReadRepository, ILocalizationWriteRepository localizationWriteRepository, IMemoryCache memoryCache)
        {
            _localizationReadRepository = localizationReadRepository;
            _localizationWriteRepository = localizationWriteRepository;
            _memoryCache = memoryCache;
        }

        private string GetCacheKey(string key, CultureInfo culture = null)
        {
            return $"{CacheKeyPrefix}{key}_{(culture ?? CultureInfo.CurrentCulture).Name}";
        }

        public string GetLocalizedString(string key)
        {
            return GetLocalizedString(key, CultureInfo.CurrentCulture);
        }

        public string GetLocalizedString(string key, CultureInfo culture)
        {
            string cacheKey = GetCacheKey(key, culture);
            var localization = _memoryCache
                .GetOrCreate(cacheKey, entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                    return _localizationReadRepository.GetAsync(x => x.ResourceKey == key && x.CultureCode == culture.Name).GetAwaiter().GetResult();
                });
            return localization?.ResourceValue ?? cacheKey;
        }

        public bool AddLocalizeString(string key, List<LocalizedStringDto> languageAndValues)
        {
            var nameKeyValuePairs = languageAndValues
                .Select(ln => new KeyValuePair<string, string>(ln.CultureCode, ln.Value))
                .ToArray();
            return AddLocalizeString(key, nameKeyValuePairs);
        }

        public bool AddLocalizeString(string key, params KeyValuePair<string, string>[] languageAndValues)
        {
            if (languageAndValues == null || languageAndValues.Length == 0)
                return false;

            bool result = true;
            foreach (var pair in languageAndValues)
            {
                string cultureCode = pair.Key;
                string resourceValue = pair.Value;

                var localization = _localizationReadRepository.GetAsync(x => x.ResourceKey == key && x.CultureCode == cultureCode).GetAwaiter().GetResult();

                if (localization == null)
                {
                    localization = new Domain.Entities.Localization
                    {
                        ResourceKey = key,
                        CultureCode = cultureCode,
                        ResourceValue = resourceValue
                    };

                    result = result && _localizationWriteRepository.AddAsync(localization).GetAwaiter().GetResult();
                }
                else
                {
                    localization.ResourceValue = resourceValue;
                    result = result && _localizationWriteRepository.Update(localization);
                }

                string cacheKey = GetCacheKey(key, new CultureInfo(cultureCode));
                _memoryCache.Remove(cacheKey);
            }

            result = result && (_localizationWriteRepository.SaveAsync().GetAwaiter().GetResult() > 0);

            return result;
        }

        public async Task<bool> AddLocalizeStringAsync(string key, List<LocalizedStringDto> languageAndValues)
        {
            var nameKeyValuePairs = languageAndValues
                .Select(ln => new KeyValuePair<string, string>(ln.CultureCode, ln.Value))
                .ToArray();
            return await AddLocalizeStringAsync(key, nameKeyValuePairs);
        }

        public async Task<bool> AddLocalizeStringAsync(string key, params KeyValuePair<string, string>[] languageAndValues)
        {
            if (languageAndValues == null || languageAndValues.Length == 0)
                return false;

            bool result = true;
            foreach (var pair in languageAndValues)
            {
                string cultureCode = pair.Key;
                string resourceValue = pair.Value;

                var localization = await _localizationReadRepository.GetAsync(x => x.ResourceKey == key && x.CultureCode == cultureCode);

                if (localization == null)
                {
                    localization = new Domain.Entities.Localization
                    {
                        ResourceKey = key,
                        CultureCode = cultureCode,
                        ResourceValue = resourceValue
                    };

                    result = result && await _localizationWriteRepository.AddAsync(localization);
                }
                else
                {
                    localization.ResourceValue = resourceValue;
                    result = result && _localizationWriteRepository.Update(localization);
                }

                string cacheKey = GetCacheKey(key, new CultureInfo(cultureCode));
                _memoryCache.Remove(cacheKey);
            }

            result = result && (await _localizationWriteRepository.SaveAsync() > 0);

            return result;
        }


    }
}