using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public void OpenTutorial()
    {
        panel.SetActive(true);
    }

    public void CloseTutorial()
    {
        panel.SetActive(false);
    }

    public void Begin()
    {
        SceneManager.LoadScene(1);
    }
}
