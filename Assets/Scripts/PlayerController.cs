using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MainManager mainManager;

    FloatingJoystick joystick;

    Rigidbody thisRigidbody;

    [SerializeField] float speed;

    float verticalInput;
    float horizontalInput;

    private void Awake()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
    }

    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
    }

    private void FixedUpdate()
    {
        if (!mainManager.IsGameOver)
        {
            thisRigidbody.AddForce(verticalInput * speed * Vector3.forward);
            thisRigidbody.AddForce(horizontalInput * speed * Vector3.right);
        }
    }
}
