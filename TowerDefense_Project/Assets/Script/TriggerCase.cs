using DG.Tweening;
using UnityEngine;

public class TriggerCase : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    /*public void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Case"))
        {
            gameManager.GetComponent<CursorCaseSelect>().currentCase = col.gameObject;
        }
        
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Case"))
        {
            other.transform.DORotate(new Vector3(0, Random.Range(-25, 25), 0), 0.25f).SetEase(Ease.OutFlash);
            gameManager.GetComponent<CursorCaseSelect>().currentCase = other.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Case"))
        {
            other.transform.DORotate(Vector3.zero, 0.25f).SetEase(Ease.OutExpo);

            gameManager.GetComponent<CursorCaseSelect>().currentCase = null;
        }
    }

}
