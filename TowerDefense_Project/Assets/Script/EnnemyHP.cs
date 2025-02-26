using UnityEngine;

public class EnnemyHP : MonoBehaviour
{
    public int hp;


    public void Damage(int damage)
    {
        hp -= damage;
    }
}
