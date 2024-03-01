using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Event", menuName = "Game Event/AbilityEvent")]
public class AbilityEventSO : ScriptableObject
{
    public UnityEvent onAbilityActivated;

    public void RaiseEvent()
    {
        if (onAbilityActivated != null)
        {
            onAbilityActivated.Invoke();
        }
    }
}
