using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public enum BattleMap
    {
        sumatera, kalimantan, jawa, sulawesi, papua
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

    public GameObject spawnDialogBox, dialogBox;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        print(pertanyaanLevel1[0].jawabanBenar);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnDialogBox(UnityEngine.Random.Range(0, pertanyaanLevel1.Count));
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

        print("Jawaban salah");
    }

    void SpawnDialogBox(int urutanPertanyaan)
    {
        GameObject dialogBoxGameobject = Instantiate(dialogBox, spawnDialogBox.transform);
        dialogBoxGameobject.GetComponent<DialogBox>().IsiPertanyaan(pertanyaanLevel1[urutanPertanyaan].pertanyaan, pertanyaanLevel1[urutanPertanyaan].a, pertanyaanLevel1[urutanPertanyaan].b, pertanyaanLevel1[urutanPertanyaan].c, pertanyaanLevel1[urutanPertanyaan].d, pertanyaanLevel1[urutanPertanyaan].jawabanBenar);

    }
}
