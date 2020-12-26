/*
Implement the class TweetCounts that supports two methods:

1. recordTweet(string tweetName, int time)

Stores the tweetName at the recorded time (in seconds).
2. getTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)

Returns the total number of occurrences for the given tweetName per minute, hour, or day (depending on freq) starting from the startTime (in seconds) and ending at the endTime (in seconds).
freq is always minute, hour or day, representing the time interval to get the total number of occurrences for the given tweetName.
The first time interval always starts from the startTime, so the time intervals are [startTime, startTime + delta*1>,  [startTime + delta*1, startTime + delta*2>, [startTime + delta*2, startTime + delta*3>, ... , [startTime + delta*i, min(startTime + delta*(i+1), endTime + 1)> for some non-negative number i and delta (which depends on freq).  

*/


using System;
using System.Collections.Generic;
// Time o(logk) record, o(m) where k if number of records already in the set for a specific tweetnam and m is times of tweetname within the  range start to end
public class TweetCounts {
    Dictionary<string, SortedSet<int>> tweets;
    Dictionary<string, int> _freq;

    public TweetCounts() {
        tweets = new Dictionary<string, SortedSet<int>>();
        _freq =  new Dictionary<string, int>(){{"minute", 60}, {"hour", 60*60}, {"day", 24*60*60}};
        
    }
    
    public void RecordTweet(string tweetName, int time) {
        if(tweets.ContainsKey(tweetName)){
            SortedSet<int> tweetInfo = tweets[tweetName];
            tweetInfo.Add(time);
        }
        else{
            SortedSet<int> tweetInfo = new SortedSet<int>(){time};
            tweets[tweetName] = tweetInfo;
        }
        
    }
    
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) {
        SortedSet<int> tweetInfo = tweets[tweetName];
        List<int> res= new List<int>();
        
        int start = startTime;
        while(start<=endTime){
            int nextStart = start + _freq[freq];
            SortedSet<int> subset= tweetInfo.GetViewBetween(start, Math.Min(nextStart-1, endTime)); // 
            int sum = subset.Count;
            res.Add(sum);
            start=nextStart;
        }
        return res;
        
    }
}
