using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float turnSpeed = 180f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movDir = Vector3.zero;

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        if (!(Input.GetKey(KeyCode.Space)))
        {
            movDir = transform.forward * Input.GetAxis("Vertical") * speed;
        }
        else
        {
            movDir = Vector3.zero;
        }
        controller.Move(movDir * Time.deltaTime);
    }
}