using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player currentplayer = collision.GetComponent<Player>();
            currentplayer.hasKey = true;
            this.transform.SetParent(collision.gameObject.transform);
            this.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1f, 0f);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
