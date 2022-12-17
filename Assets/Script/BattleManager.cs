using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public bool noneGameplay;
    public enum BattleMap
    {
        sumatera, kalimantan, jawa, sulawesi, papua, none
    }
    public BattleMap battleMap;

    [Serializable]
    public struct PertanyaanLevel1
    {
        public string pertanyaan;
        public string a, b, c, d;
        public string jawabanBenar;
    }
    public List<PertanyaanLevel1> pertanyaanLevel1;
    public List<PertanyaanLevel1> pertanyaanLevel2;
    public List<PertanyaanLevel1> pertanyaanLevel3;

    public GameObject spawnDialogBox, dialogBox, notifikasiText;

    public int level;
    public Text levelText;

    private void Awake()
    {
        instance = this;

        if (battleMap == BattleMap.none)
        {
            noneGameplay = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnDialogBoxLevel1(UnityEngine.Random.Range(0, pertanyaanLevel1.Count));
        }
    }
    public void StartDialogBox()
    {
        if (battleMap == BattleMap.none)
        {

        }
        else
        {
            SpawnDialogBoxLevel();
        }
    }
    public void KunciPulau()
    {
        if (battleMap == BattleMap.sumatera) PlayerPrefs.SetString("sumatera", "kunci");
        if (battleMap == BattleMap.kalimantan) PlayerPrefs.SetString("kalimantan", "kunci");
        if (battleMap == BattleMap.jawa) PlayerPrefs.SetString("jawa", "kunci");
        if (battleMap == BattleMap.sulawesi) PlayerPrefs.SetString("sulawesi", "kunci");
        if (battleMap == BattleMap.papua) PlayerPrefs.SetString("papua", "kunci");
    }
    public void PlayerAttack()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0);
            PlayerController.instance.Attack();
            EnemyController.instance.TerHIT();
        }

        AudioManager.Instance.AttackSfx();
        print("Jawaban benar");
    }
    public void EnemyAttack()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0);
            EnemyController.instance.Attack();
            PlayerController.instance.TerHIT();
        }

        AudioManager.Instance.AttackSfx();
        print("Jawaban salah");
    }

    void SpawnDialogBoxLevel1(int urutanPertanyaan)
    {
        GameObject dialogBoxGameobject = Instantiate(dialogBox, spawnDialogBox.transform);
        dialogBoxGameobject.GetComponent<DialogBox>().IsiPertanyaan(pertanyaanLevel1[urutanPertanyaan].pertanyaan, pertanyaanLevel1[urutanPertanyaan].a, pertanyaanLevel1[urutanPertanyaan].b, pertanyaanLevel1[urutanPertanyaan].c, pertanyaanLevel1[urutanPertanyaan].d, pertanyaanLevel1[urutanPertanyaan].jawabanBenar);
    }
    void SpawnDialogBoxLevel2(int urutanPertanyaan)
    {
        GameObject dialogBoxGameobject = Instantiate(dialogBox, spawnDialogBox.transform);
        dialogBoxGameobject.GetComponent<DialogBox>().IsiPertanyaan(pertanyaanLevel2[urutanPertanyaan].pertanyaan, pertanyaanLevel2[urutanPertanyaan].a, pertanyaanLevel2[urutanPertanyaan].b, pertanyaanLevel2[urutanPertanyaan].c, pertanyaanLevel2[urutanPertanyaan].d, pertanyaanLevel2[urutanPertanyaan].jawabanBenar);
    }

    public void SpawnDialogBoxLevel()
    {
        if (level == 1)
        {
            countInt1++;
            randomPertanyaan1("1");
            SpawnDialogBoxLevel1(randomInt1);
        }
        else if (level == 2 || level == 3)
        {
            if (!oneUse2)
            {
                oneUse2 = true;
                oneUse1 = false;
                countInt1 = -1;
            }

            countInt1++;
            randomPertanyaan1("2");
            SpawnDialogBoxLevel2(UnityEngine.Random.Range(0, pertanyaanLevel2.Count));
        }
    }

    public bool[] randomBool1;
    public int randomInt1, countInt1;
    bool oneUse1, oneUse2;
    void randomPertanyaan1(string pertanyaan)
    {
        if (pertanyaan == "1")
        {
            if (!oneUse1)
            {
                oneUse1 = true;
                randomBool1 = new bool[pertanyaanLevel1.Count];
            }

            randomInt1 = UnityEngine.Random.Range(0, pertanyaanLevel1.Count);

            if (countInt1 == pertanyaanLevel1.Count)
            {
                countInt1 = 0;
                oneUse1 = false;
            }
        }
        else if (pertanyaan == "2")
        {
            if (!oneUse1)
            {
                oneUse1 = true;
                randomBool1 = new bool[pertanyaanLevel2.Count];
            }

            randomInt1 = UnityEngine.Random.Range(0, pertanyaanLevel2.Count);

            if (countInt1 == pertanyaanLevel2.Count)
            {
                countInt1 = 0;
                oneUse1 = false;
            }
        }


        if (randomInt1 == 0 && !randomBool1[0])
        {
            randomBool1[0] = true;
            randomInt1 = 0;
        }
        else if (randomInt1 == 1 && !randomBool1[1])
        {
            randomBool1[1] = true;
            randomInt1 = 1;
        }
        else if (randomInt1 == 2 && !randomBool1[2])
        {
            randomBool1[2] = true;
            randomInt1 = 2;
        }
        else if (randomInt1 == 3 && !randomBool1[3])
        {
            randomBool1[3] = true;
            randomInt1 = 3;
        }
        else if (randomInt1 == 4 && !randomBool1[4])
        {
            randomBool1[4] = true;
            randomInt1 = 4;
        }
        else if (randomInt1 == 5 && !randomBool1[5])
        {
            randomBool1[5] = true;
            randomInt1 = 5;
        }
        else if (randomInt1 == 6 && !randomBool1[6])
        {
            randomBool1[6] = true;
            randomInt1 = 6;
        }
        else if (randomInt1 == 7 && !randomBool1[7])
        {
            randomBool1[7] = true;
            randomInt1 = 7;
        }
        else if (randomInt1 == 8 && !randomBool1[8])
        {
            randomBool1[8] = true;
            randomInt1 = 8;
        }
        else if (randomInt1 == 9 && !randomBool1[9])
        {
            randomBool1[9] = true;
            randomInt1 = 9;
        }
        else if (randomInt1 == 10 && !randomBool1[10])
        {
            randomBool1[10] = true;
            randomInt1 = 10;
        }
        else if (randomInt1 == 11 && !randomBool1[11])
        {
            randomBool1[11] = true;
            randomInt1 = 11;
        }
        else if (randomInt1 == 12 && !randomBool1[12])
        {
            randomBool1[12] = true;
            randomInt1 = 12;
        }
        else if (randomInt1 == 13 && !randomBool1[13])
        {
            randomBool1[13] = true;
            randomInt1 = 13;
        }
        else if (randomInt1 == 14 && !randomBool1[14])
        {
            randomBool1[14] = true;
            randomInt1 = 14;
        }
        else if (randomInt1 == 15 && !randomBool1[15])
        {
            randomBool1[15] = true;
            randomInt1 = 15;
        }
        else
        {
            if (pertanyaan == "1")
            {
                randomPertanyaan1("1");
            }
            else if (pertanyaan == "2")
            {
                randomPertanyaan1("2");
            }


        }
    }

    public void NextLevel()
    {
        level++;

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0);
            if (level < 4)
            {
                levelText.text = "Level " + level;
            }
        }


    }

    public void SpawnNotifikasi(string jawaban)
    {
        GameObject damageTextObject = Instantiate(notifikasiText, transform);
        damageTextObject.GetComponent<DamageText>().damageText.text = "Jawaban yang benar adalah " + jawaban;
        damageTextObject.GetComponent<DamageText>().transform.position = new Vector3(0, 0, 0);
    }
}
