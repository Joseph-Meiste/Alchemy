using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Pressed : MonoBehaviour
{
    private Rigidbody rigidbody;
    public int objCount = 0;
    public bool done = false;

    public Objective objective;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Hit()
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
        if (objCount == 5)
        {
            objective.CompleteObjective();
            done = true;
        }
    }
}
