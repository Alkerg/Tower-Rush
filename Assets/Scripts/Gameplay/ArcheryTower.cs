using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcheryTower : Tower
{
    private CapsuleCollider attackRangeTrigger;

    private void Start()
    {
        attackRangeTrigger = GetComponent<CapsuleCollider>();
        attackRangeMeshIsActive = false;
    }

    private void Update()
    {
        
    }

    public override void Attack()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    /*public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }*/
}
