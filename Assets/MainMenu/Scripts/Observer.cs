using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    private string sceneName;
    private float mouseX;
    private float mouseY;

    public GameObject leftHL;
    public GameObject rightHL;
    public GameObject addInfoBox;
    public Button defaultButton;
    public Text title;
    public Text summary;
    public Text addInfo;
    public Image preview;

    // Start is called before the first frame update
    void Start()
    {
        defaultButton.onClick.Invoke();
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x / Screen.width * 800.0f - 400.0f;
        mouseY = Input.mousePosition.y / Screen.height * 450.0f - 225.0f;

        leftHL.SetActive(false);
        rightHL.SetActive(false);
        if (-218.0f < mouseY && mouseY < 218.0f)
        {
            if (-393.0f < mouseX && mouseX < -139.0f)
            {
                leftHL.SetActive(true);
            }
            else if (-131.0f < mouseX && mouseX < 393.0f)
            {
                rightHL.SetActive(true);
            }
        }
    }

    /* Update Info Pane */
    public void UpdateInfo(string sN, string ttl, string summ, string aInfo, Sprite prev)
    {
        sceneName = sN;
        title.text = ttl;
        summary.text = summ;
        addInfo.text = aInfo;
        preview.sprite = prev;
    }

    public void ToggleAddInfo()
    {
        if (addInfoBox.activeSelf)
        {
            addInfoBox.SetActive(false);
        }
        else
        {
            addInfoBox.SetActive(true);
        }
    }

    /* Quit */
    public void QuitGame()
    {
        Application.Quit();
    }

    /* Launch Game */
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
