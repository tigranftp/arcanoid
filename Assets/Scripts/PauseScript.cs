using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//������ �����
public class PauseScript : MonoBehaviour
{
    Button continueBTN;
    Button menuBTN;
    public GameDataScript GameData;


    // ���������� ������.
    void Start()
    {
        continueBTN = GameObject.Find("Continue").GetComponent<Button>();
        continueBTN.onClick.AddListener(continueTask);
        menuBTN = GameObject.Find("MainMenu").GetComponent<Button>();
        menuBTN.onClick.AddListener(menuTask);
    }

    //� ������ ������� �� ���� - ������ ����� ���� + �������� gameData
    void menuTask()
    {
        GameData.Reset();
        SceneManager.LoadScene("StartingMenu");
    }

    // � ������ ����������� ������ ������ ��������� + ������ �������� ������� + ���� ����� ������ �� ��������.
    void continueTask()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }



}
