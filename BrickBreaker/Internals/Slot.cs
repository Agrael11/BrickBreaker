using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BrickBreaker.Internals
{
    [Serializable]
    public class Slot
    {
        public int Level = 1;
        public int Score = 0;
        public int Lives = 3;
        public bool Used = false;

        public static Slot Load(string file)
        {
            if (File.Exists(file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Slot));
                StreamReader reader = new StreamReader(file);
                Slot slot = (Slot)serializer.Deserialize(reader);
                reader.Close();
                return slot;
            }
            else return new Slot();
        }

        public static void Save(string file, Slot slot)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Slot));
            StreamWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, slot);
            writer.Close();
        }
    }
}
