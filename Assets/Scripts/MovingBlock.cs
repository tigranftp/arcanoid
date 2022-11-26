using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ����������� ������.
public class MovingBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;

    // ��������� �������� �����
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        //������ ����������� � ������ ��� �����
        dir = new Vector2(rb.mass*100, 0);
        //������� ������� ��������
        rb.freezeRotation = true;
        //������� ����.
        rb.AddForce(dir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //��� ����� ������ �����������
        dir = -dir;
        //������ �������� �� ����, ����� ��������� � ������ ������� � ��� �� ���������.
        rb.velocity = Vector2.zero;
        //��������� ���� � ������ �����������.
        rb.AddForce(dir);
    }
}
