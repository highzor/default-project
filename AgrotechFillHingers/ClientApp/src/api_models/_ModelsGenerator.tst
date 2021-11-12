${
    using Typewriter.Extensions.Types;
   
    string TypeFormatted(Property property)
    {
        var type = property.Type;
        if (type.IsNullable)
        {
            return $"?";
        }
        else
        {
            return $"";
        }
    }

    string ImportsList(Class objClass)
    {
        List<string> ImportsTypes = new List<string>();
        List<string> ImportsOutput = new List<string>();

        var objProperties = objClass.Properties;
        foreach(Property prop in objProperties)
        {
             if (!prop.Type.IsPrimitive && prop.Type.Name.Replace("[]", "") != objClass.Name && !prop.Type.Name.Contains("any")) {
                var name = prop.Type.Name.Replace("[]", "");

                if (!ImportsTypes.Contains(prop.Type.Name))
                {
                    ImportsTypes.Add(prop.Type.Name);
                    ImportsOutput.Add($"import {{ { name } }} from '../api_models/{name}';");
                }
             }
        }
        
        if (ImportsOutput.Count > 0)
        {
            return String.Join( Environment.NewLine, ImportsOutput);
        }
        else
        {
            return "";
        }

    }
}

// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

$Classes(*Model)[
$ImportsList
export interface $Name {$Properties[
    $Name$TypeFormatted: $Type;]
}
]