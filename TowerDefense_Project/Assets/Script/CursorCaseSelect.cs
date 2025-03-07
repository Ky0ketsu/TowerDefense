using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class CursorCaseSelect : MonoBehaviour
{
    public GameObject sphere;

    public GameObject[] turret;
    public GameObject turretSelected;

    public GameObject currentCase;

    private Vector3 cursorScreenPos;
    private Vector3 cursorWorldPos;

    private GameObject gameManager;
    private GameObject buildMenu;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        buildMenu = GameObject.Find("PlayScreen");
    }

    public void Update()
    {
        cursorScreenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(cursorScreenPos);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            cursorWorldPos = new Vector3(hit.point.x ,0, hit.point.z);
        }

        sphere.transform.position = cursorWorldPos;



        if(Input.GetButtonDown("Interact"))
        {
            if (turretSelected != null && currentCase != null && canPlaceTurret)
            {
                gameManager.GetComponent<GameManager>().money -= turretSelected.GetComponent<TurretStat>().cost;
                turretSelected.transform.parent = null;
                turretSelected.transform.position = new Vector3(currentCase.transform.position.x, 1, currentCase.transform.position.z);
                turretSelected = null;
                canPlaceTurret = false;
            }
        }

        if(Input.GetButtonDown("InteractRevert"))
        {
            if(turretSelected != null && canPlaceTurret)
            {
                Destroy(turretSelected);
                turretSelected = null;
                canPlaceTurret = false;
            }
        }


    }

    private bool canPlaceTurret;

    public void DefineTurret(int ID)
    {
        if(sphere.transform.childCount == 1)
        {
            turretSelected = turret[ID];
            
            if(turretSelected.GetComponent<TurretStat>().cost <=  gameManager.GetComponent<GameManager>().money)
            {
                turretSelected = Instantiate(turret[ID], sphere.transform);
                turretSelected.transform.localPosition = new Vector3(0, 2, 0);
                buildMenu.GetComponent<BuildMenu>().isOpen = false;
                buildMenu.GetComponent<BuildMenu>().menu.SetActive(false);
                canPlaceTurret = true;
            }
        }
    }



}
