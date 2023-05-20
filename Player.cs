using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Animator anim;
    private float _faceDirection;
    private GameObject cube;
    public PlayerInput playerInput;
    private bool canAttach = false;
    private bool attached = false;
    public bool hasKey = false;
    public bool doorCanOpen = false;
    private GameController gameController;
    private Vector2 inputVector;
    public InputAction keyboardAction = null;
    public InputAction gamepadAction = null;
    public bool disabled = false;
    public bool crystalActive = false;
    private bool canBreak = false;
    public AudioSource footstepSound;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * inputVector.x * speed * Time.deltaTime);
        transform.Translate(Vector3.up * inputVector.y * speed * Time.deltaTime);
        if (disabled == false)
        {
            anim.SetFloat("Horizontal", inputVector.x);
            anim.SetFloat("Vertical", inputVector.y);
            anim.SetFloat("Speed", inputVector.sqrMagnitude);
            if (inputVector.y > 0.01)
            {
                _faceDirection = 0;
            }
            else if (inputVector.y < -0.01)
            {
                _faceDirection = 1;
            }
            else if (inputVector.x > 0.01)
            {
                _faceDirection = 2;
            }
            else if (inputVector.x < -0.01)
            {
                _faceDirection = 3;
            }
            switch (_faceDirection)
            {
                case 0:
                    anim.SetBool("FaceBackward", true);
                    anim.SetBool("FaceForward", false);
                    anim.SetBool("FaceLeft", false);
                    anim.SetBool("FaceRight", false);
                    break;
                case 1:
                    anim.SetBool("FaceBackward", false);
                    anim.SetBool("FaceForward", true);
                    anim.SetBool("FaceLeft", false);
                    anim.SetBool("FaceRight", false);
                    break;
                case 2:
                    anim.SetBool("FaceBackward", false);
                    anim.SetBool("FaceForward", false);
                    anim.SetBool("FaceLeft", false);
                    anim.SetBool("FaceRight", true);
                    break;
                case 3:
                    anim.SetBool("FaceBackward", false);
                    anim.SetBool("FaceForward", false);
                    anim.SetBool("FaceRight", false);
                    anim.SetBool("FaceLeft", true);
                    break;
            }
        }
    }
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        if(footstepSound.isPlaying == false)
        {
            footstepSound.enabled = true;
        }
        if (ctx.canceled)
        {
            footstepSound.enabled = false;
        }
        if (ctx.action.activeControl.device.name == "Keyboard")
        {
            keyboardAction = ctx.action;
        }
        if (ctx.action.activeControl.device.name == "XInputControllerWindows")
        {
            gamepadAction = ctx.action;
        }
        inputVector = ctx.ReadValue<Vector2>();
    }
    public void OnUse(InputAction.CallbackContext ctx)
    {
        if (ctx.interaction is SlowTapInteraction)
        {
            if (ctx.started && canAttach == true)
            {
                cube.transform.SetParent(this.transform);
                canAttach = false;
                attached = true;
            }
            if (ctx.performed && attached == true)
            {
                cube.transform.SetParent(gameController.currentLevelController.transform);
                attached = false;
            }
        }
        if(ctx.canceled && attached == true)
        {
            cube.transform.SetParent(gameController.currentLevelController.transform);
            attached = false;
        }
        if (doorCanOpen == true)
        {
            gameController.OpenDoor();
        }
        if(canBreak == true)
        {
            gameController.BreakCrystal();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            speed = 0;
            inputVector = new Vector2(0, 0);
            disabled = true;
            Debug.Log("Hit by laser");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block" && collision.name != "FakeBox")
        {
            canAttach = true;
            cube = collision.gameObject;
        }
        if (collision.tag == "Door" && hasKey == true && gameController.gameLevel != 0)
        {
            doorCanOpen = true;
        }
        if(collision.tag == "Door" && gameController.gameLevel == 0)
        {
            doorCanOpen = true;
            gameController.currentDoor = collision.name;
            gameController.currentDoorObject = collision.gameObject;
        }
        if(collision.tag == "Crystal" && crystalActive == true)
        {
            canBreak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            cube.transform.SetParent(gameController.currentLevelController.transform);
            cube = null;
            attached = false;
        }
        if (collision.tag == "Door" && gameController.gameLevel == 0)
        {
            doorCanOpen = false;
            gameController.currentDoor = "";
        }
    }
}
