using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool selectMap;
    public GameObject volumeUI, deathUI, victoryUI, transisiUI, exitUI;
    public GameObject player, enemy;
    public Button sumatera, kalimantan, jawa, sulawesi, papua;

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
            if (selectMap)
            {
                LoadPulau();
            }
        }
        else
        {
            yield return new WaitForSeconds(1);
            LoadHPPlayer();
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

        CheatPulau();
    }


    void LoadHPPlayer()
    {
        player.GetComponent<PlayerController>().maxHp = PlayerPrefs.GetFloat("MaxHP");
        player.GetComponent<PlayerController>().hp = player.GetComponent<PlayerController>().maxHp;
        player.GetComponent<PlayerController>().UpdateUI();
    }
    void LoadPulau()
    {
        if (PlayerPrefs.GetString("PrologAkhir") == "")
        {
            if (PlayerPrefs.GetString("sumatera") == "") sumatera.interactable = true;
            else sumatera.interactable = false;

            if (PlayerPrefs.GetString("kalimantan") == "") kalimantan.interactable = true;
            else kalimantan.interactable = false;

            if (PlayerPrefs.GetString("jawa") == "") jawa.interactable = true;
            else jawa.interactable = false;

            if (PlayerPrefs.GetString("sulawesi") == "") sulawesi.interactable = true;
            else sulawesi.interactable = false;

            if (PlayerPrefs.GetString("papua") == "") papua.interactable = true;
            else papua.interactable = false;
        }


        if (PlayerPrefs.GetString("PrologAkhir") == "")
        {
            if (PlayerPrefs.GetString("sumatera") != "" && PlayerPrefs.GetString("kalimantan") != "" && PlayerPrefs.GetString("jawa") != "" && PlayerPrefs.GetString("sulawesi") != "" && PlayerPrefs.GetString("papua") != "")
            {
                PlayerPrefs.SetString("PrologAkhir", "Sudah");
                SceneManager.LoadScene("PrologAkhir");
            }
        }
    }

    void CheatPulau()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetString("sumatera", "Sudah");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetString("kalimantan", "Sudah");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerPrefs.SetString("jawa", "Sudah");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerPrefs.SetString("sulawesi", "Sudah");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayerPrefs.SetString("papua", "Sudah");
        }
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
        BattleManager.instance.KunciPulau();

        //Bonus selesaikan pulau
        PlayerPrefs.SetFloat("MaxHP", player.GetComponent<PlayerController>().maxHp += 20);

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
    public void LoadPapua()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Papua");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void LoadKalimantan()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Kalimantan");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void LoadJawa()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Jawa");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void LoadSulawesi()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Sulawesi");
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
    public void LoadInstruction()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Instruction");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void LoadStoryOfIndonesia()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("StoryOfIndonesia");
        }

        AudioManager.Instance.ClickButtonSfx();
    }
    public void StartGame()
    {
        if (PlayerPrefs.GetString("Prolog") == "")
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                PlayerPrefs.SetString("Prolog", "Sudah");
                StartTransisi();
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene("Prolog");
            }
        }
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                StartTransisi();
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene("SelectMap");
            }
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
