using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// ������ ������ �� ��������� ��������
public class ButtonScript : MonoBehaviour
{
	public GameDataScript gameData;
	public Text bestResult;
	void Start()
	{
		//������� ������ ������ � ����� �����������
		bestResult = GameObject.Find("BestResult").GetComponent<Text>();
		//������ �� ���������
		bestResult.gameObject.SetActive(false);
		
		//�������� �� �������� �� ����� ������
		//� � ������ ��� ������ ������ �������
		if (gameData.newRecord)
		{
			bestResult.gameObject.SetActive(true);
		}
		//������� �����������
		gameData.newRecord = false;

		//��������� ������ ��������
		GetRecordList();

		//����������� ������ ������ �������.
		Cursor.visible = true;

		//������� ������ + ������ �� ������� ��� �������
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		//���� ��� ������ - ���������� ���.
		if (gameData.curPlayerName != "")
        {
			GameObject.FindObjectOfType<InputField>().text = gameData.curPlayerName;

		}
	}



	void TaskOnClick()
	{
		// � ������ ������� �������� ��� �������� ������
		gameData.curPlayerName = GameObject.FindObjectOfType<InputField>().text;
		Cursor.visible = true;
		//��������� ����� � ������ �����
		Time.timeScale = 1;
		SceneManager.LoadScene("SampleScene");
	}


	//������� ��������� ������ ������������
	void GetRecordList()
    {
		//������� ������ ������ ��� ��������� ����
		List<Text> names = new List<Text>();
		names.Add(GameObject.Find("Name1").GetComponent<Text>());
		names.Add(GameObject.Find("Name2").GetComponent<Text>());
		names.Add(GameObject.Find("Name3").GetComponent<Text>());
		names.Add(GameObject.Find("Name4").GetComponent<Text>());
		names.Add(GameObject.Find("Name5").GetComponent<Text>());

		//��������� � ��� ��������� ���� �������� �� GameData
        for (int i = 0; i < gameData.recordNames.Count; i++)
        {
			names[i].text = gameData.recordNames[i] + " " + gameData.recordPoints[i] ;
        }
	}
}