using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _inputAxis;
    internal Rigidbody2D RB;
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();   

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void GetInputAxis(InputAction.CallbackContext ctx) 
    {
        _inputAxis = ctx.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        RB.velocity = _inputAxis * PlayerManager.instance.PlayerStats.PlayerSpeed;
    }
}
