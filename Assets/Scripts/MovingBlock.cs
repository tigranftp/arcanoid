using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт двигающихся блоков.
public class MovingBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;

    // Загружаем свойства блока
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        //задаем направление с учетом его массы
        dir = new Vector2(rb.mass*100, 0);
        //убираем угловые повороты
        rb.freezeRotation = true;
        //пускаем блок.
        rb.AddForce(dir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //при ударе меняем направление
        dir = -dir;
        //меняем скорость на ноль, чтобы запустить в другую сторону с той же скоростью.
        rb.velocity = Vector2.zero;
        //запускаем блок в другое направление.
        rb.AddForce(dir);
    }
}
