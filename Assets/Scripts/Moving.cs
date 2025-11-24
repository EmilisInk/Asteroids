using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moving : MonoBehaviour
{
    public float speed = 5f;
    public float range = 10f;

    private Vector3 target;
    void Start()
    {
        PickNewTarget();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        target = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
    }

}
