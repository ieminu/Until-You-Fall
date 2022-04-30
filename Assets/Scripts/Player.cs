using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Material material;

    [SerializeField] float alphaValue;

    [SerializeField] float activityDuration;
    float timePassed;

    public static bool IsPlayerVisible { get; private set; }

    [System.Obsolete]
    private void Start()
    {
        IsPlayerVisible = true;

        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (!IsPlayerVisible)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= activityDuration)
            {
                IsPlayerVisible = true;
                material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
                timePassed = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            IsPlayerVisible = false;
            timePassed = 0;
            Destroy(other.gameObject);
            material.color = new Color(material.color.r, material.color.g, material.color.b, alphaValue);
        }
    }
}
