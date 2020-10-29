using Newtonsoft.Json;
using PineconeGames.Core.Patterns;
using PineconeGames.Core.Serializers;
using PineconeGames.CoreUnity.Serializers.Json.Newtonsoft.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PineconeGames.CoreUnity.Serializers.Json.Newtonsoft
{
    public class NewtonsoftSerializer : Singleton<NewtonsoftSerializer>, ISerializer
    {
        #region Variables

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            ContractResolver = new PrivateResolver(),
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
        };

        #endregion

        #region Public Functions

        public void AddConverters(params JsonConverter[] jsonConverters)
        {
            if (_settings.Converters == null)
            {
                _settings.Converters = new List<JsonConverter>();
            }

            AddConvertersToSettings(jsonConverters);
        }

        #endregion

        #region Private Functions

        private void AddConvertersToSettings(JsonConverter[] jsonConverters)
        {
            try
            {
                if (jsonConverters != null && jsonConverters.Any())
                {
                    for (int i = 0; i < jsonConverters.Length; i++)
                    {
                        JsonConverter currentJsonConverter = jsonConverters[i];

                        if (!_settings.Converters.Contains(currentJsonConverter))
                        {
                            _settings.Converters.Add(currentJsonConverter);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.LogError(string.Format("NewtonsoftSerializer.AddConvertersToSettings({0}) failed. Reason: {1}", jsonConverters, ex.Message));
            }
        }

        #endregion

        #region Serializer Functions

        public T Deserialize<T>(string serializedData) where T : class
        {
            T result = null;

            try
            {
                result = JsonConvert.DeserializeObject<T>(serializedData, _settings);
            }
            catch(Exception ex)
            {
                Debug.LogError(string.Format("NewtonsoftSerializer.Deserialize<{0}>({1}) failed. Reason: {2}", typeof(T).ToString(), serializedData, ex.Message));  
            }

            return result;
        }

        public string Serialize(object obj)
        {
            string result = string.Empty;

            try
            {
                result = JsonConvert.SerializeObject(obj, _settings);
            }
            catch(Exception ex)
            {
                Debug.LogError(string.Format("NewtonsoftSerializer.Serialize({0}): failed. Reason: {1}", obj, ex.Message));
            }

            return result;
        }

        #endregion
    }
} 