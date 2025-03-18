using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private string objectiveText = "I am an objective!";
    [SerializeField] private string completeText = "You did it";
    [SerializeField] private Text objectiveDisplay;

    public UnityEvent OnCompleteObjective = new UnityEvent();
    
    private void OnEnable()
    {
        objectiveDisplay.text = objectiveText;
    }

    public void CompleteObjective()
    {
        if (gameObject.activeSelf)
        {
            objectiveDisplay.text = "";

        OnCompleteObjective.Invoke();

        gameObject.SetActive(false);
        }
    }
}
