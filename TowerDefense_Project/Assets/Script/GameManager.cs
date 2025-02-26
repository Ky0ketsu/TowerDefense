using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float enemySpeedMult = 1;

    private GameObject spawner;

    private void Start()
    {
        spawner = GameObject.Find("SpawnPoint");
    }

    public void StartGame()
    {
        spawner.GetComponent<Spawner>().Spawn1(10);
    }

}
