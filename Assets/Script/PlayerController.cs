using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    PlayerMotor motor;

    public Interactable focus;

    public LayerMask movementMask;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        // movementMask = 1 << LayerMask.NameToLayer("Ground")| 1 << LayerMask.NameToLayer("UI");
        movementMask = 1 << LayerMask.NameToLayer("Ground");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100,1<<LayerMask.NameToLayer("Ground")))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow,10);
                Debug.Log("µã»÷ÎïÌå"+hit.collider.name + "===" + hit.point);
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100))
            {
                Interactable interactanle = hit.collider.GetComponent<Interactable>();
                if (interactanle != null)
                {
                    SetFocus(interactanle);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
