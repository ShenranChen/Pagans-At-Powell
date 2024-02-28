using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public AbilityEventSO abilityEvent;

    public LayerMask layerToDetect; // Set this in the inspector to match the layer you're interested in
    public Transform playerPos;
    List<GameObject> hitEntities = new List<GameObject>();

    private Vector3 normDirToMouse;

    private void Start()
    {
        abilityEvent.onAbilityActivated.AddListener(ActivateBasicAttack);
    }

    void ActivateBasicAttack()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject is on the layer you're interested in
        if (((1 << other.gameObject.layer) & layerToDetect) != 0)
        {
            // Add the entity to the list if it's not already included
            if (!hitEntities.Contains(other.gameObject))
            {
                hitEntities.Add(other.gameObject);
                Debug.Log("Hit: " + other.gameObject.name);
            }
        }

        foreach (GameObject obj in hitEntities)
        {
            obj.GetComponent<EnemySetup>().TakeDamage();
        }
    }

    // Example method to clear the list, call this when needed
    public void ClearHitList()
    {
        hitEntities.Clear();
    }
}
