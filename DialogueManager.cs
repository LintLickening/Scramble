using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject noButton;
    public GameObject yesButton;
    public GameObject dialogueBackground;
    public SceneInfo sceneinfo;
    private Queue<string> sentences;
    public Image storyImage;
    public Sprite part2;
    public Animator cutsceneAnimator;
    public AudioSource kingDeathSound;
    public Image blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(SceneManager.GetActiveScene().name == "BossCutscene")
        {
            nameText.enabled = true;
            dialogueText.enabled = true;
            continueButton.SetActive(true);
            dialogueBackground.SetActive(true);
        }
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && SceneManager.GetActiveScene().name != "EndCutscene")
        {
            Debug.Log("No sentences left");
            EndDialogue();
            return;
        }
        if(sentences.Count == 0 && SceneManager.GetActiveScene().name == "EndCutscene")
        {
            blackScreen.enabled = true;
            StartCoroutine(kingDeath());
        }
        if(SceneManager.GetActiveScene().name == "Cutscene1" && sentences.Count == 2)
        {
            storyImage.sprite = part2;
        }

        if(SceneManager.GetActiveScene().name == "BossCutscene" && sentences.Count == 2)
        {
            continueButton.SetActive(false);
            noButton.SetActive(true);
            yesButton.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "BossCutscene" && sentences.Count == 1)
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            continueButton.SetActive(true);
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        if(SceneManager.GetActiveScene().name == "Game")
        {
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.15f);
            }
            DisplayNextSentence();
        }
        else
        {
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    IEnumerator kingDeath()
    {
        kingDeathSound.Play();
        yield return new WaitForSeconds(2);
        dialogueBackground.SetActive(false);
        dialogueText.enabled = false;
        continueButton.SetActive(false);
        blackScreen.enabled = false;
        cutsceneAnimator.SetTrigger("Kill");
    }

    public void EndDialogue()
    {
        if(SceneManager.GetActiveScene().name == "Cutscene1")
        {
            GameObject.Find("SceneManager").GetComponent<SceneManagement>().PlayOn();
        }

        if(SceneManager.GetActiveScene().name == "BossCutscene")
        {
            sceneinfo.isPreviousScene = true;
            SceneManager.LoadScene("Game");
        }

        if(SceneManager.GetActiveScene().name == "EndCutscene")
        {
            SceneManager.LoadScene("Credits");
        }
        if(SceneManager.GetActiveScene().name == "Game")
        {
            GameObject.Find("ScrambleText").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = false;
        }
    }
}
