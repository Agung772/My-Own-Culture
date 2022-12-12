using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public bool SetVolumeDefault;
    public float saveBGM, saveSFX;
    public Image barBGM, barSFX;
    public Text barBGMText, barSFXText;
    public AudioSource audioSourceBGM, audioSourceSFX;
    public AudioClip clickButton;

    private void Start()
    {
        if (SetVolumeDefault)
        {
            PlayerPrefs.SetFloat("saveBGM", 5);
            PlayerPrefs.SetFloat("saveSFX", 5);
        }
        saveBGM = PlayerPrefs.GetFloat("saveBGM");
        saveSFX = PlayerPrefs.GetFloat("saveSFX");

        UpdateVolume();
    }
    public void PlusBGM()
    {
        saveBGM++;
        UpdateVolume();
    }
    public void MinusBGM()
    {
        saveBGM--;
        UpdateVolume();
    }
    public void PlusSFX()
    {
        saveSFX++;
        UpdateVolume();
    }
    public void MinusSFX()
    {
        saveSFX--;
        UpdateVolume();
    }
    void UpdateVolume()
    {
        saveBGM = Mathf.Clamp(saveBGM, 0, 10);
        saveSFX = Mathf.Clamp(saveSFX, 0, 10);

        PlayerPrefs.SetFloat("saveBGM", saveBGM);
        PlayerPrefs.SetFloat("saveSFX", saveSFX);

        barBGM.fillAmount = saveBGM / 10;
        barSFX.fillAmount = saveSFX / 10;

        barBGMText.text = saveBGM * 10 + "%";
        barSFXText.text = saveSFX * 10 + "%";

        audioSourceBGM.volume = saveBGM / 10;
        audioSourceSFX.volume = saveSFX / 10;
    }
    public void ClickButtonSfx()
    {
        audioSourceSFX.PlayOneShot(clickButton);
    }
}
