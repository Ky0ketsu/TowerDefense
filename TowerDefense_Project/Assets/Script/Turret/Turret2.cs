using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

public class Turret2 : MonoBehaviour
{
    public GameObject missilePrefab;

    public float reloadTime;
    private Transform canon;

    public List<Transform> targets;
    public Transform currentTarget;
    public float damage;
    public float baseDamage;

    public float level;

    private bool canShoot;

    public float bulletSpeed;

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
        damage = baseDamage + baseDamage * level * 0.5f;

        if(targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] == null)
                {
                    targets.RemoveAt(i);
                }

            }

            targets = targets.OrderBy(targets => Vector3.Distance(transform.position, targets.position)).ToList();
            if (targets.Count() > 0)
            {
                currentTarget = targets[0];
            }
           

            if(currentTarget != null) canon.LookAt(new Vector3(currentTarget.position.x, canon.position.y, currentTarget.position.z));

        }

        if(canShoot & targets.Count > 0)
        {
            StartCoroutine(Shoot());
            canShoot = false;
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
            lastMissile.GetComponent<BulletTurret>().missileSpeed = bulletSpeed;
        }
        canShoot = true;
    }

}
