using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private int startDialogueCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Cutscene1")
        {
            if(startDialogueCount < 1)
            {
                GameObject.Find("Part1").GetComponent<DialogueTrigger>().TriggerDialogue();
                startDialogueCount++;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void PlayOn()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
