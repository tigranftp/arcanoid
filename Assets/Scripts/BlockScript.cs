using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using TMPro;
public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    Text textComponent;
    public int hitsToDestroy;
    public int points;
    PlayerScript playerScript;
    string spriteName;
    void Start()

    {
        spriteName = GetComponent<SpriteRenderer>().sprite.name;
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball")
        {
            return;
        }
        {
            hitsToDestroy--;
            if (hitsToDestroy < 1)
            {
                //т.к. бонусы падают после разбития зеленого блока
                //выполняем проверку + спавним рандомный бонус
                if (spriteName == "cube_green")
                {
                    generateRnadomBonus();
                }

                Destroy(gameObject);
                playerScript.BlockDestroyed(points);
            }
            else if (textComponent != null)
                textComponent.text = hitsToDestroy.ToString();
        }
    }

    //Функция генерации рандомных бонусов. 
    //Генерит рандомное число от нуля до шести, т.к. бонусов всего 6
    void generateRnadomBonus()
    {
        var rand = new System.Random();
        int value = rand.Next(0, 6); 
        switch (value)
        {
            case 0:
                CreateBonus100();
                break;
            case 1:
                CreateBonusFast();
                break;
            case 2:
                CreateBonusSlow();
                break;
            case 3:
                CreateBonusBall();
                break;
            case 4:
                CreateBonus2BallsAndLaunch();
                break;
            case 5:
                CreateBonus10BallsAndLaunch();
                break;
            default:
                break;
        }
    }

    //Далее идут функции создания бонусов. Во всех используются готовые префабы и добавляется явно компонент BonusScript.
    //Гравитация убрана и бонусы идут с постоянной скоростью.

    // Бонус +100 к очкам
    void CreateBonus100()
    {
        var obj = Instantiate(playerScript.bonus,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBase>();
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }

    //Бонус увеличения скорости шаров на 10%
    void CreateBonusFast()
    {
        var obj = Instantiate(playerScript.bonusFast,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusSpeed>();
        bs.coef = 1.1f;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    //Бонус уменьшения скорости шаров на 10%
    void CreateBonusSlow()
    {
        var obj = Instantiate(playerScript.bonusSlow,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusSpeed>();
        bs.coef = 0.9f;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    // Бонус +1 шар к резерву.
    void CreateBonusBall()
    {
        var obj = Instantiate(playerScript.bonusBall,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBall>();
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }

    //Мгновенный спавн 2 шаров и +2 к резерву
    void CreateBonus2BallsAndLaunch()
    {
        var obj = Instantiate(playerScript.bonusBalls2,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBallAndLaunch>();
        bs.ballCount = 2;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    //Мгновенный спавн 10 шаров и +10 к резерву
    void CreateBonus10BallsAndLaunch()
    {
        var obj = Instantiate(playerScript.bonusBalls10,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBallAndLaunch>();
        bs.ballCount = 10;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }
}