using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    private GameObject gameManager;

    public void StartButton()
    {
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().StartGame();
        gameObject.SetActive(false);
    }
}
