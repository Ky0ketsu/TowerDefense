using UnityEngine;

public class ButtonTurret : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void SelectTurret(int ID)
    {
        gameManager.GetComponent<CursorCaseSelect>().DefineTurret(ID);
    }

}
