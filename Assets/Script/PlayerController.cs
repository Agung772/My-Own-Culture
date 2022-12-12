using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float maxHp, hp;

    public Image barHP;
    public Text barHPText;

    public Animator animatorMove, animatorBody;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        hp = maxHp;
    }

    public void Attack()
    {
        animatorMove.SetTrigger("Attack");

        float random = Random.Range(1, 3);
        if (random == 1) animatorBody.SetTrigger("Attack1");
        else if (random == 2) animatorBody.SetTrigger("Attack2");

    }
    public void TerHIT()
    {
        animatorBody.SetTrigger("Hit");

        hp -= 20;
        UpdateUI();
    }
    void UpdateUI()
    {
        barHP.fillAmount = hp / maxHp;
        barHPText.text = hp.ToString();
    }
}
