using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Common.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StructureMap;

namespace CoreCms.Cms.Editor.WebApi.JsonConverters
{
    public class ContentReferenceJsonConverter : JsonConverter
    {
        private readonly IContainer _container;
        private Dictionary<string, Type> _contentReferenceTypesRegistry;

        public ContentReferenceJsonConverter(IContainer container)
        {
            _container = container;
        }
        
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (_contentReferenceTypesRegistry == null)
            {
                var descriptors = _container.GetInstance<List<ICmsModuleDescriptor>>();
                _contentReferenceTypesRegistry =
                    descriptors.ToDictionary(x => x.GetModuleName(), x => x.GetContentReferenceType());
            }
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jObject = JObject.Load(reader);
            var contentType = jObject[nameof(ContentReference.ContentType).ToLowerCaseFirstLetter()].Value<string>();
            
            var referenceType = _contentReferenceTypesRegistry[contentType];
            var reference = Activator.CreateInstance(referenceType);
            
            foreach (var propertyInfo in referenceType.GetProperties())
            {
                var modelProperty = jObject[propertyInfo.Name.ToLowerCaseFirstLetter()].Value<string>();
                if (modelProperty != null && propertyInfo.CanWrite)
                {
                    var type = propertyInfo.PropertyType;
                    var parseMethod = type.GetMethod("Parse");
                    if (parseMethod != null)
                    {
                        object parsed = parseMethod.Invoke(null, new object[] {modelProperty});
                        propertyInfo.SetValue(reference, parsed);
                    }
                    else
                    {
                        propertyInfo.SetValue(reference, Convert.ChangeType(modelProperty, type));
                    }
                }
            }

            return reference;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ContentReference).IsAssignableFrom(objectType);
        }
    }
}