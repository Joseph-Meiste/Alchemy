using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "Interaction";

    public UnityEvent OnInteract = new UnityEvent();

    private void OnEnable()
    {

    }

    public string GetInteractionText()
    {
        return interactionText;
    }
    public void Interact()
    {
        OnInteract.Invoke();
    }
}