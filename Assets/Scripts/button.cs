using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}