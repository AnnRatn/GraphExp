using System;

namespace GraphAnalizer
{
    public static class NodeSearcher
    {
        public static long Search(int size, int[,] matrix, int goodNode)
        {
            var visited = new bool[size];
            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var isFound = DepthSearch(size, matrix, visited, 0, goodNode);
            if(!isFound) throw new Exception("Node was not found");
            watch.Stop();
            var elapsedMs = watch.ElapsedTicks;
            return elapsedMs;
        }

        private static bool DepthSearch(int size, int[,] matrix, bool[] visited, int node, int goodNode)
        {
            if(node == goodNode)
                return true;
            visited[node] = true;
            for (int i = 0; i < size; i++)
            {
                if (matrix[node, i] == 1 && !visited[i])
                {
                    if (DepthSearch(size, matrix, visited, i, goodNode))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
