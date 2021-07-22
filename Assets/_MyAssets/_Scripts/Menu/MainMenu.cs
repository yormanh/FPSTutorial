using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] RectTransform mMainPanel;

    
    public void PlayGame()
    {
        mMainPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }
}
