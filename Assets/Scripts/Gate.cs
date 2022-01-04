using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("L1");
        print("L1 in");
    }
}
