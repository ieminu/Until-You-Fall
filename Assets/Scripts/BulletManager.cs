using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject[] bullets;

    [SerializeField] float fireRate;

    float timePassed;

    bool canFire;

    private void Start()
    {
        canFire = true;
        
        GameObject playerSupporter = GameObject.Find("Player Supporter");
        bullets = new GameObject[playerSupporter.transform.childCount];

        for (int i = 0; i < bullets.Length; i++)
            bullets[i] = playerSupporter.transform.GetChild(i).gameObject;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            if (!canFire)
            {
                timePassed += Time.deltaTime;

                if (timePassed > fireRate)
                {
                    canFire = true;
                }
            }

            else
            {
                timePassed = 0;
                Fire();
                canFire = false;
            }
        }
    }

    void Fire()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                break;
            }
        }
    }
}
