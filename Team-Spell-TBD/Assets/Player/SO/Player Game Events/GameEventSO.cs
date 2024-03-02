using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event/GameEvent")]
public class GameEventSO : ScriptableObject
{
    public UnityEvent onGameEvent;

    public void RaiseEvent()
    {
        if (onGameEvent != null)
        {
            onGameEvent.Invoke();
        }
    }
}
