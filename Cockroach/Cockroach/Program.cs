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
            List<Insect> insectList = new List<Insect>();
            insectList.Add(new Insect('*',1));
            insectList.Add(new Insect('#',3));
            insectList.Add(new Insect('&',5));
            insectList.Add(new Insect('$',7));

            CancellationTokenSource token = new CancellationTokenSource();
            
            int road = 0;

            foreach (Insect i in insectList)
                i.Run(token.Token);

            while (road <= 10)
            {
                foreach (Insect i in insectList)
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

    public class Insect
    {
        int step;
        char shape;
        private int row;
        object lokObject;

        public Insect(char shape, int row)
        {
            this.shape = shape;
            this.row = row;
            this.lokObject = new object();
        }
        public void Run(CancellationToken token)
        {
            Task.Run(() =>
            {
                Random rnd = new Random();

                while (!token.IsCancellationRequested)
                {
                    
                    this.step++;
                    Thread.Sleep(rnd.Next(1000, 2000));
                    lock (lokObject)
                    {
                        Console.SetCursorPosition(step, row);
                        Console.Write(shape);
                    }
                }
            }, token);
        

        }

        public int Step()
        {
            return this.step;
        }
        public char Shape()
        {
            return shape;
        }
    }
}
