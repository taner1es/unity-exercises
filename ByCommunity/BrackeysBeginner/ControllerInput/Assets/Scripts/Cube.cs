using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    PlayerControls controls;
    
    Vector2 move;
    Vector2 rotate;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Grow.performed += ctx => Grow();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void Grow()
    {
        transform.localScale *= 1.1f;
    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
        
        Vector2 r = new Vector2(rotate.y, -rotate.x) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
