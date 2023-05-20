using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public int chosenBinding;
    public GameObject player1;
    public GameObject player2;
    private Player playerScript1;
    private Player playerScript2;
    public InputActionReference sampleAction;
    private int resetCounter = 0;

     void Start()
    {
        chosenBinding = UnityEngine.Random.Range(1, 24);
    }
    public void StartRebind()
    {
        playerScript1 = player1.GetComponent<Player>();
        playerScript2 = player2.GetComponent<Player>();
        InputAction keyboardAction = playerScript1.keyboardAction;
        InputAction gamepadAction = playerScript2.gamepadAction;
        GameController gameControl = GameObject.Find("GameController").GetComponent<GameController>();
        gameControl.colorScheme = UnityEngine.Random.Range(1, 6);
        DoRebind1(keyboardAction, gameControl);
        DoRebind2(gamepadAction, gameControl);
 
    }

    void Update()
    {
        GameController gameControl = GameObject.Find("GameController").GetComponent<GameController>();
        playerScript1 = player1.GetComponent<Player>();
        playerScript2 = player2.GetComponent<Player>();
        InputAction keyboardAction = playerScript1.keyboardAction;
        InputAction gamepadAction = playerScript2.gamepadAction;
        if(gameControl.gameLevel == 1 && resetCounter < 1)
        {
            if(gamepadAction != null)
            {
                gamepadAction.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                gamepadAction.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                gamepadAction.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                gamepadAction.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                resetCounter++;
            }
            if (keyboardAction != null)
            {
                keyboardAction.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                keyboardAction.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                keyboardAction.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                keyboardAction.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
            }
        }
    }

    public void DoRebind1(InputAction actionToRebind, GameController gameControl)
    {
        if (actionToRebind == null)
        {
            Debug.LogError("Action not found");
            return;
        }
        actionToRebind.Disable();
            switch (gameControl.colorName)
            { 
                case "Red":
                    if (gameControl.redKeySet != 0)
                    {
                        Debug.Log("Red Preset");
                        chosenBinding = gameControl.redKeySet;
                        Debug.Log(chosenBinding);

                    }
                    else
                    {
                        Debug.Log("Red not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;
                case "Yellow":
                    if (gameControl.yellowKeySet != 0)
                    {
                        Debug.Log("Yellow Preset");
                        chosenBinding = gameControl.yellowKeySet;
                        Debug.Log(chosenBinding);
                    }
                    else
                    {
                        Debug.Log("Yellow not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;
                case "Blue":
                    if (gameControl.blueKeySet != 0)
                    {
                        Debug.Log("Blue Preset");
                        chosenBinding = gameControl.blueKeySet;
                        Debug.Log(chosenBinding);
                    }
                    else
                    {
                        Debug.Log("Blue not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;
                case "Green":
                    if (gameControl.greenKeySet != 0)
                    {
                        Debug.Log("Green Preset");
                        chosenBinding = gameControl.greenKeySet;
                        Debug.Log(chosenBinding);
                    }
                    else
                    {
                        Debug.Log("Green not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;
                case "Purple":
                    if (gameControl.purpleKeySet != 0)
                    {
                        Debug.Log("Purple Preset");
                        chosenBinding = gameControl.purpleKeySet;
                        Debug.Log(chosenBinding);
                    }
                    else
                    {
                        Debug.Log("Purple not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;
                case "Orange":
                    if (gameControl.orangeKeySet != 0)
                    {
                        Debug.Log("Orange Preset");
                        chosenBinding = gameControl.orangeKeySet;
                        Debug.Log(chosenBinding);
                    }
                    else
                    {
                        Debug.Log("Orange not found");
                        chosenBinding = UnityEngine.Random.Range(1, 24);
                    }
                    break;

            }
            Debug.Log(chosenBinding);
            switch (chosenBinding)
            {
                case 1:
                actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                break;
                case 2:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 3:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                    break;
                case 4:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/s");
                    break;
                case 5:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/s");
                    break;
                case 6:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 7:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 8:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                    break;
                case 9:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 10:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                    break;
                case 11:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 12:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 13:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                    break;
                case 14:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 15:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath(" <Keyboard>/s");
                    break;
                case 16:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 17:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                    break;
                case 18:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/s");
                    break;
                case 19:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 20:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 21:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/s");
                    break;
                case 22:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/a");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/w");
                    break;
                case 23:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
                case 24:
                    actionToRebind.ChangeBindingWithId("4ac72c4f-8656-4eb3-90e8-9b7b5ce24fd1").WithPath("<Keyboard>/d");
                    actionToRebind.ChangeBindingWithId("4ea9e026-59d8-4554-972b-26a2624f8ceb").WithPath("<Keyboard>/w");
                    actionToRebind.ChangeBindingWithId("61a3389e-d2e2-43c7-a0fd-37bde2289928").WithPath("<Keyboard>/s");
                    actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/a");
                    break;
            }
            actionToRebind.Enable();
            gameControl.colorKeySet();
    }
    public void DoRebind2(InputAction actionToRebind, GameController gameControl)
    {
        if (actionToRebind == null)
        {
            Debug.LogError("Action not found");
            return;
        }
        actionToRebind.Disable();
        switch (gameControl.colorName)
        {
            case "Red":
                if (gameControl.redKeySet != 0)
                {
                    Debug.Log("Red Preset");
                    chosenBinding = gameControl.redKeySet;
                    Debug.Log(chosenBinding);

                }
                else
                {
                    Debug.Log("Red not found");
                }
                break;
            case "Yellow":
                if (gameControl.yellowKeySet != 0)
                {
                    Debug.Log("Yellow Preset");
                    chosenBinding = gameControl.yellowKeySet;
                    Debug.Log(chosenBinding);
                }
                else
                {
                    Debug.Log("Yellow not found");
                }
                break;
            case "Blue":
                if (gameControl.blueKeySet != 0)
                {
                    Debug.Log("Blue Preset");
                    chosenBinding = gameControl.blueKeySet;
                    Debug.Log(chosenBinding);
                }
                else
                {
                    Debug.Log("Blue not found");
                }
                break;
            case "Green":
                if (gameControl.greenKeySet != 0)
                {
                    Debug.Log("Green Preset");
                    chosenBinding = gameControl.greenKeySet;
                    Debug.Log(chosenBinding);
                }
                else
                {
                    Debug.Log("Green not found");
                }
                break;
            case "Purple":
                if (gameControl.purpleKeySet != 0)
                {
                    Debug.Log("Purple Preset");
                    chosenBinding = gameControl.purpleKeySet;
                    Debug.Log(chosenBinding);
                }
                else
                {
                    Debug.Log("Purple not found");
                }
                break;
            case "Orange":
                if (gameControl.orangeKeySet != 0)
                {
                    Debug.Log("Orange Preset");
                    chosenBinding = gameControl.orangeKeySet;
                    Debug.Log(chosenBinding);
                }
                else
                {
                    Debug.Log("Orange not found");
                }
                break;

        }
        Debug.Log(chosenBinding);
        switch (chosenBinding)
        {
            case 1:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 2:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 3:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 4:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/down");
                break;
            case 5:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/down");
                break;
            case 6:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 7:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 8:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 9:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 10:
                actionToRebind.ChangeBindingWithId("0151d25a-a71b-4b82-be7b-88c26c2fa65c").WithPath("<Keyboard>/d");
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 11:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 12:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 13:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 14:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 15:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/down");
                break;
            case 16:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 17:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/right");
                break;
            case 18:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/down");
                break;
            case 19:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 20:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 21:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/down");
                break;
            case 22:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/left");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/up");
                break;
            case 23:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
            case 24:
                actionToRebind.ChangeBindingWithId("48946be8-7161-4231-909d-23b1f06a2e67").WithPath("<Gamepad>/leftstick/right");
                actionToRebind.ChangeBindingWithId("67521d75-e85a-4abc-bfe7-6c41b563b254").WithPath("<Gamepad>/leftstick/up");
                actionToRebind.ChangeBindingWithId("8b520cfa-e3f3-4427-9f26-67e75c45d247").WithPath("<Gamepad>/leftstick/down");
                actionToRebind.ChangeBindingWithId("0836ed78-0442-4bf1-8547-08865622ca71").WithPath("<Gamepad>/leftstick/left");
                break;
        }
        actionToRebind.Enable();
        gameControl.colorKeySet();
    }
}
