# FlowStopwatch

A process flow stopwatch for monitoring events in your application.

###Available in Swift and C#.###

Setup for a totally generic use. 

Meassure what you like in your program, and use the result however you like. For logging, surveillance, monitoring etc.

###Samples###
#### Swift ####
´´´swift

			let flow = FlowStopwatch(events)

			// STAMP AND RUN
			flow.stamp(beforeA);
			funcA();
			flow.stamp(afterA);
			flow.stamp(beforeB);
			funcB();
			flow.stamp(afterB);
			flow.stamp(beforeC);
			funcC();
			flow.stamp(afterC);
			var status = flow.status();

			// HANDLE RESULT
			print(flow);

´´


#### C# ####
```csharp
          
			var flow = new FlowStopwatch(events);

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

            // HANDLE RESULT
            Console.WriteLine(flow);
```