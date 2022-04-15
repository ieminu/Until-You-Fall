using UnityEngine;

public class UIHandler : MonoBehaviour
{
    GameObject titleText;
    public bool GameStarted { get; private set; } = false;

    private void Start()
    {
        titleText = GameObject.Find("Title Text");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            titleText.SetActive(false);
            GameStarted = true;
        }
    }
}
