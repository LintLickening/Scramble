using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private int triggerCount = 0;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "EndCutscene" && triggerCount < 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            triggerCount++;
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
