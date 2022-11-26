using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallScript : MonoBehaviour
{
    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    PlayerScript playerObj;
    float deltaX;
    AudioSource audioSrc;
    public AudioClip hitSound;
    public AudioClip loseSound;
    public GameDataScript gameData;
    [HideInInspector]
    // свойство показывающее, создан ли м€ч из-за бонуса.
    public bool createdByBonus = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindObjectOfType<PlayerScript>();
        deltaX = transform.position.x;
        audioSrc = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.isKinematic)
            if (Input.GetButtonDown("Fire1"))
            {
                rb.isKinematic = false;
                rb.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos;
            }
        if (!rb.isKinematic && Input.GetKeyDown(KeyCode.J))
        {
            var v = rb.velocity;
            if (Random.Range(0, 2) == 0)
                v.Set(v.x - 0.1f, v.y + 0.1f);
            else
                v.Set(v.x + 0.1f, v.y - 0.1f);
            rb.velocity = v;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameData.sound)
            audioSrc.PlayOneShot(loseSound, 5);
        Destroy(gameObject);
        playerObj.GetComponent<PlayerScript>().BallDestroyed();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameData.sound)
            audioSrc.PlayOneShot(hitSound);
    }

    //‘ункци€ дл€ изменени€ скорости м€ча на ко-эф coef
    public void ChangeSpeed(float coef)
    {
        rb.velocity *= coef;
    }
}
