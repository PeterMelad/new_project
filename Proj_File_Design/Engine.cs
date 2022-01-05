using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace Proj_File_Design
{
    class Engine
    {
        //mirna....(display categories for specific file)
        public List<string> specific_categories(string name)
        {
            List<string> ls = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load("File.xml");
            XmlNodeList node = doc.GetElementsByTagName("File");
            XmlNodeList innernode = node[0].ChildNodes;
            for (int i = 0; i < innernode.Count; i++)
            {
                XmlNodeList innod = innernode[i].ChildNodes;
                for (int j = 0; j < innod.Count; j++)
                {
                    XmlNodeList nls = innod[j].ChildNodes;
                   
                    if (nls[0].InnerText != name && j==0)
                    {
                        break;
                    }
                    if (j == 1) continue;
                   
                    if (nls[0].Name=="CategoryName")
                    {
                        ls.Add(nls[0].InnerText);
                        continue;
                    }
                }
            }
          
                return ls;
        }


        public List<string> innertext= new List<string>();
       
        //verena..(display keywords for specific category)
        public bool search(string input)
        {

            bool exi = false;
            XmlDocument doc = new XmlDocument();

            doc.Load("Categories.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("File");
      
                XmlNodeList child = elemList[0].ChildNodes;
               
                for (int i = 0; i < child.Count; i++)
                {
                    if (child[i].Name == input)
                    {
                        XmlNodeList nist = child[i].ChildNodes;
                        for (int j = 0; j < nist.Count; j++)
                        {
                            innertext.Add(nist[j].InnerText);
                        }
                            exi = true;
                      
                        break;
                    }
                }
            if (!exi) return false;
            else return true;
        }//end_func

        public Dictionary<string, List<string>> KeyWord = new Dictionary<string, List<string>>();
        public string File_name;
        public string File_path;
        public int counter;
       public List<string> Ca = new List<string>();
                               
        //shrooq
        public void Counter()
        {
            XmlDocument shrooq = new XmlDocument();

            //change the file name to file path..
            shrooq.Load("File.xml");
            XmlNodeList list = shrooq.GetElementsByTagName("File");

            XmlNodeList innerlis = list[0].ChildNodes;
            counter = innerlis.Count;
        }

        public void display(int m)
        {
       KeyWord=new Dictionary<string,List<string>>();
           
            Ca=new List<string>(); 
            XmlDocument shrooq = new XmlDocument();

                //change the file name to file path..
                shrooq.Load("File.xml");
                XmlNodeList list = shrooq.GetElementsByTagName("File");

                XmlNodeList innerlis = list[0].ChildNodes;
                   XmlNodeList file = innerlis[m].ChildNodes;
            for(int i=0;i<file.Count;i++){
                           if (i==0)
                           {
                               XmlNodeList nest = file[0].ChildNodes;
                               File_name = nest[0].InnerText;
                           }
                           else if (i == 1)
                           {
                               XmlNodeList nest = file[1].ChildNodes;
                               File_path= nest[0].InnerText;
                           }
                           else
                           {
                               List<string> Kkai = new List<string>();
                               XmlNodeList nest = file[i].ChildNodes;
                               string a=null;
                               for (int x = 0; x < nest.Count; x++)
                               {
                                   if (x == 0)
                                   {
                                     a = nest[x].InnerText;
                                       Ca.Add(a);
                                   }
                                   else
                                   {
                                       string q = nest[x].InnerText;
                                       Kkai.Add(q);
                                   }
                               }
                                   KeyWord.Add(a, Kkai);
                               
                            }//end_else
            }//end_for
                
           
        }//end_func

//--------
        //xml elements first
        XmlDocument doc = new XmlDocument();
        XmlNodeList list;
        
        Dictionary<string, List<string>> key = new Dictionary<string, List<string>>();
        List<string> keywords = new List<string>();

        string[] line;
        List<string[]> linelist = new List<string[]>();
        
       // Dictionary<string, List<int>> ckfound = new Dictionary<string, List<int>>();
       
    public void done(string n1,string n2){
        keywords.Add(n1);
        key.Add(n2, keywords);
        keywords = new List<string>();
    }
    public void ke(string n)
    {
        keywords.Add(n);
                  
    }


    public void WritIntoFile()
    {
        XmlDocument xmlDoc = new XmlDocument();
        if (!File.Exists("Categories.xml"))
        {
            XmlWriter Xwrite = XmlWriter.Create("Categories.xml");
            Xwrite.WriteStartDocument();
            Xwrite.WriteStartElement("File");
            for (int i = 0; i < key.Count; i++)
            {
                Xwrite.WriteStartElement(key.ElementAt(i).Key);
                for (int j = 0; j < key.ElementAt(i).Value.Count; j++)
                {
                   
                    Xwrite.WriteStartElement("keyword");
                    Xwrite.WriteValue(key.ElementAt(i).Value.ElementAt(j));
                    Xwrite.WriteEndElement();
                    Xwrite.WriteString("\r\n");
                }
                Xwrite.WriteEndElement();
            }
            Xwrite.WriteEndElement();
            Xwrite.WriteEndDocument();
            Xwrite.Close();
        }
        else
        {
            xmlDoc.Load("Categories.xml");
            for (int i = 0; i < key.Count; i++)
            {
                XmlElement element = xmlDoc.CreateElement(key.ElementAt(i).Key);
                for (int j = 0; j < key.ElementAt(i).Value.Count; j++)
                {
                    XmlElement ew = xmlDoc.CreateElement("keyword");
                    ew.InnerText = key.ElementAt(i).Value.ElementAt(j);
                    element.AppendChild(ew);
                    XmlElement node = xmlDoc.DocumentElement;
                    node.AppendChild(element);
                    xmlDoc.AppendChild(node);

                }
            }
            xmlDoc.Save("Categories.xml");
            
        }//end_else
    }//end_func

        //-------------------------------------------------------------------------------------
    public string filename;
    public string filepath;

        //call .....
    public void set_filename_path(string path,string name)
    {
        filepath = name;
        filename = path;
    }
    


      public Dictionary<string, List<int>> ckfound = new Dictionary<string, List<int>>();
    List<int> repeat = new List<int>();
    Dictionary<string, List<string>> filesort = new Dictionary<string, List<string>>();
   public static Dictionary<string, Dictionary<string, List<int>>> last = new Dictionary<string, Dictionary<string, List<int>>>();
        public void search()
    {
        filesort = new Dictionary<string, List<string>>();
        ckfound = new Dictionary<string, List<int>>();
        get_file_to_read();
        doc.Load("Categories.xml");// non
        XmlNodeList listnodes = doc.GetElementsByTagName("File");//Category
        List<string> detectedkeywords = new List<string>();

        //for (int j = 0; j < listnodes.Count; j++)
        //{
            XmlNodeList node = listnodes[0].ChildNodes;
            for (int i = 0; i < node.Count; i++)//i<=
            {
                bool es = false;
                XmlNodeList lss = node[i].ChildNodes;
                detectedkeywords = new List<string>();
                for (int x = 0; x < lss.Count; x++)
                {
                    repeat = new List<int>();
                    for (int k = 0; k < linelist.Count; k++)
                    {
                        if (linelist[k].Contains(lss[x].InnerText))
                        {
                            for (int o = 0; o < (linelist.ElementAt(k).Count()); o++)
                            {
                                if (linelist[k].ElementAt(o) == lss[x].InnerText)
                                {
                                    repeat.Add(k+1);
                                    es = true;
                
                                }
                            
                            }
                        }//end if
                    }
                    if (es)
                    {
                        ckfound.Add(lss[x].InnerText, repeat);
                        detectedkeywords.Add(lss[x].InnerText);
                    }
                }//end_lss_loop
                if (es)
                {
                    filesort.Add((node[i].Name), (detectedkeywords));
                    es = false;
                }
            }//end_outer_loop

   
            //    }//end_loop
        save();
    }//end_func

    public void save()
    {

        if (!File.Exists("File.xml"))
        {
            XmlWriter Xwrite = XmlWriter.Create("File.xml");
            Xwrite.WriteStartDocument();
            Xwrite.WriteStartElement("File");
            Xwrite.WriteStartElement("content");
            Xwrite.WriteString("\r\n");
            Xwrite.WriteStartElement("File_name");
            Xwrite.WriteValue(filepath);
            Xwrite.WriteEndElement();
            Xwrite.WriteString("\r\n");
            Xwrite.WriteStartElement("File_Path");
            Xwrite.WriteValue(filename);
            Xwrite.WriteEndElement();
            Xwrite.WriteString("\r\n");

            for (int i = 0; i < filesort.Count; i++)
            {
                Xwrite.WriteStartElement("Category");
                Xwrite.WriteString("\r\n");
                Xwrite.WriteStartElement("CategoryName");
                Xwrite.WriteValue(filesort.ElementAt(i).Key);
                Xwrite.WriteEndElement();
                Xwrite.WriteString("\r\n");
                for (int j = 0; j < filesort.ElementAt(i).Value.Count; j++)
                {
                    Xwrite.WriteStartElement("keyword");
                    Xwrite.WriteValue(filesort.ElementAt(i).Value.ElementAt(j));
                    Xwrite.WriteEndElement();
                    Xwrite.WriteString("\r\n");
                }
                Xwrite.WriteEndElement();
            }
            Xwrite.WriteEndElement();
            Xwrite.WriteEndElement();
            Xwrite.WriteEndDocument();
            Xwrite.Close();
        }
        else
        {
            XmlDocument savedfile = new XmlDocument();
            savedfile.Load("File.xml");
            XmlElement element = savedfile.CreateElement("content");
            XmlElement ew = savedfile.CreateElement("File_name");
            ew.InnerText = filepath;
            element.AppendChild(ew);
            ew = savedfile.CreateElement("File_Path");
            ew.InnerText = filename;
            element.AppendChild(ew);
            for (int i = 0; i < filesort.Count; i++)
            {
                XmlElement inlist, catlist;
                inlist = savedfile.CreateElement("Category");
                catlist = savedfile.CreateElement("CategoryName");
                catlist.InnerText = filesort.ElementAt(i).Key;
                inlist.AppendChild(catlist);
                for (int j = 0; j < filesort.ElementAt(i).Value.Count; j++)
                {
                    catlist = savedfile.CreateElement("keyword");
                    catlist.InnerText = filesort.ElementAt(i).Value.ElementAt(j);
                    inlist.AppendChild(catlist);
                }
                ew.AppendChild(inlist);
                XmlElement root = savedfile.DocumentElement;
                element.AppendChild(inlist);
                root.AppendChild(element);
                savedfile.Save("File.xml");
                
            }


        } 
      



    }//end_save()_func


    public void get_file_to_read()
    {
        FileStream stream = new FileStream(@filename + "\\" + "\\" + filepath + ".txt", FileMode.Open, FileAccess.Read);
        StreamReader read = new StreamReader(stream);

        int i = 0;
        while (read.Peek() != -1)
        {
            string eline = read.ReadLine();
            line = eline.Split(' ');
            linelist.Add(line);
            i++;
        }

    }//end_func

    public void End()
    {
        last.Add(filepath, ckfound);
    }
    public string f_n;
    public int capacity=last.Keys.Count;
    public Dictionary<string,List<int>> Display_search(int i)
    {
        Dictionary<string, List<int>> re = new Dictionary<string, List<int>>();
        f_n = last.ElementAt(i).Key;
        re = last.ElementAt(i).Value;
        return re;
    }




    }//end_class
}
