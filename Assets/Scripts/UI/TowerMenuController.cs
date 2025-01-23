using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerMenuController : MonoBehaviour
{
    private SelectionManager selectionManager;
    public TextMeshProUGUI towerNameTMP;
    public TextMeshProUGUI towerSpeedTMP;
    public TextMeshProUGUI towerDamageTMP;

    void Start()
    {
        // Obtenemos una referencia al TowerSelectionManager
        selectionManager = FindObjectOfType<SelectionManager>();
    }

    public void SetNameTMP(string name)
    {
        towerNameTMP.text = name;
    }

    public void SetSpeedTMP(string speed)
    {
        towerSpeedTMP.text = "Speed: " + speed;

    }

    public void SetDamageTMP(string damage)
    {
        towerDamageTMP.text = "Damage: " + damage;
    }


    // Método para mejorar la torre seleccionada
    public void OnUpgradeButtonPressed()
    {
        if (selectionManager.selectedTowerGO != null)
        {
            selectionManager.selectedTowerGO.GetComponent<Tower>().Upgrade();
        }
    }

    // Método para eliminar la torre seleccionada
    public void OnSellButtonPressed()
    {
        if (selectionManager.selectedTowerGO != null)
        {
            selectionManager.selectedTowerGO.GetComponent<Tower>().Sell();
            selectionManager.DeselectTower();
        }
    }

}
