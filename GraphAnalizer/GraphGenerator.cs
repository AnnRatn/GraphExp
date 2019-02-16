using System;
using System.Collections.Generic;

namespace GraphAnalizer
{
    public static class GraphGenerator
    {
        public static int[,] GetTreeGraph(int size)
        {
            var matrix = GetMatrix(size, size, 0);
            var nextNodes = new List<int>();
            var freeNodes = new List<int>();
            for (int i = 1; i < size; i++)
            {
                freeNodes.Add(i);
            }
            Random rand = new Random();
            nextNodes.Add(0);

            while (freeNodes.Count > 0)
            {
                var nextParentNode = nextNodes[rand.Next(nextNodes.Count)];
                var childCount = rand.Next(1, freeNodes.Count);
                for (int i = 0; i < childCount; i++)
                {
                    var childNode = freeNodes[rand.Next(freeNodes.Count)];
                    matrix[nextParentNode, childNode] = 1;
                    matrix[childNode, nextParentNode] = 1;
                    freeNodes.Remove(childNode);
                    nextNodes.Add(childNode);
                }

                nextNodes.Remove(nextParentNode);
            }
            return matrix;
        }

        public static int[,] GetStrConGraph(int size)
        {
            var matrix = GetMatrix(size, size, 1);
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 0;
            }
            return matrix;
        }

        private static int[,] GetMatrix(int length, int width, int relationsValue)
        {
            var matrix = new int[length, width];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[j, i] = relationsValue;
                }
            }
            return matrix;
        }
    }
}