using NUnit.Framework;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float enemySpeedMult = 1;

    //private GameObject spawner;

    public int currentWave;

    public GameObject[] wave;

    private Transform spawnPoint;
    private bool waveIsEnd;

    private GameObject moneyPrint;
    public int money;

    private void Start()
    {
        //spawner = GameObject.Find("SpawnPoint");
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        money = 100;
        moneyPrint = GameObject.Find("Money");
    }

    private void Update()
    {
        moneyPrint.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    public void StartNextWave()
    {
        //spawner.GetComponent<Spawner>().Spawn1(10);

        if(currentWave <= wave.Length)
        {
            Instantiate(wave[currentWave], spawnPoint);
        }
    }


    public void EndWave()
    {
        Debug.Log("fin de la vague");
    }

}
