//
//  main.swift
//  FlowStopwatchApp
//
//  Created by Peter Herber on 2018-03-26.
//  Copyright © 2018 Peter Herber. All rights reserved.
//

import Foundation

// DUMMY FUNCTIONS
let ms: UInt32 = 1000
func funcA() {
    usleep(500*ms);
}
func funcB()
{
    usleep(1500*ms);
}
func funcC()
{
    usleep(700*ms);
}

// YOUR OWN EVENTS
let beforeA = 0
let afterA = 1
let beforeB = 2
let afterB = 3
let beforeC = 4
let afterC = 5

//SETUP
let events = [ beforeA, afterA, beforeB, afterB, beforeC, afterC ]
let flow = FlowStopwatch(events)

func printResult(_ o : Dictionary<Int,Date>) {
    // HANDLE THE OUTCOME
    print(String(format:"Total: %0.2f sec , B: %0.2f sec", flow.secondsBetween(event1:flow.stopEventId, event2: flow.startEventId), flow.secondsBetween(event1: beforeB, event2:afterB)));
}

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

var result = flow.stop();

// COLLECT RESULT
printResult(result);
print(flow);






