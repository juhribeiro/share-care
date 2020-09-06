using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ShareCare.App.Extensions
{
    public static class ModelStateExtensions
    {
        public static ModelStateDictionary SetModelErrors(this ModelStateDictionary dictionary, ModelStateDictionary keyValuePairs)
        {
            foreach (var dictionaryValue in keyValuePairs)
            {
                var messages = dictionaryValue.Value.Errors.Select(x => x.ErrorMessage);
                dictionary.TryAddModelError(dictionaryValue.Key, string.Join(",", messages));
            }

            return dictionary;
        }
    }
}
