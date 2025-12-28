using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IJSONDataSource jsonSource = new JsonCompanyDataSource();  // Already JSON
            IJSONDataSource adaptedXmlSource = new XmlToJsonAdapter(new LegacyXmlCompanyDataSource());  // XML adapted to JSON

            var processor1 = new DataProcessor(jsonSource);
            processor1.Process();

            var processor2 = new DataProcessor(adaptedXmlSource);
            processor2.Process();
        }
    }

    // 🎯 Target interface - modern system expects JSON
    public interface IJSONDataSource
    {
        string GetJsonData();
    }

    // 🧱 Adaptee interface - legacy XML-based
    public interface IXMLDataSource
    {
        string GetXMLData();
    }

    // ✅ Modern JSON data source
    public class JsonCompanyDataSource : IJSONDataSource
    {
        public string GetJsonData()
        {
            return "JsonCompanyDataSource JSON Data";
        }
    }

    // ❌ Legacy XML data source (can't be modified)
    public class LegacyXmlCompanyDataSource : IXMLDataSource
    {
        public string GetXMLData()
        {
            return "LegacyXmlCompanyDataSource XML Data";
        }
    }

    // 🛠️ Adapter that mocks conversion from XML to JSON
    public class XmlToJsonAdapter : IJSONDataSource
    {
        private readonly IXMLDataSource _xmlSource;

        public XmlToJsonAdapter(IXMLDataSource xmlSource)
        {
            _xmlSource = xmlSource;
        }

        public string GetJsonData()
        {
            string xmlData = _xmlSource.GetXMLData();
            return ConvertXmlToJson(xmlData);
        }

        private string ConvertXmlToJson(string xmlData)
        {
            // 🔄 Mock conversion
            return xmlData.Replace("XML", "JSON");
        }
    }

    // 🧮 Client that only understands JSON data sources
    public class DataProcessor
    {
        private readonly IJSONDataSource _dataSource;

        public DataProcessor(IJSONDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Process()
        {
            string json = _dataSource.GetJsonData();
            Console.WriteLine("Processing JSON: " + json);
        }
    }
}
