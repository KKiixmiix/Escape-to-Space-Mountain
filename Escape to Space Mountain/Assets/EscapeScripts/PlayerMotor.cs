/**
 *  Authors:    Koch 5/2020
 *  
 * Resources:   https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    //public Animator animator;
    public float faceSpeed = 5f;

    //bool moving = false;
    //Vector2 smoothDeltaPosition = Vector2.zero;
    //Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
    }

    void Update()
    {
        //if (target != null)
        //{
        //    agent.SetDestination(target.position);
        //    FaceTarget();
        //}

        //Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        //// Map 'worldDeltaPosition' to local space
        //float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        //float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        //Vector2 deltaPosition = new Vector2(dx, dy);

        //// Low-pass filter the deltaMove
        //float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        //smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        //// Update velocity if time advances
        //if (Time.deltaTime > 1e-5f)
        //    velocity = smoothDeltaPosition / Time.deltaTime;

        //bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        //// Update animation parameters
        //if (shouldMove && !moving)
        //{
        //    moving = true;
        //    animator.SetTrigger("runTrigger");
        //}
        //if (!shouldMove && moving)
        //{
        //    moving = false;
        //    animator.SetTrigger("idleTrigger");
        //    // Bow if Yuna reached the Interactable target
        //    if (target)
        //    {
        //        animator.SetTrigger("bowTrigger");
        //    }
        //}
        //transform.position = agent.nextPosition;
    }

    //public void MoveToPoint(Vector3 point)
    //{
    //    agent.SetDestination(point);
    //}

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollow()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion faceTarget = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, faceTarget, Time.deltaTime * faceSpeed);
    }
}
