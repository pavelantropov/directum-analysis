using System.Xml;

namespace AnalysisApp;

public static class Task
{
    // Given function
    public static string Func1(string input, string elementName, string attrName)
    {
        string[] lines = System.IO.File.ReadAllLines(input);
        string result = null;

        foreach (var line in lines)
        {
            var startElEndex = line.IndexOf(elementName);

            if (startElEndex != -1)
            {
                // Много вложенных условий
                if (line[startElEndex - 1] == '<')
                {
                    var endElIndex = line.IndexOf('>', startElEndex - 1);

                    var attrStartIndex = line.IndexOf(attrName, startElEndex, endElIndex - startElEndex + 1);

                    if (attrStartIndex != -1)
                    {
                        int valueStartIndex = attrStartIndex + attrName.Length + 2;

                        while (line[valueStartIndex] != '"')
                        {
                            result += line[valueStartIndex];
                            valueStartIndex++;
                        }

                        break;
                    }
                }
            }
        }
        
        return result;
    }

    // Updated algorithm
    public static string? Func2(string input, string elementName, string attrName)
    {
        throw new NotImplementedException();
    }

    // Simple version
    public static string? Func3(string input, string elementName, string attrName)
    {
        var xml = File.ReadAllText(input);
        var doc = new XmlDocument();
        doc.LoadXml(xml);

        var element = doc.GetElementsByTagName(elementName);

        return element[0]?.Attributes?[attrName]?.Value;
    }
}