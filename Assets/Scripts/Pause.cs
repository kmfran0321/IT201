using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public bool paused;
    [SerializeField] GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            PauseMenu.SetActive(paused);

            if (paused) 
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    private void OnGUI()
    {
        if (paused) 
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Paused");
        }
    }
}
