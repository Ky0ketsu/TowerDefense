using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Turret1 : MonoBehaviour
{
    public GameObject missilePrefab;

    public float reloadTime;
    private Transform canon;

    public List<Transform> targets;
    private Transform currentTarget;
    public int damage;

    private void Start()
    {
        canon = transform.GetChild(0).GetChild(1);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);
        }
    }

    private void Update()
    {
        if(targets.Count > 0)
        {
            targets = targets.OrderBy(targets => Vector3.Distance(transform.position, targets.position)).ToList();
            currentTarget = targets[0];

            canon.LookAt(new Vector3(currentTarget.position.x, canon.position.y, currentTarget.position.z));
        }
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(reloadTime);
        if (targets.Count > 0)
        {
            GameObject lastMissile = Instantiate(missilePrefab, transform);
            lastMissile.GetComponent<BulletTurret>().currentTarget = currentTarget;
            lastMissile.GetComponent<BulletTurret>().currentDamage = damage;
        }
        ShootLoop();
    }

    private void ShootLoop()
    {
        StartCoroutine(Shoot());
    }

}
