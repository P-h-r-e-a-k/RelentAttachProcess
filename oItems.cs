using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace RelentAttachProcess
{
    class Items
    {
        public Item[] Quest;

        private XmlDocument doc;

        public Items(uint LBAVer)
        {
            string path;
            if(1 == LBAVer)
                path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\files\\lba1QuestOffsets.xml";
            else
                path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\files\\lba2MemoryLocations.xml";
            doc = new XmlDocument();
            doc.Load(path);

            loadQuests(doc.DocumentElement.SelectNodes("/quests/item"));
        }

        private void loadQuests(XmlNodeList nodes)
        {
            Quest = new Item[nodes.Count+40];
            int i = 0;
            for (; i < nodes.Count; i++)
            {
                Item x = new Item();
                
                x.name = nodes[i].SelectSingleNode("name").InnerText.Trim();
                string s = nodes[i].SelectSingleNode("memoryOffset").InnerText.Trim();
                x.memoryOffset = int.Parse(s, System.Globalization.NumberStyles.HexNumber);
                x.maxVal = ushort.Parse(nodes[i].SelectSingleNode("maxVal").InnerText.Trim());
                x.minVal = ushort.Parse(nodes[i].SelectSingleNode("minVal").InnerText.Trim());
                x.size = ushort.Parse(nodes[i].SelectSingleNode("size").InnerText.Trim());
                x.type = ushort.Parse(nodes[i].SelectSingleNode("type").InnerText.Trim());
                x.lbaVersion = ushort.Parse(nodes[i].SelectSingleNode("lbaVersion").InnerText.Trim());
                Quest[i] = x;
            }

            for(; i< Quest.Count(); i++)
            {
                Item x = new Item();

                x.memoryOffset = Quest[i-1].memoryOffset+1;
                x.maxVal = 1;
                x.minVal = 0;
                x.size = 1;
                x.type = 1;
                x.lbaVersion = 1;

                Quest[i] = x;
            }
        }
    }
}
