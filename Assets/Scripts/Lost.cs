using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("E");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("BRuh");
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
