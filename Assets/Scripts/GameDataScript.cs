using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool music = true;
    public bool sound = true;
    public bool resetOnStart;
    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public int pointsToBall = 0;
    public bool newRecord = false;
    public string curPlayerName;
    public List<string> recordNames;
    public List<int> recordPoints;

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
    }


    //функци€ обновлени€ рекордов. ¬ызываетс€ при окончании игры.ы
    public void UpdateRecords()
    {
        //≈сли им€ игрока не заносилось - ничего не делаем
        if (curPlayerName == "") {
            return;
        }

        //ищем позицию рекорда.
        var pos = 0;
        for (int i = 0; i < recordPoints.Count; i++)
        {
            if (points < recordPoints[i])
            {
                pos += 1;
            }
        }

        // если рекорд не попал в том 5 - ничего не делаем
        if (pos > 4)
            return;

        //иначе это новый рекорд.
        newRecord = true;

        //вставл€ем рекорд и сокращаем список до 5.
        recordPoints.Insert(pos, points);
        recordNames.Insert(pos, curPlayerName);
        if (recordNames.Count > 5)
        {
            recordNames.RemoveAt(5);
            recordPoints.RemoveAt(5);
        }
    }
}