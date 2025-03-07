using UnityEngine;

public class EnnemyHP : MonoBehaviour
{
    public int baseMoney;
    
    public float hp;
    public float baseHP;

    private GameObject gameManager;

    public Transform hpBar;
    public float maxHp;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager");
        hpBar = transform.GetChild(1).GetChild(0);

        hp = baseHP + baseHP * gameManager.GetComponent<GameManager>().currentWave;  
        maxHp = hp;
        Debug.Log("spawn");
    }

    public void Update()
    {
        hpBar.localScale = new Vector3( (hp/maxHp) , 1, 1);

        if(hp == maxHp)
        {
            hpBar.parent.gameObject.SetActive(false);
        }
        else hpBar.parent.gameObject.SetActive(true);
    }


    public void Damage(float damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            gameManager.GetComponent<GameManager>().money += baseMoney + baseMoney * gameManager.GetComponent<GameManager>().currentWave;
            Destroy(gameObject);
        }
    }
}
