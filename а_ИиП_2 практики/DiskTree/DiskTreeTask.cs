using System;
using System.Collections.Generic;
using System.Linq;

namespace DiskTree
{
    public class DiskTreeTask
    {
        static public List<string> Solve(List<string> nodesList)
        {
            var treeNodes = new Tree();
            var result = new List<string>();
            for (int i = 0; i < nodesList.Count; i++)
            {
                string item = nodesList[i];
                treeNodes.Add(item);
            }
            treeNodes.root.CreateTreeList(0, result);
            return result;
        }

        //    public static List<string> Solve(List<string> nodesList)
        //    {
        //        var root = new Root("", new Dictionary<string, Root>());
        //        foreach (var name in nodesList)
        //        {
        //            var node = root;
        //            foreach (var item in name.Split('\\'))
        //                node = node.GetDirection(item);
        //        }
        //        return root.Conclude(-1, new List<string>());
        //    }
    }


    public class Folder
    {
        public readonly string name;
        public Dictionary<string, Folder> nodes;

        public Folder(string name)
        {
            this.name = name;
            this.nodes = new Dictionary<string, Folder>();
        }
        public void CreateTreeList(int count, List<string> result)
        {
            var keys = nodes.Keys.OrderBy(x => x, StringComparer.Ordinal);
            foreach (var key in keys)
            {
                result.Add(new string(' ', count) + key);
                nodes[key].CreateTreeList(count + 1, result);
            }
        }
    }

    public class Tree
    {
        public readonly Folder root;
        public Tree(string name = "")
        {
            root = new Folder(name);
        }
        public void Add(string nodesList)
        {
            Folder parent = root;

            string[] name = nodesList.Split('\\');
            foreach (var item in name)
            {
                if (!parent.nodes.ContainsKey(item))
                {
                    Dictionary<string, Folder> nodes = parent.nodes;
                    nodes.Add(item, new Folder(item));
                }
                parent = parent.nodes[item];
            }
        }
    }

    //public class Root
    //{
    //    public readonly string name;
    //    public readonly string root;
    //    public Dictionary<string, Root> nodes;
    //    public Root(string name, Dictionary<string, Root> nodes)
    //    {
    //        this.name = name;
    //        this.nodes = new Dictionary<string, Root>();
    //    }

    //    public Root GetDirection(string root)
    //    {
    //        return nodes.TryGetValue(root, out Root node)
    //            ? node : nodes[root] = new Root(root, nodes);

    //    }

    //    public List<string> Conclude(int i, List<string> nodesList)
    //    {
    //        if (i >= 0)
    //            nodesList.Add(new string(' ', i) + name);
    //        i++;



    //        foreach (var child in Group())

    //            nodesList = child.Conclude(i, nodesList);
    //        return nodesList;
    //    }
    //    private IOrderedEnumerable<Root> Group()
    //    {
    //        return nodes.Values.OrderBy(root => root.name, StringComparer.Ordinal);
    //    }
    //}

    //public class DiskTreeTask
    //{
    //    public static List<string> Solve(List<string> nodesList)
    //    {
    //        var root = new Root("", new Dictionary<string, Root>());
    //        foreach (var name in nodesList)
    //        {
    //            var node = root;
    //            foreach (var item in name.Split('\\'))
    //                node = node.GetDirection(item);
    //        }
    //        return root.Conclude(-1, new List<string>());
    //    }
    //}
}