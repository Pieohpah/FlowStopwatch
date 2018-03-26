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

<<<<<<< HEAD
            flow.Start();
=======
>>>>>>> 378361483f5fd6c1bb4ae9730ac045ae4ce94429
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
<<<<<<< HEAD
            var result = flow.Stop();

=======
            
            var result = flow.Stop();
>>>>>>> 378361483f5fd6c1bb4ae9730ac045ae4ce94429
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
            Console.WriteLine($"Total: {flow.SecondsBetween(flow.stopEventID,flow.startEventID)} sec , B: {flow.SecondsBetween(beforeB,afterB)} sec");
       }
    }
}
