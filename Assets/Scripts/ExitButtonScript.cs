using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//Кнопка выхода 
public class ExitButtonScript : MonoBehaviour
{
	// Start is called before the first frame update
	//Стандартно загружаем кнопку и добавляем обработчик
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	//При нажатии выходим
	void TaskOnClick()
	{
				Application.Quit();
	#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
	#endif
	
	}
}
