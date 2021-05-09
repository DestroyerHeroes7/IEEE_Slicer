using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject gameEndPanel;
    private void Awake()
    {
        Instance = this;
    }
    public void OpenGameEndPanel()
    {
        gameEndPanel.SetActive(true);
    }
    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
