using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//скрипт паузы
public class PauseScript : MonoBehaviour
{
    Button continueBTN;
    Button menuBTN;
    public GameDataScript GameData;


    // Подгружаем кнопки.
    void Start()
    {
        continueBTN = GameObject.Find("Continue").GetComponent<Button>();
        continueBTN.onClick.AddListener(continueTask);
        menuBTN = GameObject.Find("MainMenu").GetComponent<Button>();
        menuBTN.onClick.AddListener(menuTask);
    }

    //в случае нажатия на меню - грузим сцену меню + обнуляем gameData
    void menuTask()
    {
        GameData.Reset();
        SceneManager.LoadScene("StartingMenu");
    }

    // в случае продолжения делаем курсор невидимым + меняем скорость времени + слой паузы делаем не активным.
    void continueTask()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }



}
