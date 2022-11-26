using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// скрипт кнопки на начальной заставке
public class ButtonScript : MonoBehaviour
{
	public GameDataScript gameData;
	public Text bestResult;
	void Start()
	{
		//находим объект текста с лучши результатом
		bestResult = GameObject.Find("BestResult").GetComponent<Text>();
		//делаем ее невидимой
		bestResult.gameObject.SetActive(false);
		
		//проверям не случился ли новый рекорд
		//и в случае его делаем запись видимой
		if (gameData.newRecord)
		{
			bestResult.gameObject.SetActive(true);
		}
		//убираем рекордность
		gameData.newRecord = false;

		//загружаем список рекордов
		GetRecordList();

		//обязательно делаем курсор видимым.
		Cursor.visible = true;

		//находим кнопку + задаем ей функцию при нажатии
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		//если имя задано - запоминаем его.
		if (gameData.curPlayerName != "")
        {
			GameObject.FindObjectOfType<InputField>().text = gameData.curPlayerName;

		}
	}



	void TaskOnClick()
	{
		// в случае нажатия получаем имя текущего игрока
		gameData.curPlayerName = GameObject.FindObjectOfType<InputField>().text;
		Cursor.visible = true;
		//запускаем время и меняем сцену
		Time.timeScale = 1;
		SceneManager.LoadScene("SampleScene");
	}


	//функция получения списка рекордсменов
	void GetRecordList()
    {
		//создаем список находя все текстовые поля
		List<Text> names = new List<Text>();
		names.Add(GameObject.Find("Name1").GetComponent<Text>());
		names.Add(GameObject.Find("Name2").GetComponent<Text>());
		names.Add(GameObject.Find("Name3").GetComponent<Text>());
		names.Add(GameObject.Find("Name4").GetComponent<Text>());
		names.Add(GameObject.Find("Name5").GetComponent<Text>());

		//загружаем в эти текстовые поля значения из GameData
        for (int i = 0; i < gameData.recordNames.Count; i++)
        {
			names[i].text = gameData.recordNames[i] + " " + gameData.recordPoints[i] ;
        }
	}
}