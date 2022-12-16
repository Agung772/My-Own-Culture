using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public float saveBGM, saveSFX;
    public Image barBGM, barSFX;
    public Text barBGMText, barSFXText;
    public AudioSource audioSourceBGM, audioSourceSFX, audioSourceTime;
    public AudioClip clickButton, attack, damage, victory, defeat, switchDialogBox, detikan;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        saveBGM = PlayerPrefs.GetFloat("saveBGM");
        saveSFX = PlayerPrefs.GetFloat("saveSFX");

        UpdateVolume();
    }
    public void SetDefaultVolume()
    {
        PlayerPrefs.SetFloat("saveBGM", 2);
        PlayerPrefs.SetFloat("saveSFX", 5);
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
    public void AttackSfx()
    {
        audioSourceSFX.PlayOneShot(attack);
    }
    public void DamageSfx()
    {
        audioSourceSFX.PlayOneShot(damage);
    }
    public void VictorySfx()
    {
        audioSourceSFX.PlayOneShot(victory);
    }
    public void DefeatSfx()
    {
        audioSourceSFX.PlayOneShot(defeat);
    }
    public void SwitchDialogBoxSfx()
    {
        audioSourceSFX.PlayOneShot(switchDialogBox);
    }
    public void StartTimeSfx()
    {
        audioSourceTime.Play();
    }
    public void StopTimeSfx()
    {
        audioSourceTime.Stop();
    }
}
