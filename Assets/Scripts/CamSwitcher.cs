using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player;
    public CinemachineVirtualCamera activeCam;
    public CinemachineVirtualCamera firstPersonCam;
    public GameObject gun;

    public float lookUpSpeed = 2.0f;
    public float lookDownSpeed = 2.0f;

    private static float lookUp = 0;
    private static float lookDown = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gun.SetActive(true);
            firstPersonCam.Priority = 2;
            if (Input.GetKey(KeyCode.W) && lookUp <= 35)
            {
                firstPersonCam.transform.Rotate(Vector3.right, -lookUpSpeed * Time.deltaTime);
                lookUp += lookUpSpeed * Time.deltaTime;
                lookDown -= lookUpSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) && lookDown <= 35)
            {
                firstPersonCam.transform.Rotate(Vector3.right, lookDownSpeed * Time.deltaTime);
                lookDown += lookDownSpeed * Time.deltaTime;
                lookUp -= lookUpSpeed * Time.deltaTime;
            }
        }
        else
        {
            gun.SetActive(false);
            lookDown = 0;
            lookUp = 0;
            firstPersonCam.Priority = 0;
            firstPersonCam.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }
    }
}