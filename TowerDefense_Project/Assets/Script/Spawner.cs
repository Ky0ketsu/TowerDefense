using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ennemy1, ennemy2, ennemy3;

    public int ennemy1Stay, ennemy2Stay, ennemy3Stay;

    public void Spawn1(int numEnnemy1)
    {
        ennemy1Stay = numEnnemy1;
        StartCoroutine(SpawnEnnemy1());
        ennemy1Stay--;
    }

    IEnumerator SpawnEnnemy1()
    {
        yield return new WaitForSeconds(1);
        Instantiate(ennemy1, transform);
        SpawnEnnemy1Loop();
    }

    private void SpawnEnnemy1Loop()
    {
        if (ennemy1Stay > 0)
        {
            StartCoroutine(SpawnEnnemy1());
            ennemy1Stay--;
        }
    }

    public void Spawn2(int numEnnemy2)
    {

    }

    public void Spawn3(int numEnnemy3)
    {

    }

}
