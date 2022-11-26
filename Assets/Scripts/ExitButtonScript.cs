using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//������ ������ 
public class ExitButtonScript : MonoBehaviour
{
	// Start is called before the first frame update
	//���������� ��������� ������ � ��������� ����������
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	//��� ������� �������
	void TaskOnClick()
	{
				Application.Quit();
	#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
	#endif
	
	}
}
