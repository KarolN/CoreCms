using System;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Common.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreCms.Cms.Editor.WebApi.JsonConverters
{
    public class EditablePropertyJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jObject = JObject.Load(reader);

            var fullTypeString = jObject[nameof(EditableProperty.FullTypeName).ToLowerCaseFirstLetter()].Value<string>();
            var type = Type.GetType(fullTypeString);
            var deserializedObject = serializer.Deserialize(jObject[nameof(EditableProperty.Value).ToLowerCaseFirstLetter()].CreateReader(), type);

            var editableProperty = new EditableProperty
            {
                Name = jObject[nameof(EditableProperty.Name).ToLowerCaseFirstLetter()].Value<string>(),
                Value = deserializedObject,
                FullTypeName = fullTypeString,
                Type = jObject[nameof(EditableProperty.Type).ToLowerCaseFirstLetter()].Value<string>()
            };
            return editableProperty;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EditableProperty);
        }
    }
}