using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Graph.ReadStrategies
{
    class GraphReadRandom : IGraphReader
    {
        private int nRandomSeed;

        public GraphReadRandom()
        {
            nRandomSeed = DateTime.Now.Millisecond;
        }

        public List<List<int>> ReadGraph()
        {
            Random rnd = new Random(nRandomSeed);

            List<List<int>> gResult = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                gResult.Add(new List<int>());
                for (int j = 0; j < 10; j++)
                {
                    gResult[i].Add(0);
                }
            }

            for (int i = 0;i < 10;i++)
            {
                for(int j = 0;j < 10;j++)
                {
                    gResult[i][j] = gResult[j][i] = rnd.Next() % 100;
                }
            }

            return gResult;
        }
    }
}
