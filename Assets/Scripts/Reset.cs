using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void Restart(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
