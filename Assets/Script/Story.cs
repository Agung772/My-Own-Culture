using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public bool storyAkhir;
    public Text[] text;
    int textInt;
    public void Next()
    {
        ResetText();
        textInt++;
        if (textInt == text.Length && !storyAkhir)
        {
            GameManager.instance.LoadSelectMap();
        }
        else if (textInt == text.Length && storyAkhir)
        {
            GameManager.instance.LoadMainmenu();
        }
        else if (textInt < text.Length)
        {
            text[textInt].gameObject.SetActive(true);
        }

        AudioManager.Instance.ClickButtonSfx();
    }

    void ResetText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].gameObject.SetActive(false);
        }
    }
}
