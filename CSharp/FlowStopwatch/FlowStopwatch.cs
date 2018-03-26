using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowStopwatch
{
    public class FlowEventItem
    {
        public int eventIdentifier { get; set; }
        public DateTime timestamp { get; set; }
        public FlowEventItem() {
            eventIdentifier = 0;
            timestamp = DateTime.MinValue;
        }
    }

    /// <summary>
    /// FlowStopwatch class
    /// </summary>
    /// <param name="sImput1"></param>
    /// <param name="iInput2"></param>
    /// <returns></returns>
    public class FlowStopwatch
    {
        private const int _startEventID = -10;
        private const int _stopEventID = -11;
        private Dictionary<int, DateTime> _eventList;
        private DateTime _startWatch = DateTime.MinValue;
        private DateTime _stopWatch = DateTime.MinValue;

        /// <summary>
        /// Getter for the start event id
        /// </summary>
        public int startEventID 
        {
            get { return _startEventID; }
        }
        /// <summary>
        /// Getter for the stop event id
        /// </summary>
        public int stopEventID
        {
            get { return _stopEventID; }
        }
        private FlowStopwatch(){
        }
        /// <summary>
        /// Constructor for the FlowStopwatch class
        /// </summary>
        public FlowStopwatch(IList<int> events)
        {
            _eventList = new Dictionary<int, DateTime>();
            foreach(var e in events){
                _eventList[e] = DateTime.MinValue;
            }
            Clear();
        }
        private void Clear(){
            _startWatch = DateTime.MinValue;
            _stopWatch = DateTime.MinValue;
            var keys = _eventList.Keys.ToList();
            foreach(var e in keys) {
                _eventList[e] = DateTime.MinValue;
            }
        }
        /// <summary>
        /// Resets the FlowStopwatch event time, keeps the events
        /// </summary>
        public void Reset() {
            Clear();
        }
        /// <summary>
        /// Starts the FlowStopwatch event time. Returns true if the FlowStopWatch had been stopped before start, else returns false
        /// </summary>
        public bool Start() {
            var stopSet = _stopWatch != DateTime.MinValue;
            Clear();
            _startWatch = DateTime.Now;
            return stopSet;
            
        }
        /// <summary>
        /// Stops the FlowStopwatch and returns the current status
        /// </summary>
        public Dictionary<int, DateTime> Stop(){
            _stopWatch = DateTime.Now;
            return Status();
        }

        /// <summary>
        /// Returns the FlowStopwatch current status, including start and stop events
        /// </summary>
        public Dictionary<int,DateTime> Status(){
            var ret = _eventList;
            ret[_startEventID] = _startWatch;
            ret[_stopEventID] = _stopWatch;
            return ret;
        }

        /// <summary>
        /// Sets the current time for the event 
        /// </summary>
        public bool Stamp(int eventIdentifier){
            if(_startWatch == DateTime.MinValue)
            {
                _startWatch = DateTime.Now;
            }
            if(!_eventList.ContainsKey(eventIdentifier)){
                return false;
            }
            _eventList[eventIdentifier] = DateTime.Now;
            return true;
        }

        /// <summary>
        /// Returns the latest stamped event and the stamp
        /// </summary>
        public FlowEventItem Latest() {
            var l = _eventList.Max(x => x.Value);
            var e = _eventList.Where(x => x.Value == l).First();
            if (e.Key == 0) {
                return new FlowEventItem();
            } 
            var ret = new FlowEventItem();
            ret.eventIdentifier = e.Key;
            ret.timestamp = e.Value;
            return ret;
        }

        /// <summary>
        /// Returns the absolute time between two events
        /// </summary>
        public double SecondsBetween (int event1, int event2){
            if(_eventList[event1] == DateTime.MinValue || _eventList[event2] == DateTime.MinValue)
            {
                return 0.0;
            }
            var timespan = _eventList[event1] - _eventList[event2];
            return Math.Abs(timespan.TotalSeconds);
        }

        public bool IsRunning() {
            if (_startWatch == DateTime.MinValue) return false;
            if (_stopWatch == DateTime.MinValue) return true;
            return false;
        }

		public override string ToString()
		{
            return $"Total: {SecondsBetween(stopEventID, startEventID)} sec";
		}
	}
}
