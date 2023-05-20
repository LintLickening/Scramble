using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private GameController gameControl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void crystalTransition()
    {
        GameObject.Find("CrystalBreakSound").GetComponent<AudioSource>().Play();
        GameObject.Find("GameController").GetComponent<GameController>().crystalScreenStart();
        Destroy(this.gameObject);
    }
}
