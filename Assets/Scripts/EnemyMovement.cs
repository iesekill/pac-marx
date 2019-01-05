using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : GridMovement
{
    override protected void MovementLogic()
    {
        bool collidedForward = this.directionalColliders.GetDirectionCollided(Direction.forward);
        bool collidedLeft = this.directionalColliders.GetDirectionCollided(Direction.left);
        bool collidedRight = this.directionalColliders.GetDirectionCollided(Direction.right);
        bool isOnGrid = this.IsOnGrid();

        if (this.navRotation.x == 0f && this.navRotation.z == 0f && this.rnd.Next(200) == 0)
        {
            this.navRotation = this.rnd.Next(2) == 0 ? this.transform.right : -this.transform.right;
        }

        if (collidedForward)
        {
            if (!collidedLeft && isOnGrid)
            {
                this.navRotation = -this.transform.right;
            }
            else if (!collidedRight && isOnGrid)
            {
                this.navRotation = this.transform.right;
            }
            else
            {
                this.navRotation = -this.transform.forward;
            }
        }
    }
}
