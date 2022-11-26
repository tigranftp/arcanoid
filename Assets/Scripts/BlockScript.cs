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
                //�.�. ������ ������ ����� �������� �������� �����
                //��������� �������� + ������� ��������� �����
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

    //������� ��������� ��������� �������. 
    //������� ��������� ����� �� ���� �� �����, �.�. ������� ����� 6
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

    //����� ���� ������� �������� �������. �� ���� ������������ ������� ������� � ����������� ���� ��������� BonusScript.
    //���������� ������ � ������ ���� � ���������� ���������.

    // ����� +100 � �����
    void CreateBonus100()
    {
        var obj = Instantiate(playerScript.bonus,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBase>();
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }

    //����� ���������� �������� ����� �� 10%
    void CreateBonusFast()
    {
        var obj = Instantiate(playerScript.bonusFast,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusSpeed>();
        bs.coef = 1.1f;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    //����� ���������� �������� ����� �� 10%
    void CreateBonusSlow()
    {
        var obj = Instantiate(playerScript.bonusSlow,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusSpeed>();
        bs.coef = 0.9f;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    // ����� +1 ��� � �������.
    void CreateBonusBall()
    {
        var obj = Instantiate(playerScript.bonusBall,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBall>();
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }

    //���������� ����� 2 ����� � +2 � �������
    void CreateBonus2BallsAndLaunch()
    {
        var obj = Instantiate(playerScript.bonusBalls2,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBallAndLaunch>();
        bs.ballCount = 2;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }


    //���������� ����� 10 ����� � +10 � �������
    void CreateBonus10BallsAndLaunch()
    {
        var obj = Instantiate(playerScript.bonusBalls10,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var bs = obj.AddComponent<BonusBallAndLaunch>();
        bs.ballCount = 10;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

    }
}