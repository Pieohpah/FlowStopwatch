using System;
using System.Collections.Generic;
using System.Threading;

namespace FlowStopwatch
{
    class MainClass
    {
        // YOUR OWN EVENTS
        const int beforeA = 0;
        const int afterA = 1;
        const int beforeB = 2;
        const int afterB = 3;
        const int beforeC = 4;
        const int afterC = 5;

        static FlowStopwatch flow = null;

        public static void Main(string[] args)
        {
            //SETUP
            var events = new List<int>() 
            { 
                beforeA,
                afterA , 
                beforeB, 
                afterB, 
                beforeC,
                afterC
            };
            // CREATE FLOWSTOPWATCH WITH THE EVENTS
            flow = new FlowStopwatch(events);

            flow.Start();
            // STAMP AND RUN
            flow.Stamp(beforeA);
            funcA();
            flow.Stamp(afterA);
            flow.Stamp(beforeB);
            funcB();
            flow.Stamp(afterB);
            flow.Stamp(beforeC);
            funcC();
            flow.Stamp(afterC);
            var status = flow.Status();
            var result = flow.Stop();

            // COLLECT RESULT
            printResult(status);
            Console.WriteLine(flow);
        }

        public static void funcA() {
            Thread.Sleep(500);
        }
        public static  void funcB()
        {
            Thread.Sleep(1500);
        }
        public static void funcC()
        {
            Thread.Sleep(700);
        }
        public static void printResult(Dictionary<int,DateTime> o) {
            // HANDLE THE OUTCOME
            Console.WriteLine($"Total: {flow.secondsBetween(flow.stopEventID,flow.startEventID)} sec , B: {flow.secondsBetween(beforeB,afterB)} sec");
       }
    }
}
