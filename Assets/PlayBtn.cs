using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    // Método público que recibe el nombre de la escena como parámetro
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
