﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    public Interactable focus;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //move to to what we hit
                motor.MoveToPoint(hit.point);


                //stop focusing any object
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100))
            {

                //check if we hit interactable 
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    //Debug.Log("SetFocus from right mouse");
                    SetFocus(interactable);
                }


            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            StopCombat();
            if (focus != null)
                focus.OnDeFocus();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        StopCombat();
        if (focus != null)
            focus.OnDeFocus();

        focus = null;
        motor.StopFollowingTarget();
    }

    void StopCombat()
    {
        CharacterCombat c = GetComponent<CharacterCombat>();
        if (c != null) c.SetTarget(null);
    }
}

