using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public void ScrambleAnimation()
    {
        GameObject.Find("GameController").GetComponent<GameController>().colorChangeCamera.transform.position = new Vector3(19.5f, 113.5f, -1f);
        this.GetComponent<Animator>().SetTrigger("ChangeColor");
    }

    public void TriggerRebind()
    {
        GameObject.Find("GameController").GetComponent<GameController>().TriggerRebind();
        Destroy(this.gameObject);
    }

    public void playSound()
    {
        GameObject.Find("ColorChangeSound").GetComponent<AudioSource>().Play();
    }
}
