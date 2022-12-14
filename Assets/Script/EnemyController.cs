using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int levelEnemy = 1;

    public static EnemyController instance;
    public float maxHp, hp;

    public Image barHP;
    public Text barHPText;

    public Animator animatorMove, animatorBody;

    public GameObject damageText;
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
        GameObject damageTextObject = Instantiate(damageText, transform);
        damageTextObject.GetComponent<DamageText>().damageText.text = "-20";
        damageTextObject.GetComponent<DamageText>().transform.localScale = new Vector3(1, 1, 1);

        UpdateUI();
        Death();

        AudioManager.Instance.DamageSfx();
    }
    void UpdateUI()
    {
        barHP.fillAmount = hp / maxHp;
        barHPText.text = hp.ToString();
    }

    void Death()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            if (hp <= 0)
            {
                hp = 0;
                BattleManager.instance.NextLevel();
                yield return new WaitForSeconds(1);
                animatorBody.SetTrigger("Death");
                yield return new WaitForSeconds(1);
                animatorMove.SetTrigger("Death");

                yield return new WaitForSeconds(1);

                levelEnemy++;
                if (levelEnemy == 4)
                {
                    print("Pulau tertaklukan");
                    GameManager.instance.VictoryUI();
                }
                else
                {
                    hp = 100;
                    UpdateUI();

                    animatorMove.SetTrigger("Spawn");
                    animatorBody.SetTrigger("Spawn");
                }
            }
        }

    }
}
