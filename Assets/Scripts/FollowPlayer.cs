using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    MainManager mainManager;

    GameObject player;

    [SerializeField] GameObject defaultGameObjectToFollow;

    Rigidbody thisRigidbody;

    [SerializeField] float speed;

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        player = GameObject.Find("Player");
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!mainManager.IsGameOver)
        {
            transform.LookAt(player.transform);

            Vector3 direction = GameObjectToFollow().transform.position - transform.position;
            thisRigidbody.AddForce(direction.normalized * speed);
        }
    }

    GameObject GameObjectToFollow()
    {
        GameObject gameObjectToFollow = defaultGameObjectToFollow;

        if (player != null && Player.IsPlayerVisible)
        {
            gameObjectToFollow = player;
        }

        return gameObjectToFollow;
    }
}
