using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool setDefaultPlayerPrefs;
    public GameObject volumeUI, deathUI, victoryUI, transisiUI, exitUI;
    public GameObject player, enemy;
    bool exit;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;

        transisiUI.SetActive(true);
        ExitTransisi();

        if (PlayerPrefs.GetFloat("Default") == 0)
        {
            PlayerPrefs.SetFloat("Default", 1);

            AudioManager.Instance.SetDefaultVolume();
            PlayerPrefs.SetFloat("MaxHP", 100);
            
        }
    }
    IEnumerator Start()
    {

        if (BattleManager.instance.noneGameplay)
        {

        }
        else
        {
            LoadHPPlayer();
            yield return new WaitForSeconds(1);
            player.SetActive(true);
            enemy.SetActive(true);
            yield return new WaitForSeconds(1);
            BattleManager.instance.StartDialogBox();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!exit)
            {
                exit = true;
                ExitUI(true);
            }
            else if (exit)
            {
                exit = false;
                ExitUI(false);
            }

            AudioManager.Instance.ClickButtonSfx();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }


    void LoadHPPlayer()
    {
        player.GetComponent<PlayerController>().maxHp = PlayerPrefs.GetFloat("MaxHP");
    }

    int deleteInt;
    public void DeletePlayerPrefs()
    {
        deleteInt++;
        if (deleteInt >= 10)
        {
            PlayerPrefs.DeleteAll();
            AudioManager.Instance.ClickButtonSfx();
        }
    }
    public void VolumeUI(bool condition)
    {
        if (condition)
        {
            volumeUI.SetActive(true);
            exitUI.SetActive(false);
        }
        else
        {
            volumeUI.SetActive(false);
            exit = false;

            Time.timeScale = 1;
        }
    }
    public void ExitUI(bool condition)
    {
        if (condition)
        {
            exitUI.SetActive(true);
            volumeUI.SetActive(false);

            Time.timeScale = 0;
        }
        else
        {
            exitUI.SetActive(false);
            exit = false;

            Time.timeScale = 1;
        }
    }
    public void DeathUI()
    {
        deathUI.SetActive(true);

        AudioManager.Instance.DefeatSfx();
    }
    public void VictoryUI()
    {
        victoryUI.SetActive(true);

        AudioManager.Instance.VictorySfx();
    }

    public void LoadSelectMap()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("SelectMap");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void LoadSumatera()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Sumatera");
        }

        AudioManager.Instance.ClickButtonSfx();
    }

    public void LoadLevel()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        AudioManager.Instance.ClickButtonSfx();
    }

    public void LoadMainmenu()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Mainmenu");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void QuitGame()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            Application.Quit();
        }

        AudioManager.Instance.ClickButtonSfx();

    }

    public void StartTransisi()
    {
        transisiUI.GetComponent<Animator>().SetTrigger("Start");
        Time.timeScale = 1;
    }
    public void ExitTransisi()
    {
        transisiUI.GetComponent<Animator>().SetTrigger("Exit");
    }
}
