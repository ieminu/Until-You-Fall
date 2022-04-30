using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MainManager mainManager;

    Rigidbody thisRigidbody;

    [SerializeField] float speed;

    float verticalInput;
    float horizontalInput;

    private void Awake()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
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
