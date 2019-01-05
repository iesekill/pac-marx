using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GridMovement
{
    override protected void MovementLogic()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            this.navRotation = Vector3.forward;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            this.navRotation = Vector3.back;
        }
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            this.navRotation = Vector3.right;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            this.navRotation = Vector3.left;
        }
    }
}
