using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform InteractableTran;
    bool isFocus = false;
    Transform player;
    bool hasInteractable = false;
    public virtual void Interact() { Debug.Log("���ߴ�����"); }


    private void Update()
    {
        if (isFocus&&!hasInteractable)
        {
            float distance = Vector3.Distance(player.position, InteractableTran.position);
            if (distance <= radius)
            {
       
                Interact();
                hasInteractable = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteractable = false;
    }
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteractable = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractableTran.position, radius);
    }
}
