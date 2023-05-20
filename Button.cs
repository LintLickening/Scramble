using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite buttonPushedSprite;
    public Sprite buttonUpSprite;
    public bool spawnBlock2;
    private GameController gameControl;
    private int buttonSpriteChange = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer buttonRender = this.gameObject.GetComponent<SpriteRenderer>();
        if (this.gameObject.name == "Button1")
        {
            switch (gameControl.gameLevel)
            {
                case 2:
                    if (gameControl.buttonUnlock == false)
                    {
                        buttonRender.sprite = buttonPushedSprite;
                    }
                    if (gameControl.buttonUnlock == true && buttonSpriteChange < 1)
                    {
                        buttonRender.sprite = buttonUpSprite;
                        buttonSpriteChange++;
                    }
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            SpriteRenderer buttonRender = this.gameObject.GetComponent<SpriteRenderer>();
            if(this.gameObject.name == "Button1")
            {
                if(gameControl.gameLevel == 2)
                {
                    if (gameControl.buttonUnlock == true)
                    {
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                    }
                }
                else if(gameControl.gameLevel == 11)
                {
                    if (gameControl.buttonUnlock == true)
                    {
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                    }
                }
                else
                {
                    gameControl.button1 = true;
                    buttonRender.sprite = buttonPushedSprite;
                }   
            }
            else if (this.gameObject.name == "Button2")
            {
                gameControl.button2 = true;
                buttonRender.sprite = buttonPushedSprite;
            }
            else if (this.gameObject.name == "Button3")
            {
                gameControl.button3 = true;
                buttonRender.sprite = buttonPushedSprite;
            }
            else if(this.gameObject.name == "Button4")
            {
                gameControl.button4 = true;
                buttonRender.sprite = buttonPushedSprite;
            }
        }
        if (collision.tag == "Player")
        {
            SpriteRenderer buttonRender = this.gameObject.GetComponent<SpriteRenderer>();
            if (this.gameObject.name == "Button1")
            {
                switch (gameControl.gameLevel)
                {
                    case 1:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 3:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 6:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 7:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 12:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 15:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                    case 16:
                        gameControl.button1 = true;
                        buttonRender.sprite = buttonPushedSprite;
                        break;
                }
            }
            else if (this.gameObject.name == "Button2")
            {
                if (gameControl.gameLevel != 9)
                {
                    gameControl.button2 = true;
                    buttonRender.sprite = buttonPushedSprite;
                }
            }
            else if (this.gameObject.name == "Button3")
            {
                gameControl.button3 = true;
                buttonRender.sprite = buttonPushedSprite;
            }
            else if(this.gameObject.name == "Button4")
            {
                if (gameControl.gameLevel != 4)
                {
                    gameControl.button4 = true;
                    buttonRender.sprite = buttonPushedSprite;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Block")
        {
            SpriteRenderer buttonRender = this.gameObject.GetComponent<SpriteRenderer>();
            buttonRender.sprite = buttonUpSprite;
            if (this.gameObject.name == "Button1")
            {
                gameControl.button1 = false;
            }
            else if (this.gameObject.name == "Button2")
            {
                gameControl.button2 = false;
            }
            else if (this.gameObject.name == "Button3")
            {
                gameControl.button3 = false;
            }
            else if (this.gameObject.name == "Button4")
            {
                gameControl.button4 = false;
            }
        }
        if (collision.tag == "Player")
        {
            SpriteRenderer buttonRender = this.gameObject.GetComponent<SpriteRenderer>();
            buttonRender.sprite = buttonUpSprite;
            if (this.gameObject.name == "Button1")
            {
                gameControl.button1 = false;
            }
            else if (this.gameObject.name == "Button2")
            {
                gameControl.button2 = false;
            }
            else if (this.gameObject.name == "Button3")
            {
                gameControl.button3 = false;
            }
            else if (this.gameObject.name == "Button4")
            {
                gameControl.button4 = false;
            }
        }
    }
}
