using UnityEngine;

public class EnnemyMove : MonoBehaviour
{
    private GameObject gameManager;

    public float speed;
    public float baseSpeed;
    public GameObject path;

    public Transform target;
    public int currentWaypoint;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");

        path = GameObject.Find("EnnemyPath");
        currentWaypoint = 0;
        target = path.GetComponent<EnnemyWay>().waypoint[currentWaypoint];
    }

    private void Update()
    {
        speed = baseSpeed * gameManager.GetComponent<GameManager>().enemySpeedMult;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(target.position, transform.position) < 0.2f && currentWaypoint < 15)
        {
            currentWaypoint++;
            target = path.GetComponent<EnnemyWay>().waypoint[currentWaypoint];
        }
    }
}
