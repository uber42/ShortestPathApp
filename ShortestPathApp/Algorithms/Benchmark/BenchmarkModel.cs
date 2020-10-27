using ShortestPathApp.Algorithms.Dijkstra;
using ShortestPathApp.Algorithms.Floyd;
using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.ReadStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Algorithms.Benchmark
{
    class BenchmarkResult
    {
        public string algorithmName { get; set; }
        public long lTime { get; set; }

        public BenchmarkResult(string name)
        {
            algorithmName = name;
            lTime = 0L;
        }
    }

    class BenchmarkModel
    {
        IGraphModel graphModel;

        List<Tuple<string, IShortestPathAlgorithm>> algorithms;

        public BenchmarkModel()
        {
            graphModel = new GraphModel();
            algorithms = new List<Tuple<string, IShortestPathAlgorithm>>();

            IGraphReader reader = new GraphReadFake();
            graphModel.ReadGraph(reader);

            algorithms.Add(Tuple.Create<string, IShortestPathAlgorithm>("Дейкстра", new DijkstraModel()));
            algorithms.Add(Tuple.Create<string, IShortestPathAlgorithm>("Флойд", new FloydModel()));

            for (int i = 0;i < algorithms.Count;i++)
            {
                algorithms[i].Item2.Graph = graphModel;
            }
        }

        /// <summary>
        /// Запустить
        /// </summary>
        /// <param name="nCount">Количество повторений</param>
        public List<BenchmarkResult> Start(int nCount)
        {
            List<BenchmarkResult> result = new List<BenchmarkResult>();
            for(int i = 0; i< algorithms.Count;i++)
            {
                result.Add(new BenchmarkResult(algorithms[i].Item1));
            }

            for (int i = 0;i < nCount;i++)
            {
                for(int j = 0;j < algorithms.Count;j++)
                {
                    result[j].lTime += algorithms[j].Item2.Benchmark();
                    algorithms[j].Item2.Invalidate();
                }
            }

            return result;
        }
    }
}
