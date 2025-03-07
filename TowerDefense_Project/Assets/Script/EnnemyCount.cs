using UnityEngine;

public class EnnemyCount : MonoBehaviour
{

    public int enemyCount;
    private GameObject gameManager;

    private void Start()
    {
        enemyCount = transform.childCount;
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        enemyCount = transform.childCount;

        if (enemyCount == 0)
        {
            gameManager.GetComponent<GameManager>().EndWave();
            Destroy(gameObject);
        }
    }

}
