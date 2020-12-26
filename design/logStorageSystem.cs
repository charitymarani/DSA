/*
You are given several logs, where each log contains a unique ID and timestamp. Timestamp is a string that has the following format: Year:Month:Day:Hour:Minute:Second, for example, 2017:01:01:23:59:59. All domains are zero-padded decimal numbers.

Implement the LogSystem class:

LogSystem() Initializes the LogSystem object.
void put(int id, string timestamp) Stores the given log (id, timestamp) in your storage system.
int[] retrieve(string start, string end, string granularity) Returns the IDs of the logs whose timestamps are within the range from start to end inclusive. start and end all have the same format as timestamp, and granularity means how precise the range should be (i.e. to the exact Day, Minute, etc.). For example, start = "2017:01:01:23:59:59", end = "2017:01:02:23:59:59", and granularity = "Day" means that we need to find the logs within the inclusive range from Jan. 1st 2017 to Jan. 2nd 2017, and the Hour, Minute, and Second for each log entry can be ignored.

*/
// Time: o(1)put, 0(n) retrieve => can be improved to o(logn) put and o(m)retrieve using treemap in java and treemap.tailmap() to traverse only m timestamps >=start
using System;
using System.Collections.Generic;
using System.Linq;

public class LogSystem
{
    Dictionary<int, long> logs;
    Dictionary<string, long> dict = new Dictionary<string, long>() 
        {
            //     YYYYMMDDHHMMSS
            {"Year",  10000000000}, 
            {"Month",   100000000},
            {"Day",       1000000},
            {"Hour",        10000},
            {"Minute",        100},
            {"Second",          1}
        };
    public LogSystem()
    {
        logs = new Dictionary<int, long>();
    }

    public void Put(int id, string timestamp)
    {
        logs.Add(id, long.Parse(timestamp.Replace(":", "")));
        
    }

    public IList<int> Retrieve(string s, string e, string gra)
    {
        
        long div = dict[gra], start = long.Parse(s.Replace(":", "")) / div, end = long.Parse(e.Replace(":", "")) / div;
        return logs.Where(x => x.Value/div >= start && x.Value/div <= end).Select(x => x.Key).ToList();
    }
}