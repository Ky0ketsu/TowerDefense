using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject menu;
    public bool isOpen;
    private Vector3 startScale;

    private void Start()
    {
        menu = GameObject.Find("BuildMenu");
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("BuildMenu"))
        {
            if (isOpen)
            {
                isOpen = false;
                menu.SetActive(false);
            }
            else
            {
                isOpen = true;
                menu.SetActive(true);
            }
        }
    }
}
