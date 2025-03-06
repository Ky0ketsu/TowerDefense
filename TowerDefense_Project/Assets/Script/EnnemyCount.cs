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
        if (enemyCount == 0)
        {
            gameManager.GetComponent<GameManager>().EndWave();
        }
    }

}
