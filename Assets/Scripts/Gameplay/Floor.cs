using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Floor : MonoBehaviour, IPointerClickHandler
{
    public GameObject settingsPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        settingsPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
