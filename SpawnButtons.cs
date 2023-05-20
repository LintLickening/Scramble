using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtons : MonoBehaviour
{
    public GameObject startButton;
    public GameObject exitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnButton()
    {
        startButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void EndScreen()
    {
        startButton.SetActive(true);
        exitButton.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
