using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Expose : MonoBehaviour
{
    private Rigidbody rigidbody; 
    public int objCount = 0;
    public bool done = false;

    public Objective objective;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Change()
    {
        objCount++;
        Debug.Log(objCount);
    }

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        if (objCount == 3)
        {
            objective.CompleteObjective();
            done = true;
        }
    }
}
