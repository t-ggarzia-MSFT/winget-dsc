// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation.Collections;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static System.Net.Mime.MediaTypeNames;

namespace dscui.Models;
public class ConfigurationUnitModel
{
    public string Type { get; set; } = "";
    public ValueSet Settings { get; set; } = new();
    public Boolean ElevatedRequired { get; set; } = false;

    public string ToYaml()
    {

        var resource = new Dictionary<string, object>
        {
            ["properties"] = new Dictionary<string, object>
            {
                ["resources"] = new List<Dictionary<string, object>>
                 {
                     new Dictionary<string, object>
                     {
                        ["resource"] = Type,
                        ["settings"] = Settings
                     }
                 }
            }
        };

        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        string yaml = serializer.Serialize(resource);
        return yaml;
    }
    public void FromYaml(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var resource = deserializer.Deserialize<Dictionary<string, object>>(yaml);
        try
        {
            var dict = (((resource["properties"] as Dictionary<object, object>)["resources"] as List<object>)[0] as Dictionary<object, object>);
            Type = dict["resource"] as string;


            Settings = new ValueSet();

            FromYamlHelper(Settings, dict["settings"] as Dictionary<object, object>);
            //foreach (var kvp in dict["settings"] as Dictionary<object, object>)
            //{
            //    if (kvp.Value is string)
            //    {
            //        object result = kvp.Value as string;
            //        if (bool.TryParse(kvp.Value as string, out bool b))
            //        {
            //            result = b;
            //        }
            //        else if (double.TryParse(kvp.Value as string, NumberStyles.Float, CultureInfo.InvariantCulture, out double d))
            //        {
            //            result = d;
            //        }

            //        Settings[kvp.Key as string] = result;
            //    }
            //    else if (kvp.Value is Dictionary<object, object> subDict)
            //    {
            //        var subSettings = new ValueSet();
            //        FromYamlHelper(subSettings, subDict);
            //        Settings[kvp.Key as string] = subSettings;
            //    }
            //}
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error deserializing YAML: {ex.Message}");
        }
    }
    private void FromYamlHelper(ValueSet settings, Dictionary<object, object> dict)
    {
        foreach (var kvp in dict)
        {
            if (kvp.Value is string)
            {
                object result = kvp.Value as string;
                if (bool.TryParse(kvp.Value as string, out bool b))
                {
                    result = b;
                }
                else if (double.TryParse(kvp.Value as string, NumberStyles.Float, CultureInfo.InvariantCulture, out double d))
                {
                    result = d;
                }

                settings[kvp.Key as string] = result;
            }
            else if (kvp.Value is Dictionary<object, object> subDict)
            {
                var subSettings = new ValueSet();
                FromYamlHelper(subSettings, subDict);
                settings[kvp.Key as string] = subSettings;
            }
        }
    }
}
