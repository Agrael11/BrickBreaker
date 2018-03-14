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
    public class Highscores
    {
        public List<int> Scores = new List<int>();
        public List<string> Names = new List<string>();

        public void Clean()
        {
            for (int i = 0; i < 10; i++)
            {
                Scores.Add(0);
                Names.Add("");
            }
        }

        public int TryPut(int score, string name)
        {
            int putInd = -1;
            for (int i = 9; i >= 0; i--)
            {
                if (Scores[i] <= score)
                {
                    putInd = i;
                }
            }
            if (putInd < 0) return -1;
            else return putInd;
        }

        public int Put(int score, string name)
        {
            int putInd = -1;
            for (int i = 9; i >= 0; i--)
            {
                if (Scores[i] <= score)
                {
                    putInd = i;
                }
            }
            if (putInd < 0) return -1;
            else
            {
                Scores.RemoveAt(9);
                Scores.Insert(putInd, score);
                Names.RemoveAt(9);
                Names.Insert(putInd, name);
                return putInd;
            }
        }

        public static Highscores Load(string file)
        {
            if (File.Exists(file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
                StreamReader reader = new StreamReader(file);
                Highscores scores = (Highscores)serializer.Deserialize(reader);
                reader.Close();
                return scores;
            }
            else
            {
                Highscores scores = new Internals.Highscores();
                scores.Clean();
                return scores;
            }
        }

        public static void Save(string file, Highscores scores)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
            StreamWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, scores);
            writer.Close();
        }
    }
}
