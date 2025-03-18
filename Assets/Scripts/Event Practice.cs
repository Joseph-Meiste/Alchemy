using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPractice : MonoBehaviour
{
    public UnityEvent testEvent = new UnityEvent();
    void Start()
    {
        testEvent.AddListener(TestListener);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            testEvent.Invoke();
        }
    }

    private void TestListener()
    {
        print("test listener called");
    }
}
