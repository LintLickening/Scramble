using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Tilemap floor;
    public Tilemap walls;
    public Tilemap pillars;
    public GameObject cubePrefab;
    public int gameLevel = 0;
    private GameObject door;
    public bool button1 = false;
    public bool button2 = false;
    public bool button3 = false;
    public bool button4 = false;
    public Sprite doorUpSprite;
    public Sprite doorDownSprite;
    public Sprite gateOpenSprite;
    public GameObject[] player;
    public GameObject player1Camera;
    public GameObject player2Camera;
    public GameObject keyPrefab;
    private int keySpawnCount = 0;
    private float timeValue = 5;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scrambleText;
    public Image timerBackground;
    public GameObject levelContainer;
    public GameObject currentLevelController;
    public int colorScheme;
    private Vector4 color;
    private int switchControlCount = 0;
    public InputActionReference Movement;
    [SerializeField]
    public int redKeySet;
    public int yellowKeySet;
    public int blueKeySet;
    public int greenKeySet;
    public int purpleKeySet;
    public int orangeKeySet;
    public string colorName = "";
    public string currentDoor = "";
    public GameObject currentDoorObject;
    public bool buttonUnlock = false;
    private int addTimeValue = 0;
    private float startingTimeValue;
    public AudioSource levelMusic;
    public AudioSource safeMusic;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public AudioSource keySpawnSound;
    public AudioSource laserSound;
    public AudioSource bossMusic;
    public Animator transition;
    private int openDoorCount = 0;
    private int doorsOpen = 0;
    public GameObject laserSpawnPrefab;
    public GameObject laserPrefab;
    private int roomsCleared = 0;
    public GameObject crystalPrefab;
    private int crystalSpawnCount = 0;
    public GameObject crystalScreenObject;
    private int stunnedPlayers = 0;
    public GameObject colorChangeCamera;
    public Animator bossAnimator;
    public Material bossMaterial;
    public GameObject bossPrefab;
    private int switchColorCount = 0;
    public SceneInfo sceneInfo;
    private int movePlayersCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = true;
        color = new Vector4(255, 255, 255, 255);
        colorScheme = Random.Range(1, 6);
        door = GameObject.FindGameObjectWithTag("Door");
        player = GameObject.FindGameObjectsWithTag("Player");
        gameLevel = 1;
        if (gameLevel == 1)
        {
            levelMusic.Play();
            currentLevelController = GameObject.Find("Level1");
            buttonUnlock = true;
            startingTimeValue = 60;
            timeValue = startingTimeValue;
        }
        foreach (GameObject player in player)
        {
            player.transform.SetParent(currentLevelController.transform);
        }
    }


    // Update is called once per frame
    void Update()
    {
        switch (colorScheme)
        {
            case 1:
                color = new Vector4(1, 0.29f, 0.29f, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(1, 0, 0, 0) * 60f);
                colorName = "Red";
                break;
            case 2:
                color = new Vector4(1, 1, 0.49f, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(1, 1, 0, 0) * 60f);
                colorName = "Yellow";
                break;
            case 3:
                color = new Vector4(0.51f, 0.54f, 1, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(0f, 0f, 1, 0) * 60f);
                colorName = "Blue";
                break;
            case 4:
                color = new Vector4(0.55f, 1, 0.51f, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(0, 1, 0, 0) * 60f);
                colorName = "Green";
                break;
            case 5:
                color = new Vector4(0.82f, 0.51f, 1, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(0.59f, 0, 1, 0) * 60f);
                colorName = "Purple";
                break;
            case 6:
                color = new Vector4(1, 0.73f, 0.51f, 1);
                bossMaterial.SetColor("_GlowColor", new Vector4(1, 0.73f, 0, 0) * 60f);
                colorName = "Orange";
                break;
        }
        if(sceneInfo.isPreviousScene == true && movePlayersCount < 1)
        {
            gameLevel = sceneInfo.gameLevel;
            foreach (GameObject players in player)
            {
                if(players.name == "Player1")
                {
                    players.transform.position = sceneInfo.player1Position;
                }
                else if(players.name == "Player2")
                {
                    players.transform.position = sceneInfo.player2Position;
                }
            }
            EndGame();
            movePlayersCount++;
        }
        switch (gameLevel)
        {
            case 1:
                if (button1 == true && button2 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(-30f, -2f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 2:
                if (button2 == true && button3 == true)
                {
                    buttonUnlock = true;
                }
                if (button1 == true && button2 == true && button3 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(17f, -33f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 3:
                if (button1 == true && button2 == true && button3 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(40.5f, -33.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 4:
                if(button1 == true && button2 == true && button3 == true && button4 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(17.5f, -50.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 5:
                if(button1 == true && button2 == true && button3 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(40.5f, -50.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 6:
                if(button1 == true && button2 == true && button3 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(17.5f, -66.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 7:
                if(button1 == true && button2 == true && button3 == true && button4 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(40.5f, -67f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 8:
                if (button1 == true && button2 == true && button3 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(17.5f, -81.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 9:
                if (button1 == true && button2 == true && button3 == true && button4 == true && keySpawnCount < 1)
                {
                    Instantiate(keyPrefab, new Vector3(40.5f, -82.5f, 0f), Quaternion.identity);
                    GameObject key = GameObject.FindGameObjectWithTag("Key");
                    key.transform.SetParent(currentLevelController.transform);
                    keySpawnSound.Play();
                    keySpawnCount++;
                }
                break;
            case 11:
                if (button2 == true && button3 == true)
                {
                    buttonUnlock = true;
                }
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(47.5f, 50.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 12:
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(71.5f, 50.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 13:
                if (button1 == true && button2 == true && button3 == true && button4 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(95.5f, 50.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 14:
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(119.5f, 50.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 15:
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(143.5f, 52.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 16:
                if (button1 == true && button2 == true && button3 == true && button4 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(167.5f, 50.5f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 17:
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(191.5f, 55f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
            case 18:
                if (button1 == true && button2 == true && button3 == true && crystalSpawnCount < 1)
                {
                    Instantiate(crystalPrefab, new Vector3(215.5f, 53f, 0f), Quaternion.identity);
                    keySpawnSound.Play();
                    foreach (GameObject players in player)
                    {
                        players.GetComponent<Player>().crystalActive = true;
                    }
                    crystalSpawnCount++;
                    roomsCleared++;
                }
                break;
        }
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        if (timeValue < 0)
        {
            SwitchColors();
        }
        DisplayTime(timeValue);
    }

    void SwitchColors()
    {
        if(addTimeValue >= 3)
        {
            SceneManager.LoadScene("LossCutscene");
        }
        else if (switchColorCount < 1 && addTimeValue < 3)
        {
            GameObject bossSpawned = Instantiate(bossPrefab, new Vector3(19.5f, 113.5f, 0), Quaternion.identity);
            bossAnimator = bossSpawned.GetComponent<Animator>();
            timeText.enabled = false;
            timerBackground.enabled = false;
            player1Camera.SetActive(false);
            player2Camera.SetActive(false);
            colorChangeCamera.SetActive(true);
            scrambleText.enabled = true;
            bossAnimator.SetTrigger("Move");
            switchColorCount++;
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TriggerRebind()
    {
        player1Camera.SetActive(true);
        player2Camera.SetActive(true);
        colorChangeCamera.SetActive(false);
        scrambleText.enabled = false;
        colorChangeCamera.transform.position = new Vector3(31f, 113.5f, -1f);
        if (switchControlCount < 1)
        {
            switchControlCount++;
            foreach (Transform child in levelContainer.transform)
            {
                foreach (GameObject players in player)
                {
                    foreach (Transform playerChild in players.transform)
                    {
                        if (playerChild.GetComponent<SpriteRenderer>() != null && playerChild.tag != "Key")
                        {
                            playerChild.gameObject.GetComponent<SpriteRenderer>().color = color;
                        }
                    }
                }
                foreach (Transform kids in child)
                {
                    if (kids.GetComponent<SpriteRenderer>() != null && kids.tag != "Key")
                    {
                        kids.gameObject.GetComponent<SpriteRenderer>().color = color;
                    }
                    else
                    {
                        Debug.Log("No sprite renderer attached to " + kids.name);
                    }
                }
            }
            walls.GetComponent<Tilemap>().color = color;
            floor.GetComponent<Tilemap>().color = color;
            pillars.GetComponent<Tilemap>().color = color;
            DoRebind();
            addTimeValue++;
            if (addTimeValue < 4)
            {
                timeValue = startingTimeValue * 2;
                timeText.enabled = true;
                timerBackground.enabled = true;
            }
            switchColorCount = 0;
        }
    }

    private void DoRebind()
    {
        InputManager inputManager = this.gameObject.GetComponent<InputManager>();
        inputManager.StartRebind();
    }

    public void colorKeySet()
    {
        InputManager inputManager = this.gameObject.GetComponent<InputManager>();
        switch(colorName)
        {
            case "Red":
                redKeySet = inputManager.chosenBinding;
                Debug.Log(redKeySet);
                break;
            case "Yellow":
                yellowKeySet = inputManager.chosenBinding;
                Debug.Log(yellowKeySet);
                break;
            case "Blue":
                blueKeySet = inputManager.chosenBinding;
                Debug.Log(blueKeySet);
                break;
            case "Green":
                greenKeySet = inputManager.chosenBinding;
                Debug.Log(greenKeySet);
                break;
            case "Purple":
                purpleKeySet = inputManager.chosenBinding;
                Debug.Log(purpleKeySet);
                break;
            case "Orange":
                orangeKeySet = inputManager.chosenBinding;
                Debug.Log(orangeKeySet);
                break;
        }
        switchControlCount = 0;
    }

    public void OpenDoor()
    {
        button1 = false;
        button2 = false;
        button3 = false;
        button4 = false;
        keySpawnCount = 0;
        foreach (GameObject players in player)
        {
            players.GetComponent<Player>().speed = 0;
        }
        if (openDoorCount < 1)
        {
            doorOpenSound.Play();
            StartCoroutine(loadNextLevel());
            openDoorCount++;
        }
    }

    IEnumerator loadNextLevel()
    {
        if(gameLevel != 0)
        {
            timeValue = 99999999999;
            timeText.enabled = false;
            timerBackground.enabled = false;
        }
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);
        doorCloseSound.Play();
        yield return new WaitForSeconds(1);

        transition.SetTrigger("End");

        openDoorCount = 0;

        foreach (GameObject players in player)
        {
            players.GetComponent<Player>().speed = 5;
        }

        if (gameLevel != 0)
        {
            GameObject key = GameObject.FindGameObjectWithTag("Key");
            switch (gameLevel)
            {
                case 1:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(11f, -2.5f, 0);
                    }
                    break;
                case 2:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(17.45f, -15.5f, 0);
                    }
                    break;
                case 3:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(32.5f, -15.5f, 0);
                    }
                    break;
                case 4:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(17.5f, 11.5f, 0);
                    }
                    break;
                case 5:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(32.5f, 11.5f, 0);
                    }
                    break;
                case 6:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(19.5f, 8.75f, 0);
                    }
                    break;
                case 7:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(19.5f, -12f, 0);
                    }
                    break;
                case 8:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(30.5f, 8.5f, 0);
                    }
                    break;
                case 9:
                    foreach (GameObject players in player)
                    {
                        players.transform.position = new Vector3(30.5f, -12.5f, 0);
                    }
                    break;

            }
            gameLevel = 0;
            doorsOpen++;
            levelMusic.Stop();
            safeMusic.Play();
            Destroy(key);
        }
        if (gameLevel == 0)
        {
            if (currentDoorObject.GetComponent<SpriteRenderer>().sprite != doorUpSprite && currentDoorObject.GetComponent<SpriteRenderer>().sprite != doorDownSprite)
            {
                switch (currentDoor)
                {
                    case "Door2":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorDownSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        buttonUnlock = false;
                        timeValue = 30;
                        gameLevel = 2;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(17.5f, -29f, 0);
                            currentLevelController = GameObject.Find("Level 2");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door3":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorDownSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 30;
                        gameLevel = 3;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(40.5f, -29f, 0);
                            currentLevelController = GameObject.Find("Level 3");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door4":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorUpSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 30;
                        gameLevel = 4;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(17.5f, -55.2f, 0);
                            currentLevelController = GameObject.Find("Level 4");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door5":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorUpSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 20;
                        gameLevel = 5;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(40.5f, -55.2f, 0);
                            currentLevelController = GameObject.Find("Level 5");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door6":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorDownSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 25;
                        gameLevel = 6;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(17.5f, -63f, 0);
                            currentLevelController = GameObject.Find("Level 6");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door7":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorUpSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 40;
                        gameLevel = 7;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(40.5f, -71.5f, 0);
                            currentLevelController = GameObject.Find("Level 7");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door8":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorDownSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 20;
                        gameLevel = 8;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(17.5f, -81.5f, 0);
                            currentLevelController = GameObject.Find("Level 8");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door9":
                        currentDoorObject.GetComponent<SpriteRenderer>().sprite = doorUpSprite;
                        currentDoor = "";
                        currentDoorObject = null;
                        timeText.enabled = true;
                        timerBackground.enabled = true;
                        timeValue = 20;
                        gameLevel = 9;
                        foreach (GameObject players in player)
                        {
                            players.transform.position = new Vector3(40.5f, -88.5f, 0);
                            currentLevelController = GameObject.Find("Level 9");
                            players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                        }
                        break;
                    case "Door10":
                        if (doorsOpen == 9)
                        {
                            currentDoor = "";
                            SceneManager.LoadScene("BossCutscene");
                        }
                        break;
                }
                if(addTimeValue > 0)
                {
                    timeValue *= 2;
                }
                if (gameLevel != 10)
                {
                    safeMusic.Stop();
                    levelMusic.Play();
                }
            }
            else
            {
                Debug.Log("Door is already open");
            }
        }
        foreach (GameObject players in player)
        {
            buttonUnlock = true;
            players.GetComponent<Player>().hasKey = false;
            players.GetComponent<Player>().doorCanOpen = false;
        }
        startingTimeValue = timeValue;
    }


    private void EndGame()
    {
        levelMusic.Stop();
        safeMusic.Stop();
        if (bossMusic.isPlaying == false)
        {
            bossMusic.Play();
        }
        StartCoroutine(Lasers());
        player1Camera.GetComponent<Camera>().orthographicSize = 14;
        player2Camera.GetComponent<Camera>().orthographicSize = 14;
    }
    IEnumerator Lasers()
    {
        for(var i = 0; i < 3; i++)
        {
            int attackNum = Random.Range(1, 4);
            stunnedPlayers = 0;
            yield return new WaitForSeconds(3);
            switch (attackNum)
            {
                case 1:
                    StartCoroutine(vertLasers());
                    break;
                case 2:
                    StartCoroutine(crossLasers());
                    break;
                case 3:
                    StartCoroutine(TLaser());
                    break;
            }
            foreach (GameObject players in player)
            {
                if (players.GetComponent<Player>().speed == 0)
                {
                    stunnedPlayers++;
                }
            }
            if (stunnedPlayers == 2)
            {
                SceneManager.LoadScene("LossCutscene");
            }
        }
        if (stunnedPlayers == 2)
        {
            SceneManager.LoadScene("LossCutscene");
        }
        else
        {
            Debug.Log("Next level");
            yield return new WaitForSeconds(2);
            roomsCleared++;
            StartCoroutine(crystalScreen());
        }
    }

    private void StartRooms()
    {
        foreach (GameObject players in player)
        {
            buttonUnlock = true;
            players.gameObject.GetComponent<Player>().speed = 5f;
            players.gameObject.GetComponent<Player>().disabled = false;
            stunnedPlayers = 0;
        }
        button1 = false;
        button2 = false;
        button3 = false;
        button4 = false;
        crystalSpawnCount = 0;
        player1Camera.GetComponent<Camera>().orthographicSize = 6;
        player2Camera.GetComponent<Camera>().orthographicSize = 6;
        switch (roomsCleared)
        {
            case 1:
                gameLevel = 11;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 30;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(47.5f, 55.5f, 0);
                    currentLevelController = GameObject.Find("Level 11");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 2:
                gameLevel = 12;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 30;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(71.5f, 55.5f, 0);
                    currentLevelController = GameObject.Find("Level 12");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 4:
                gameLevel = 13;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 30;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(95.5f, 46.5f, 0);
                    currentLevelController = GameObject.Find("Level 13");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 5:
                gameLevel = 14;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 20;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(119.5f, 46.5f, 0);
                    currentLevelController = GameObject.Find("Level 14");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 7:
                gameLevel = 15;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 25;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(143.5f, 46.5f, 0);
                    currentLevelController = GameObject.Find("Level 15");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 8:
                gameLevel = 16;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 40;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(167.5f, 55.5f, 0);
                    currentLevelController = GameObject.Find("Level 16");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 10:
                gameLevel = 17;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 20;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(191.5f, 46.5f, 0);
                    currentLevelController = GameObject.Find("Level 17");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 11:
                gameLevel = 18;
                timeText.enabled = true;
                timerBackground.enabled = true;
                timeValue = 20;
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(215.5f, 55.5f, 0);
                    currentLevelController = GameObject.Find("Level 18");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            case 12:
                Instantiate(crystalPrefab, new Vector3(26f, 75.5f, 0f), Quaternion.identity);
                player1Camera.GetComponent<Camera>().orthographicSize = 14;
                player2Camera.GetComponent<Camera>().orthographicSize = 14; 
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(26f, 72.75f, 0);
                    currentLevelController = GameObject.Find("Level 10");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
            default:
                gameLevel = 10;
                EndGame();
                foreach (GameObject players in player)
                {
                    players.transform.position = new Vector3(26f, 72.75f, 0);
                    currentLevelController = GameObject.Find("Level 10");
                    players.gameObject.transform.parent = currentLevelController.gameObject.transform;
                }
                break;
                startingTimeValue = timeValue;
        }
        startingTimeValue = timeValue;
    }

    IEnumerator vertLasers()
    {
        for (var i = 0; i < 7; i++)
        {
            Instantiate(laserSpawnPrefab, new Vector3(19.5f + i * 2, 86.5f, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.4f);
        laserSound.Play();
        for (var i = 0; i < 7; i++)
        {
            GameObject laser = Instantiate(laserPrefab, new Vector3(19.5f + (i * 2), 85.99f, 0), Quaternion.identity);
            while (laser.transform.localScale.y <= 35)
            {
                laser.transform.localScale += new Vector3(0, 0.1f, 0);
                laser.transform.localPosition -= new Vector3(0, 0.05f, 0);
            }
            if (laser.transform.localScale.y >= 35)
            {
                laser.gameObject.GetComponent<Laser>().startFading();
            }
        }
    }

    IEnumerator crossLasers()
    {

        GameObject spawn1 = Instantiate(laserSpawnPrefab, new Vector3(17.076f, 87.759f, 0f), Quaternion.identity);
        GameObject spawn2 = Instantiate(laserSpawnPrefab, new Vector3(34.932f, 37.769f, 0f), Quaternion.identity);
        spawn1.transform.rotation = Quaternion.Euler(0, 0, 48);
        spawn2.transform.rotation = Quaternion.Euler(0, 0, -48);
        yield return new WaitForSeconds(0.4f);
        laserSound.Play();
        GameObject laser1 = Instantiate(laserPrefab, new Vector3(17.4567f, 87.4174f, 0f), Quaternion.identity);
        GameObject laser2 = Instantiate(laserPrefab, new Vector3(34.558f, 87.4307f, 0f), Quaternion.identity);
        laser1.transform.rotation = Quaternion.Euler(0, 0, 48);
        laser2.transform.rotation = Quaternion.Euler(0, 0, -48); ;
        while (laser1.transform.localScale.y <= 25)
        {
            laser1.transform.localScale += new Vector3(0, 0.1f, 0);
            laser1.transform.localPosition += new Vector3(0.0355f, -0.0325f, 0);
            laser2.transform.localScale += new Vector3(0, 0.1f, 0);
            laser2.transform.localPosition += new Vector3(-0.0355f, -0.0325f, 0);
        }
        if (laser1.transform.localScale.y >= 25)
        {
            laser1.gameObject.GetComponent<Laser>().startFading();
            laser2.gameObject.GetComponent<Laser>().startFading();
        }
    }

    IEnumerator TLaser()
    {
        for(var i = 0; i < 4; i++)
        {
            Instantiate(laserSpawnPrefab, new Vector3(24.5f + i, 33.5f, 0), Quaternion.identity);
        }
        for(var i = 0; i < 3; i++)
        {
            GameObject laserSpawn = Instantiate(laserSpawnPrefab, new Vector3(17.5f, 76.5f + i, 0), Quaternion.identity);
            laserSpawn.transform.rotation = Quaternion.Euler(0,0,90);
        }
        yield return new WaitForSeconds(0.4f);
        laserSound.Play();
        for(var i = 0; i < 4; i++)
        {
            GameObject laser = Instantiate(laserPrefab, new Vector3(24.5f + i, 86.99f, 0), Quaternion.identity);
            while (laser.transform.localScale.y <= 35)
            {
                laser.transform.localScale += new Vector3(0, 0.1f, 0);
                laser.transform.localPosition -= new Vector3(0, 0.05f, 0);
            }
            if (laser.transform.localScale.y >= 35)
            {
                laser.gameObject.GetComponent<Laser>().startFading();
            }
        }
        for(var i = 0; i < 3; i++)
        {
            GameObject laser = Instantiate(laserPrefab, new Vector3(26.99f, 76.5f + i, 0), Quaternion.identity);
            laser.transform.rotation = Quaternion.Euler(0, 0, -90);
            while (laser.transform.localScale.y <= 35)
            {
                laser.transform.localScale += new Vector3(0, 0.1f, 0);
                laser.transform.localPosition -= new Vector3(-0.0225f, 0f, 0);
            }
            if (laser.transform.localScale.y >= 35)
            {
                laser.gameObject.GetComponent<Laser>().startFading();
            }
        }
    }

    public void BreakCrystal()
    {
        Debug.Log("Fuck with time");
        Animator crystalAnimator = GameObject.FindGameObjectWithTag("Crystal").GetComponent<Animator>();
        crystalAnimator.SetTrigger("Break");
        timeValue = 99999999999;
        timeText.enabled = false;
        timerBackground.enabled = false;
    }

    public void crystalScreenStart()
    {
        StartCoroutine(crystalScreen());
    }

    IEnumerator crystalScreen()
    {
        Debug.Log("Flashbang out");
        crystalScreenObject.gameObject.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        crystalScreenObject.gameObject.GetComponent<Animator>().SetTrigger("End");
        if (roomsCleared < 13)
        {
            if (roomsCleared == 12)
            {
                StartRooms();
                roomsCleared++;
            }
            else
            {
                StartRooms();
            }
        }
        else
        {
            foreach (GameObject players in player)
            {
                players.GetComponent<Player>().speed = 0;
            }
            SceneManager.LoadScene("EndCutscene");
        }
    }
}
