﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using MvcSwaggerClient.Models;
using Newtonsoft.Json.Linq;

namespace MvcSwaggerClient.Models
{
    public static partial class TitleCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<Title> DeserializeJson(JToken inputObject)
        {
            IList<Title> deserializedObject = new List<Title>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                Title title = new Title();
                title.DeserializeJson(iListValue);
                deserializedObject.Add(title);
            }
            return deserializedObject;
        }
    }
}
