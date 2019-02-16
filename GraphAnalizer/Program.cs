using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GraphAnalizer
{
    static class Program
    {
        static void Main(string[] args)
        {
            int nodeCount = 1000;
            int expCount = 1000;
            long treeGraphTime = 0;
            long strConGraphTime = 0;
            Random rand = new Random();
            for (int i = 0; i < expCount; i++)
            {
                Console.WriteLine($"Exp num {i}");
                var goodNode = rand.Next(nodeCount);
                var treeGraph = GraphGenerator.GetTreeGraph(nodeCount);
                var strConGraph = GraphGenerator.GetStrConGraph(nodeCount);
                var treeGrTime = NodeSearcher.Search(nodeCount, treeGraph, goodNode);
                treeGraphTime += treeGrTime;
                var strConGrTime = NodeSearcher.Search(nodeCount, strConGraph, goodNode);
                strConGraphTime += strConGrTime;
            }

            //double avgTreeGraphTime = (double)treeGraphTime / (double)expCount;
            //double avgStrConGraphTime = (double)strConGraphTime / (double)expCount;
            Console.WriteLine($"Avg tree graph time: {treeGraphTime} / {expCount}");
            Console.WriteLine($"Avg str con graph time: {strConGraphTime} / {expCount}");
            Console.ReadKey();
        }
    }
}
