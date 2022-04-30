using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    MainManager mainManager;

    Rigidbody thisRigidbody;

    [SerializeField] float offset;

    [SerializeField] float speed;
    
    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!mainManager.IsGameOver)
        {
            GameObject gameObjectToFollow = GameObjectToFollow();

            if (gameObject.name == "Player Supporter")
            {
                transform.LookAt(gameObjectToFollow.transform);
                thisRigidbody.velocity = Direction().normalized * speed;
            }

            else if (gameObject.name.Contains("Bullet"))
            {
                gameObject.transform.parent = null;

                if (gameObjectToFollow != gameObject)
                {
                    transform.LookAt(gameObjectToFollow.transform);
                    transform.position += speed * Time.deltaTime * transform.forward;
                }

                else
                {
                    gameObject.SetActive(false);
                    transform.parent = GameObject.Find("Player Supporter").transform;
                    transform.position = Vector3.zero;
                }
            }
        }
    }

    Vector3 Direction()
    {   
        Vector3 direction = GameObjectToFollow().transform.position - transform.position;
        float distance = direction.x + direction.z;
        bool directionIsNegative = distance < 0;

        if (Mathf.Abs(direction.x) > offset)
        {
            direction.x += directionIsNegative ? offset : -offset;
            return direction;
        }

        else if (Mathf.Abs(direction.z) > offset)
        {
            direction.z += directionIsNegative ? offset : -offset;
            return direction;
        }

        else
        {
            return Vector3.zero;
        }
    }

    GameObject GameObjectToFollow()
    {
        List<GameObject> enemies = new List<GameObject>();

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            enemies.Add(enemy);

        GameObject gameObjectToFollow = gameObject;
        float shorterDistance = float.PositiveInfinity;

        for (int i = 0; i < enemies.Count; i++)
        {
            Vector3 thisDirection = enemies[i].transform.position - transform.position;
            float thisDistance = thisDirection.x + thisDirection.y + thisDirection.z;

            if (Mathf.Abs(thisDistance) <= Mathf.Abs(shorterDistance))
            {
                shorterDistance = thisDistance;
                gameObjectToFollow = enemies[i];
            }
        }
        
        return gameObjectToFollow;
    }
}
