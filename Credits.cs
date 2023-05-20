using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public AudioSource creditsMusic;
    public GameObject menuButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beginScrolling()
    {
        creditsMusic.Play();
    }

    public void spawnButton()
    {
        menuButton.SetActive(true);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("StartCutscene");
    }
}
