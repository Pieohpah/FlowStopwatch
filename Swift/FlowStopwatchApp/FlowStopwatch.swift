//
//  FlowStopwatch.swift
//  FlowStopwatchApp
//
//  Created by Peter Herber on 2018-03-26.
//  Copyright © 2018 Peter Herber. All rights reserved.
//

import Cocoa



class FlowStopwatch: NSObject {
    fileprivate let _startEventId = -10
    fileprivate let _stopEventId = -11
    fileprivate var _eventList : Dictionary<Int,Date> = [:]
    fileprivate var _startWatch : Date = Date.distantPast
    fileprivate var _stopWatch : Date = Date.distantPast

    fileprivate override init() {
        super.init()
    }
    override var description: String {
        return "Total: \(secondsBetween(event1:_stopEventId, event2:_startEventId)) sec"
    }
    var startEventId : Int {
        get { return _startEventId }
    }
    var stopEventId : Int {
        get { return _stopEventId }
    }
    init(_ events : Array<Int>) {
        super.init()
        for e in events {
            _eventList[e] = Date.distantPast
        }
        clear()
    }
    
    private func clear() {
        _startWatch = Date.distantPast
        _stopWatch = Date.distantPast
        let keys = _eventList.keys
        for k in keys {
            _eventList[k] = Date.distantPast
        }
    }
    func reset(){
        clear()
    }
    func start() -> Bool {
        let stopSet = _stopWatch != Date.distantPast
        clear()
        _startWatch = Date()
        return stopSet
    }
    func stop() -> Dictionary<Int,Date> {
        _stopWatch = Date()
        return status()
    }
    func status() -> Dictionary<Int,Date> {
        var ret = _eventList
        ret[_startEventId] = _startWatch
        ret[_stopEventId] = _stopWatch
        return ret
    }
    func stamp(_ eventIdentifier: Int ) -> Bool {
        if _startWatch == Date.distantPast
        {
            _startWatch = Date()
        }
        if !_eventList.keys.contains(eventIdentifier) {
            return false
        }
        _eventList[eventIdentifier] = Date()
        return true
    }
    func latest() -> (Int,Date) {
        let l = _eventList.values.max()
        for e in _eventList.enumerated() {
            if e.element.value == l {
                return e.element
            }
        }
        return (0, Date.distantPast)
    }
    func isRunning() -> Bool {
        if _startWatch == Date.distantPast { return false }
        if _stopWatch == Date.distantPast { return true }
        return false
    }
    func secondsBetween(event1 : Int, event2 : Int) -> Double {
        let events = status()
        if !events.keys.contains(event1) || !events.keys.contains(event2) {
             return 0.0;
        }
        if events[event1] == Date.distantPast || events[event2] == Date.distantPast
        {
            return 0.0;
        }
        let timespan = events[event1]!.timeIntervalSince(events[event2]!)
        return abs(timespan);
    }
}




