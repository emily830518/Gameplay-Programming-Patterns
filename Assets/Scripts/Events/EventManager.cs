using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{
    public delegate void Handler(GameEvent e);
}


public class EventManager
{

    private readonly Dictionary<System.Type, GameEvent.Handler> _handlersDict = new Dictionary<System.Type, GameEvent.Handler>();

    // static private EventManager _instance;     
    // static public EventManager Instance { 
    //     get {
    //             if (_instance == null) {             
    //                 _instance = new EventManager();         
    //             }         
    //             return _instance;
    //         } 
    // }  

    public void AddHandler<Event>(GameEvent.Handler handler) where Event : GameEvent
    {
        System.Type t = typeof(Event);
        if (_handlersDict.ContainsKey(t))
        {
            _handlersDict[t] += handler;
        }
        else
        {
            _handlersDict[t] = handler;
        }
    }

    public void RemoveHandler<Event>(GameEvent.Handler handler) where Event : GameEvent
    {
        System.Type t = typeof(Event);
        GameEvent.Handler handlers;
        if (_handlersDict.TryGetValue(t, out handlers))
        {
            handlers -= handler;
            if (handlers == null)
            {
                _handlersDict.Remove(t);
            }
            else
            {
                _handlersDict[t] = handlers;
            }
        }
    }

    public void Fire(GameEvent e)
    {
        System.Type t = e.GetType();
        GameEvent.Handler handlers;
        if (_handlersDict.TryGetValue(t, out handlers))
        {
            handlers(e);
        }
    }
}



//using System;
//using System.Collections.Generic;

////taken from our course example Events
//public abstract class GameEvent { }

//public class EventManager
//{
//    public delegate void EventDelegate<T>(T e) where T : GameEvent;
//    private delegate void EventDelegate(GameEvent e);

//    private readonly Dictionary<Type, EventDelegate> _delegates = new Dictionary<Type, EventDelegate>();
//    private readonly Dictionary<Delegate, EventDelegate> _delegateLookup = new Dictionary<Delegate, EventDelegate>();
//    private readonly List<GameEvent> _queuedEvents = new List<GameEvent>();
//    private readonly object _queueLock = new object();

//    private static readonly EventManager _instance = new EventManager();
//    public static EventManager Instance => _instance;

//    public EventManager() { }

//    public void AddHandler<T>(EventDelegate<T> del) where T : GameEvent
//    {
//        if (_delegateLookup.ContainsKey(del))
//        {
//            return;
//        }

//        EventDelegate internalDelegate = (e) => del((T)e);
//        _delegateLookup[del] = internalDelegate;

//        EventDelegate tempDel;
//        if (_delegates.TryGetValue(typeof(T), out tempDel))
//        {
//            _delegates[typeof(T)] = tempDel += internalDelegate;
//        }
//        else
//        {
//            _delegates[typeof(T)] = internalDelegate;
//        }
//    }

//    public void RemoveHandler<T>(EventDelegate<T> del) where T : GameEvent
//    {
//        EventDelegate internalDelegate;
//        if (_delegateLookup.TryGetValue(del, out internalDelegate))
//        {
//            EventDelegate tempDel;
//            if (_delegates.TryGetValue(typeof(T), out tempDel))
//            {
//                tempDel -= internalDelegate;
//                if (tempDel == null)
//                {
//                    _delegates.Remove(typeof(T));
//                }
//                else
//                {
//                    _delegates[typeof(T)] = tempDel;
//                }
//            }
//            _delegateLookup.Remove(del);
//        }
//    }

//    public void Clear()
//    {
//        lock (_queueLock)
//        {
//            if (_delegates != null) _delegates.Clear();
//            if (_delegateLookup != null) _delegateLookup.Clear();
//            if (_queuedEvents != null) _queuedEvents.Clear();
//        }
//    }

//    public void Fire(GameEvent e)
//    {
//        EventDelegate del;
//        if (_delegates.TryGetValue(e.GetType(), out del))
//        {
//            del.Invoke(e);
//        }
//    }

//    public void ProcessQueuedEvents()
//    {
//        List<GameEvent> events;
//        lock (_queueLock)
//        {
//            if (_queuedEvents.Count > 0)
//            {
//                events = new List<GameEvent>(_queuedEvents);
//                _queuedEvents.Clear();
//            }
//            else
//            {
//                return;
//            }
//        }

//        foreach (var e in events)
//        {
//            Fire(e);
//        }
//    }

//    public void Queue(GameEvent e)
//    {
//        lock (_queueLock)
//        {
//            _queuedEvents.Add(e);
//        }
//    }

//}