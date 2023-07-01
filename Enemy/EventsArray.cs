using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] EventArray;

    private void EventStart(int index)
    {
        EventArray[index].Invoke();
    }
}
