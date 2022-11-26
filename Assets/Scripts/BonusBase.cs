using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� BonusBase.
public class BonusBase : MonoBehaviour
{
    public int bonusSize;
    public PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    virtual public void bonusActivate()
    {
        var gameData = playerScript.gameData;
        gameData.points += 100;
        gameData.pointsToBall += 100;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        bonusActivate();    

    }
}


// ����� ����� ��� ���������� ������� - �������� �� BonusBase
public class BonusSpeed: BonusBase
{
    public float coef;
    public BonusSpeed(float coef)
    {
       this.coef = coef;
    }
    override public void bonusActivate()
    {
        var balls = GameObject.FindObjectsOfType<BallScript>();
        foreach (var ball in balls)
        {
            // �������� �� ������ �� ��� �������
            if (!ball.createdByBonus)
            {
                ball.ChangeSpeed(coef);
            }
        }
    }

}


// ����� ����� ��� ��� ���� - �������� �� BonusBase
public class BonusBall: BonusBase
{

    override public void bonusActivate()
    {
        playerScript.gameData.balls += 1;
    }

}

// ����� ����� ��� ��� ����� + ������ �� �� ���� - �������� �� BonusBase
public class BonusBallAndLaunch: BonusBase
{
    public int ballCount;
    override public void bonusActivate()
    {
        var multipliers = new List<int> { -1, 1 };
        var rand = new System.Random();
        var randomBall = GameObject.FindGameObjectWithTag("Ball");
        playerScript.gameData.balls += ballCount;

        for (int i = 0; i < ballCount; i++)
        {
            //�������� ����������� �� � � y ��� ����
            var x = rand.Next(100, 300)* multipliers[rand.Next(0,2)];
            var y = Math.Sqrt(100000 - (x * x));
            //������� �����
            var obj = Instantiate(playerScript.ballPrefab, randomBall.transform.position, randomBall.transform.rotation);
            var ball = obj.GetComponent<BallScript>();
            //������ �������, ��� ��� ��� ������
            ball.createdByBonus = true;
            var rb = obj.GetComponent<Rigidbody2D>();
            //������ �������� ��� ����, ����� ����� ��� ���������.
            rb.isKinematic = false;
            rb.AddForce(new Vector2(x, (float)y));
        }
    }

}