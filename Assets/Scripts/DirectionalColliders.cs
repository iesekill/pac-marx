using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalColliders : MonoBehaviour
{
    private Dictionary<Direction, int> directionCollided = new Dictionary<Direction, int>()
    {
        { Direction.forward, 0 },
        { Direction.right, 0 },
        { Direction.back, 0 },
        { Direction.left, 0 }
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // string log = System.String.Format("f = {0}; r = {1}; b = {2}; l = {3};",
        //     this.directionCollided[Direction.forward],
        //     this.directionCollided[Direction.right],
        //     this.directionCollided[Direction.back],
        //     this.directionCollided[Direction.left]
        // );
        // Debug.Log(log);
    }

    public bool GetDirectionCollided (Direction direction)
    {
        return this.directionCollided[direction] > 0;
    }

    public void SetDirectionCollided (Direction direction, int value)
    {
        this.directionCollided[direction] += value;
    }
}
