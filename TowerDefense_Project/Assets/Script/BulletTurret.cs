using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    public Transform currentTarget;
    public float missileSpeed;
    public float currentDamage;


    public void Update()
    {
        Vector3 dir = currentTarget.position - transform.position;
        transform.Translate(dir.normalized * missileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == currentTarget.transform.name)
        {
            Debug.Log("toucher");
            other.transform.parent.GetComponent<EnnemyHP>().Damage(currentDamage);

            Destroy(gameObject);
        }
    }
}
