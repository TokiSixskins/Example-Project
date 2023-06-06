using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        anim.SetBool("isWalkingForward", verticalInput > 0 && !Input.GetKey(KeyCode.Space));
        anim.SetBool("isWalkingBackward", verticalInput < 0 && !Input.GetKey(KeyCode.Space));
        anim.SetBool("isTurningLeft", horizontalInput < 0);
        anim.SetBool("isTurningRight", horizontalInput > 0);
    }
}
