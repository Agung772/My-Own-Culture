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
            SpawnDialogBoxLevel1(UnityEngine.Random.Range(0, pertanyaanLevel1.Count));
        }
        else if (level == 2 || level == 3)
        {
            SpawnDialogBoxLevel2(UnityEngine.Random.Range(0, pertanyaanLevel2.Count));
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
