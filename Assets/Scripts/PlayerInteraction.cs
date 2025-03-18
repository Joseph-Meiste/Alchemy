using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Text interactableName;

    [SerializeField] private InteractionObject targetInteraction;

    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycasthit = new RaycastHit();
        string interactionText = "";
        targetInteraction = null;

        if (Physics.Raycast(origin, direction, out raycasthit, maxDistance))
        {
            targetInteraction = raycasthit.collider.gameObject.GetComponent<InteractionObject>();
        }

        if (targetInteraction && targetInteraction.enabled)
        {
            interactionText = targetInteraction.GetInteractionText();
        }

        SetInteractableNameText(interactionText);
    }

    private void SetInteractableNameText(string newText)
    {
        if (interactableName)
        {
            interactableName.text = newText;
        }
    }

    public void TryInteract()
    {
        if (targetInteraction && targetInteraction.enabled)
        {
            targetInteraction.Interact();
        }
    }
}
