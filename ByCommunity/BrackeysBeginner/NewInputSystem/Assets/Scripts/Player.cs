using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Player : MonoBehaviour
{
    // Handling Concept 1
    // ------------------
    Keyboard kb;

    private void OnEnable()
    {
        kb = InputSystem.GetDevice<Keyboard>();
    }

    private void Update()
    {
        if (kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Someone pressed space key !!..");
        } 
    }
    // ------------------

    // Handling Concept 2
    // ------------------

    /*public InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Shoot.performed += _ => Shoot();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        Debug.Log("Player wants to move !!!.." + direction);
    }

    private void Shoot()
    {
        Debug.Log("We Shot the Sheriff!...");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }*/

    // ------------------
}
