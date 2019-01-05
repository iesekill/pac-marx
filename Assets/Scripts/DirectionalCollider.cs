using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    forward = 0,
    right = 1,
    back = 2,
    left = 3
}

public class DirectionalCollider : MonoBehaviour
{
    public Direction direction;
    private DirectionalColliders directionalColliders;

    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = this.transform.parent.gameObject.GetComponent<Transform>();
        this.directionalColliders = parentTransform.parent.gameObject.GetComponent<DirectionalColliders>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        this.directionalColliders.SetDirectionCollided(this.direction, 1);
    }

    void OnTriggerExit(Collider coll)
    {
        this.directionalColliders.SetDirectionCollided(this.direction, -1);
    }
}
