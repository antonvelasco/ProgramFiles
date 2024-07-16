using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOwner : MonoBehaviour
{
    public Transform owner;

    [SerializeField]
    private float moveSpeed = 5;
    
    [SerializeField]
    public float rotSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookAtGoal = new Vector3(owner.position.x, transform.position.y, owner.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        if (Vector3.Distance(owner.position, transform.position) > 1)
        {
            transform.position = Vector3.Lerp(transform.position, owner.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        }
    }
}
