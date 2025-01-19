using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{
    public Grid grid;
    public GameObject panel;
    void Start()
    {
        
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


    }
}