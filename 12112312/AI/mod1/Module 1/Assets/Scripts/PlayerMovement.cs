using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    [SerializeField]
    private float rotSense = 1.5f; //rotation sensitivity
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputMovement = inputMovement.normalized;

        Vector3 inputLook = new Vector3(0, Input.GetAxis("Mouse X"), 0 );
        inputLook = inputLook.normalized;

        transform.Translate(inputMovement * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(inputLook * rotSense);
        
    }
}
