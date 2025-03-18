using UnityEngine;

public class ChangeSize : MonoBehaviour
{

    [SerializeField] private float modifiedScale = 2f;
    [SerializeField] private float changeRate = 5f;

    private Vector3 initialScale;
    private bool isScaled = false;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, GetTargetScale(), changeRate * Time.deltaTime);
    }

    private Vector3 GetTargetScale()
    {
        return isScaled ? Vector3.one * modifiedScale : initialScale;
    }

    public void ToggleScale()
    {
        isScaled = !isScaled;
    }
}
