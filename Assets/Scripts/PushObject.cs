using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushObject : MonoBehaviour
{
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Push(float strength)
    {
        Vector3 PushDirection = transform.position - Camera.main.transform.position;
        PushDirection.Normalize();

        rigidbody.AddForce(PushDirection * strength, ForceMode.Impulse);
    }
}
