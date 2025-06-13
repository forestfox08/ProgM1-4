using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screenswitch : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         SceneManager.LoadScene(1);

            // Scene 1 is SampleScene, check Unity Build Settings voor extra proof.
        }
    }
}