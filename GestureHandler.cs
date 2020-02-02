using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GestureHandler : MonoBehaviour
{
    public UnityEvent horseRearEvent;
    public UnityEvent pandaFallEvent;

    void Start()
    {
        NuitrackManager.onNewGesture += NuitrackManager_onNewGesture;

        if (horseRearEvent == null)
            horseRearEvent = new UnityEvent();

        if (pandaFallEvent == null)
            pandaFallEvent = new UnityEvent();

        // horseRearEvent.AddListener(Ping);
    }

    private void OnDestroy()
    {
        NuitrackManager.onNewGesture -= NuitrackManager_onNewGesture;
    }

    private void NuitrackManager_onNewGesture(nuitrack.Gesture gesture)
    {
        if ((gesture.Type == nuitrack.GestureType.GestureSwipeRight || gesture.Type == nuitrack.GestureType.GestureSwipeLeft)
            && horseRearEvent != null) {
            horseRearEvent.Invoke();
            Debug.Log("swipe detected");
        } else if (gesture.Type == nuitrack.GestureType.GesturePush
            && pandaFallEvent != null)
        {
            pandaFallEvent.Invoke();
            Debug.Log("push detected");
        }
    }
}
