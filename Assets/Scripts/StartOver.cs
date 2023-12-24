using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    public bool start;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            start = !start;

            if (start) 
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }

    private void OnGUI()
    {
        if (start) 
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Start");
        }
    }
}
