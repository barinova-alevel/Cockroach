using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cockroach
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FastInsect> insectList = new List<FastInsect>();
            insectList.Add(new FastInsect('*',1));
            insectList.Add(new FastInsect('#',3));
            insectList.Add(new FastInsect('&',5));
            insectList.Add(new FastInsect('$',7));

            CancellationTokenSource token = new CancellationTokenSource();
            
            int road = 0;

            foreach (FastInsect i in insectList)
                i.Run(token.Token);

            while (road <= 10)
            {
                foreach (FastInsect i in insectList)
                {
                    int s = i.Step();
                    if (road < s)
                        road = s;
                }
                Thread.Sleep(200);
            }
            token.Cancel();
            Console.ReadKey();
        }
    }

  
}
