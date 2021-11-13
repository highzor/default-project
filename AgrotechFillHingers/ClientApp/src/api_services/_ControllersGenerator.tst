${
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        settings.OutputFilenameFactory = file => {

            var FinalFileName = file.Name.Replace("Controller", "");
            FinalFileName = FinalFileName.Replace(".cs", "");
            return $"{FinalFileName}.service.ts";
        };
    }

    string ServiceName(Class c) => c.Name.Replace("Controller", "Service");

    string ReturnType(Method m)
    {
        if (m.Type.Name == "IActionResult"){
            foreach (var a in m.Attributes)
            {
                if (a.name == "returnType")
                {
                    string type = string.Empty;
                    
                    bool isArray = a.Value.Contains("<");
                    string formattedType = a.Value.Replace("<", "").Replace(">", "").Replace("typeof(", "").Replace(")", ""); 
                    string[] ar;

                    ar = formattedType.Split('.');
                    type = ar[ar.Length - 1];

                    if (isArray)
                    {
                        type += "[]";
                    }   

                    if (type == "bool")
                    {
                        type = "boolean";
                    } 

                    if (type.StartsWith("int"))
                    {
                        type = type.Replace("int", "number");
                    } 

                    if (type.StartsWith("byte"))
                    {
                        type = type.Replace("byte", "number");
                    } 

                    if (type.StartsWith("?"))
                    {
                        type = type.Replace("?", " | null");
                    } 

                    return type;
                }
            }
            return "void";
        }

         return m.Type.Name;
    }

    string ImportsList(Class objClass)
    {
        List<string> ImportsTypes = new List<string>();
        List<string> ImportsOutput = new List<string>();

        var objMethods = objClass.Methods;
        foreach(Method objMethod in objMethods)
        {
            foreach(Parameter objParameter in objMethod.Parameters)
            {
                if (!objParameter.Type.IsPrimitive && objParameter.Type.OriginalName != "dynamic")
                {
                    if (!ImportsTypes.Contains(objParameter.Type.Name)) 
                    {
                        ImportsTypes.Add(objParameter.Type.Name);
                        ImportsOutput.Add($"import {{ { objParameter.Type.Name } }} from '../api_models/{objParameter.Type.Name}';");
                    }
                }
            }
            foreach(var a in objMethod.Attributes)
            {
                if (a.name == "returnType")
                {
                    string type = string.Empty;

                    string formattedType = a.Value.Replace("<", "").Replace(">", "").Replace("typeof(", "").Replace(")", "");
                    string[] ar;

                    ar = formattedType.Split('.');
                    type = ar[ar.Length - 1];

                    if (
                        !type.StartsWith("bool") && 
                        !type.StartsWith("byte") && 
                        !type.StartsWith("sbyte") && 
                        !type.StartsWith("char") && 
                        !type.StartsWith("decimal") && 
                        !type.StartsWith("double") && 
                        !type.StartsWith("float") && 
                        !type.StartsWith("int") && 
                        !type.StartsWith("uint") && 
                        !type.StartsWith("nint") && 
                        !type.StartsWith("nuint") && 
                        !type.StartsWith("long") && 
                        !type.StartsWith("ulong") && 
                        !type.StartsWith("short") && 
                        !type.StartsWith("ushort") && 
                        !type.StartsWith("object") && 
                        !type.StartsWith("dynamic") 
                       )
                    {
                        if (!ImportsTypes.Contains(type))
                        {
                            ImportsTypes.Add(type);
                            ImportsOutput.Add($"import {{ {type} }} from '../api_models/{type}';");
                        }
                    }
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

    string MethodFormat(Method objMethod)
    {
        if (objMethod.HttpMethod() == "get"){
            return $"<{ReturnType(objMethod)}>(_Url)";
        }

        if (objMethod.HttpMethod() == "post"){
            return $"(_Url, {objMethod.Parameters[0].name})";
        }

        if (objMethod.HttpMethod() == "put"){
           return $"(_Url, {objMethod.Parameters[1].name})";
        }

        if (objMethod.HttpMethod() == "delete"){
            return $"(_Url)";
        }

        return $"";
    }
}

// *** НЕ ИЗМЕНЯТЬ!!! ***
// * Автосгенерированный файл *
// *** НЕ ИЗМЕНЯТЬ!!! ***

import {httpClient} from '../helpers/HttpClient';
$Classes(c=> c.Namespace.StartsWith("AgrotechFillHingers.Backend.Controllers."))[
$ImportsList
class _$ServiceName {
$Methods[ $name = async ($Parameters[$name: $Type][, ]) => {
        // $HttpMethod: $Url
        var _Url = '$Url';
        const {data} = await httpClient.$HttpMethod$MethodFormat;
        return data;
    };
]}
export const $ServiceName = new _$ServiceName();] 