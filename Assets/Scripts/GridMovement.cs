using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GridMovement : MonoBehaviour
{
    private float size = 1f;
    protected System.Random rnd = new System.Random();
    protected Vector3 navRotation = new Vector3();
    protected DirectionalColliders directionalColliders;
    protected float speed = 2f;

    void Start()
    {
        this.directionalColliders = this.transform.GetComponentInChildren<DirectionalColliders>();

        this.AlignToGrid();
    }

    void Update()
    {
        bool collidedForward = this.directionalColliders.GetDirectionCollided(Direction.forward);
        if (!collidedForward)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }

        this.MovementLogic();

        this.Rotate();
    }

    void LateUpdate()
    {
        this.AlignToGrid();
    }

    abstract protected void MovementLogic();

    float GetSignedAngle(Vector3 direction)
    {
        float angle = Vector3.Angle(this.transform.forward, direction);
        Vector3 cross = Vector3.Cross(this.transform.forward, direction);
        if (cross.y < 0)
        {
            angle = -1f * angle;
        }
        return angle;
    }

    protected void Rotate()
    {
        if (this.navRotation.x != 0f || this.navRotation.z != 0f)
        {
            float angle_float_decim = this.GetSignedAngle(this.navRotation);
            int angle = Mathf.RoundToInt(angle_float_decim);
            bool collidedRight = this.directionalColliders.GetDirectionCollided(Direction.right);
            bool collidedLeft = this.directionalColliders.GetDirectionCollided(Direction.left);
            bool collidedBack = this.directionalColliders.GetDirectionCollided(Direction.back);
            bool isOnGrid = this.IsOnGrid();
            bool rotateRight = angle == 90 && !collidedRight && isOnGrid;
            bool rotateLeft = angle == -90 && !collidedLeft && isOnGrid;
            bool rotateOpposite = (angle == 180 || angle == -180) && !collidedBack;
            if (rotateRight || rotateLeft || rotateOpposite)
            {
                this.transform.eulerAngles += new Vector3(0, angle, 0);
                this.navRotation = new Vector3();
            }
        }
    }

    Vector3 GetClosestToGrid()
    {
        Vector3 gridPosition;

        gridPosition.x = Mathf.Round(this.transform.position.x / this.size) * this.size;
        gridPosition.y = Mathf.Round(this.transform.position.y / this.size) * this.size;
        gridPosition.z = Mathf.Round(this.transform.position.z / this.size) * this.size;

        return gridPosition;
    }

    protected bool IsOnGrid()
    {
        float gridAllowance = 0.05f;
        Vector3 closestToGrid = this.GetClosestToGrid();
        bool onGridX = Mathf.Abs(this.transform.position.x - closestToGrid.x) < gridAllowance;
        bool onGridZ = Mathf.Abs(this.transform.position.z - closestToGrid.z) < gridAllowance;
        return onGridX && onGridZ;
    }

    void AlignToGrid()
    {
        Vector3 closestToGrid = this.GetClosestToGrid();
        Vector3 newPosition = this.transform.position;

        int angle = Mathf.RoundToInt(Vector3.Angle(this.transform.forward, Vector3.forward));
        if (angle % 180 == 0)
        {
            newPosition.x = closestToGrid.x;
        }
        else
        {
            newPosition.z = closestToGrid.z;
        }

        this.transform.position = newPosition;
    }
}
