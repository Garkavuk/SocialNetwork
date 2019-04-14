using Graph.Objects;
using System.Collections.Generic;
using System.IO;

namespace Graph.IO
{
    public static class IOServicecs
    {
        public static void GetData(string filePath, Dictionary<string, GraphNode<string>> graphDictionary, AssociationHashSet<string> unique, AssociationHashSet<string[]> links)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] lineItems = line.Split(',');

                    //Add link
                    links.AddItem(lineItems);

                    //add uniqe Value
                    unique.AddItem(lineItems[0]);
                    unique.AddItem(lineItems[1]);
                }
            }

            foreach (string uniqueItems in unique)
            {
                if (graphDictionary == null || !graphDictionary.ContainsKey(uniqueItems))
                {
                    graphDictionary.Add(uniqueItems, new GraphNode<string>(uniqueItems));
                }
            }

            foreach (string[] linksItems in links)
            {
                GraphNode<string> mainNode = graphDictionary[linksItems[0]];
                GraphNode<string> neighbourNode = graphDictionary[linksItems[1]];

                mainNode.AddNeighbour(neighbourNode, 1);
            }
        }
    }
}
