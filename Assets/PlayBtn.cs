using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    // M�todo p�blico que recibe el nombre de la escena como par�metro
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
