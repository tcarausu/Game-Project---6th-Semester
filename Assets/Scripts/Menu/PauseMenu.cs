using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI, optionsMenuUI, deadMenuUI, wonMenuUI;
    public static bool gameisPaused = false;


    private GameObject thePlayer;

    private PlayerBehaviourScript playerScript;
    private PlayerShootBow playerScriptBow;
    private PlayerMelee playerScriptMelee;

    private bool isMeleeScriptActive = true;

    private void Awake()
    {

        thePlayer = GameObject.Find("Player");

        playerScript = thePlayer.GetComponent<PlayerBehaviourScript>();
        playerScriptBow = thePlayer.GetComponent<PlayerShootBow>();
        playerScriptMelee = thePlayer.GetComponent<PlayerMelee>();
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPaused)
            {
                ResumeGame();
            }
            else
                PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            WonGame();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {

            DeadGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        deadMenuUI.SetActive(false);
        wonMenuUI.SetActive(false);

        Time.timeScale = 1f;
        gameisPaused = false;

        playerScript.enabled = true;

        if (isMeleeScriptActive)
        {
            playerScriptMelee.enabled = true;
        }
        else
        {
            playerScriptBow.enabled = true;
        }
    }

    public void DeadGame()
    {
        deadMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameisPaused = true;


        playerScript.enabled = false;

        if (playerScriptBow.enabled == true && playerScriptMelee.enabled == false)
        {
            isMeleeScriptActive = false;
        }
        else if (playerScriptBow.enabled == false && playerScriptMelee.enabled == true)
        {
            isMeleeScriptActive = true;
        }

        playerScriptMelee.enabled = false;
        playerScriptBow.enabled = false;
    }


    public void WonGame()
    {
        wonMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameisPaused = true;


        playerScript.enabled = false;

        if (playerScriptBow.enabled == true && playerScriptMelee.enabled == false)
        {
            isMeleeScriptActive = false;
        }
        else if (playerScriptBow.enabled == false && playerScriptMelee.enabled == true)
        {
            isMeleeScriptActive = true;
        }

        playerScriptMelee.enabled = false;
        playerScriptBow.enabled = false;
    }


    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameisPaused = true;


        playerScript.enabled = false;

        if (playerScriptBow.enabled == true && playerScriptMelee.enabled == false)
        {
            isMeleeScriptActive = false;
        }
        else if (playerScriptBow.enabled == false && playerScriptMelee.enabled == true)
        {
            isMeleeScriptActive = true;
        }

        playerScriptMelee.enabled = false;
        playerScriptBow.enabled = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }



    public void OpenMenu()
    {
        playerScriptMelee.enabled = false;
        playerScriptBow.enabled = false;
        isMeleeScriptActive = true;

        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        if (gameisPaused)
        {
            return;
        }
    }
}
