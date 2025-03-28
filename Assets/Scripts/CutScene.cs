using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public GameObject Evil;
    public GameObject Pillars;
    public GameObject Monster;
    public GameObject Player;
    public GameObject Final;

    public Text text;

    public Camera PlayerCamera;
    public Camera CutCamera;

    public int evilMoveSpeed = 1;
    public int monsterMoveSpeed = 1;
    public float monsterWaitTime = 2f;
    public float cutsceneDuration = 10f;

    private IEnumerator setpause;

    private IEnumerator Pause(float pause)
    {
        yield return new WaitForSeconds(pause);

        StartCoroutine(Summon());
    }

    public void Setup()
    {
        text.enabled = false;

        PlayerCamera.enabled = false;
        CutCamera.enabled = true;

        Player.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        Pillars.SetActive(false);

        setpause = Pause(2f);
        StartCoroutine(setpause);
    }

    private IEnumerator Summon()
    {

        for (float alpha = 10f; alpha >= 0; alpha -= 0.1f)
            {
                yield return new WaitForSeconds(.015f);
                Evil.transform.position += Vector3.down * evilMoveSpeed *Time.deltaTime;
            }
        Monster.SetActive(true);

        for (int i = 0; i < 35; i++)
        {
            Quaternion rumble = Quaternion.Euler(
                Random.Range(36f, 38f),            
                Random.Range(-91f, -89f),       
                Random.Range(-3f, -1f)         
            );
            CutCamera.transform.rotation = rumble;

            yield return new WaitForSeconds(0.025f);
        }

        StartCoroutine(End(1));

    }

    private IEnumerator End(float pause)
    {
        yield return new WaitForSeconds(pause);

        Closing();
    }

    private void Closing()
    {
        text.enabled = true;

        PlayerCamera.enabled = true;
        CutCamera.enabled = false;

        Player.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;

        Pillars.SetActive(true);

        Final.SetActive(true);
    }
}

