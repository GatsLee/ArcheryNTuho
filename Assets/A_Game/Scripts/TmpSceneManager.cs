using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class TmpSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "ArcheryScene")
                SceneManager.LoadScene("TuhoScene");
            else if (SceneManager.GetActiveScene().name == "TuhoScene")
                SceneManager.LoadScene("ArcheryScene");
        }
    }
}
