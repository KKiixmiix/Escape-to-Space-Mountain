using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 20f;

    bool isFocus = false;
    protected Transform player;

    bool hasInteracted = false;

    // Override this method in inheriting classes.
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            //Debug.Log("distance " + (distance < radius));
            if (distance < radius)
            {
                //Debug.Log("Should interact");
                Interact();
                //Debug.Log("Interacted");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
