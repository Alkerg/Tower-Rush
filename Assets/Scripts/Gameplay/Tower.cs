using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower: MonoBehaviour, IPointerClickHandler, IDeselectHandler
{
    public GameObject attackRangeCylinder;
    public bool attackRangeMeshIsActive;
    public GameObject settingsPanel;
    public bool settingsPanelIsActive;

    public virtual void Attack() { }
    public virtual void Upgrade() { }
    public virtual void ToggleAttackRangeObject()
    {
        attackRangeMeshIsActive = !attackRangeMeshIsActive;
        attackRangeCylinder.GetComponent<MeshRenderer>().enabled = attackRangeMeshIsActive;
    }
    public virtual void ToggleSettingsPanel()
    {
        Vector3 offset = new Vector3(60, 60, 0);
        settingsPanelIsActive = !settingsPanelIsActive;
        settingsPanel.transform.position = Input.mousePosition + offset;
        settingsPanel.SetActive(settingsPanelIsActive);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
        ToggleAttackRangeObject();
        ToggleSettingsPanel();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ToggleAttackRangeObject();
        ToggleSettingsPanel();
    }
}
