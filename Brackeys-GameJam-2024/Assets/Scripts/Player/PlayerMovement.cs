using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    internal Vector2 InputAxis;
    internal Rigidbody2D RB;
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        //Cursor.visible = false;
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
        InputAxis = ctx.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        RB.velocity = InputAxis * PlayerManager.instance.PlayerStats.PlayerSpeed;
    }
}
