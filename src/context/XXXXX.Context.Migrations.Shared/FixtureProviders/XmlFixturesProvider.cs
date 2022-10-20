
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace XXXXX.Context.Migrations.Shared
{
    public class XmlFixturesProvider<T>
    {
        private XmlSerializer _serializer;
        private string _fixtureDirectory;
        private string FilePath => Path.Join(_fixtureDirectory, $"{typeof(T).Name.ToLower()}.xml");


        public XmlFixturesProvider(string fixtureDirectory)
        {
            _fixtureDirectory = fixtureDirectory;

            XmlAttributeOverrides overrides = new XmlAttributeOverrides();

            foreach (var property in typeof(T).GetProperties())
            {
                if (
                    property.PropertyType.IsPrimitive ||
                    property.PropertyType == typeof(Decimal) ||
                    property.PropertyType == typeof(String) ||
                    property.PropertyType == typeof(Guid)
                )
                {
                    overrides.Add(typeof(T), property.Name, new XmlAttributes { XmlAttribute = new XmlAttributeAttribute() });
                }
                else
                {
                    overrides.Add(typeof(T), property.Name, new XmlAttributes { XmlIgnore = true });
                }
            }

            _serializer = new XmlSerializer(typeof(List<T>), overrides);
        }

        public XmlFixturesProvider(string fixtureDirectory, XmlAttributeOverrides overrides)
        {
            _fixtureDirectory = fixtureDirectory;
            _serializer = new XmlSerializer(typeof(List<T>), overrides);
        }

        public IEnumerable<T> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                Console.Error.WriteLine($"Unable to find file {FilePath}");
                return Enumerable.Empty<T>();
            };

            using var stream = File.OpenRead(FilePath);
            return (List<T>)_serializer.Deserialize(stream);
        }

        public void Persist(IEnumerable<T> fixtures)
        {
            if (!Directory.Exists(_fixtureDirectory))
                Directory.CreateDirectory(_fixtureDirectory);

            if (fixtures.Any())
            {
                using var stream = File.Open(FilePath, FileMode.Create);
                _serializer.Serialize(stream, fixtures.ToList());
            }
        }
    }
}