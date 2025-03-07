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
        buttonStart = GameObject.Find("StartButton");
        firstWave = true;
    }

    private void Update()
    {
        moneyPrint.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    private bool firstWave;

    public void StartNextWave()
    {

        if (currentWave <= wave.Length)
        {
            if(firstWave)
            {
                Instantiate(wave[currentWave], spawnPoint);
                firstWave=false;
            }
            else
            {
                currentWave++;
                Instantiate(wave[currentWave], spawnPoint);
            }
            
        }
        else Victory();
    }

    private GameObject buttonStart;

    public void EndWave()
    {
        buttonStart.SetActive(true);
        Debug.Log("fin de la vague");
    }

    public void Victory()
    {
        Debug.Log("victoire");
    }

}
