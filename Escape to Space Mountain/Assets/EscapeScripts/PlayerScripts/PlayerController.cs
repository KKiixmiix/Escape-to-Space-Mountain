using UnityEngine;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Interactable focus;
    public LayerMask movementMask;
    public Camera cam;
    //PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    ray = cam.ScreenPointToRay(Input.mousePosition);
        //    Debug.Log("MousPos: " + Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100, movementMask))
        //    {
        //        RemoveFocus();
        //        motor.MoveToPoint(hit.point);
        //    }
        //}

        if (Input.GetMouseButtonDown(1))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Hit: " + hit.collider.name + " " + hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            //motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        //motor.StopFollow();
    }
}
