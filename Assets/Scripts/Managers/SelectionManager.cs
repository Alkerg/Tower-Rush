using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{
    public Grid grid;
    public GameObject panelMenu;
    public bool panelMenuIsActive;
    public GameObject selectedTowerGO;

    private float minCameraSize = 4;
    private float maxCameraSize = 20;
    private TowerMenuController towerMenuController;
    private Camera gameCamera;
    void Start()
    {
        towerMenuController = panelMenu.GetComponent<TowerMenuController>();
        gameCamera = Camera.main.GetComponent<Camera>();
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Tower selectedTower;
            Vector3 offset = new Vector3(60,60,0);
            int layer = ~LayerMask.GetMask("UI");
            if (Physics.Raycast(ray, out hit,1000f, layer))
            {
                if (hit.transform.TryGetComponent<Tower>(out selectedTower))
                {
                    selectedTower.ToggleAttackRangeObject();
                    //panel.transform.position = Input.mousePosition + offset;
                    //panel.SetActive(true);
                    Debug.Log("TOWER: " + hit.transform.name);
                }
                else
                {
                    //panel.SetActive(false);
                    Debug.Log(hit.transform.name);
                }
            }
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            // Si hacemos clic sobre la interfaz de usuario, no hacemos nada
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            // Realizar un raycast para detectar si se hizo clic en una torre
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Si el objeto tiene el componente Tower, lo seleccionamos
                if (hit.collider.CompareTag("Tower"))
                {
                    SelectTower(hit.collider.gameObject);
                }
                else
                {
                    // Si no se hace clic en una torre, cerramos el menú
                    DeselectTower();
                }
            }
            else
            {
                // Si no golpea nada, cerramos el menú
                DeselectTower();
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0 && gameCamera.orthographicSize > minCameraSize)
        {
            gameCamera.orthographicSize -= 1;

        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0 && gameCamera.orthographicSize < maxCameraSize)
        {
            gameCamera.orthographicSize += 1;
        }

    }

    public virtual void TogglePanelMenu(Tower tower)
    {
        /*Vector3 offset = new Vector3(60, 60, 0);
        panelMenuIsActive = !panelMenuIsActive;
        panelMenu.transform.position = Input.mousePosition + offset;
        panelMenu.SetActive(panelMenuIsActive);*/
        panelMenuIsActive = !panelMenuIsActive;
        panelMenu.SetActive(panelMenuIsActive);

        // Actualizamos la información de la torre (puedes modificar esto según los atributos de tu torre)
        towerMenuController.SetNameTMP(tower.name);
        towerMenuController.SetSpeedTMP(tower.speed.ToString());
        towerMenuController.SetDamageTMP(tower.damage.ToString());

        Vector3 offset = new Vector3(60, 60, 0);
        panelMenu.transform.position = Input.mousePosition + offset;
    }

    public void SelectTower(GameObject towerGO)
    {
        
        if(selectedTowerGO != null)
        {
            Tower prevTower = selectedTowerGO.GetComponent<Tower>();
            prevTower.ToggleAttackRangeObject();
            TogglePanelMenu(prevTower);
        }

        selectedTowerGO = towerGO;
        Tower tower = selectedTowerGO.GetComponent<Tower>();
        TogglePanelMenu(tower);
        tower.ToggleAttackRangeObject();
    }

    public void DeselectTower()
    {
        if (selectedTowerGO == null) return;

        Tower tower = selectedTowerGO.GetComponent<Tower>();
        TogglePanelMenu(tower);
        tower.ToggleAttackRangeObject();
        selectedTowerGO = null;
    }
}