using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cockroach
{
    public class FastInsect
    {
        int step;
        char shape;
        private int row;
        object lokObject;

        public FastInsect(char shape, int row)
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
