using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class EnnemyWay : MonoBehaviour
{
    public Transform[] waypoint;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            {
                
                waypoint[i] = transform.GetChild(i);
            }
        }
    }

}
