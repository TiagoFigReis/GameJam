using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chef : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private int bun = 0, cheese = 0, steak = 0;
    
    [SerializeField] private float speed;

    private float x;
    
    bool isAttacking = false;

    [SerializeField] GameObject burger;
    
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

  
    void FixedUpdate()
    {
        Running();
    }

    void Running()
    {
        rb.linearVelocityX = x * speed * Time.deltaTime;

        bool isRunning = Mathf.Abs(rb.linearVelocityX) > 0;
        anim.SetBool("IsRunning", isRunning);
        
        if(isRunning) Flip();
    }

    void OnMove(InputValue value)
    {
        x = value.Get<Vector2>().x;
    }

    void Flip()
    {
        transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocityX) * 2, 2);
    }

    void OnAttack(InputValue value)
    {
        print(value.isPressed);
        isAttacking = value.isPressed;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!isAttacking)
        {
            return;
        }
        
        if (collision.gameObject.CompareTag("bun"))
        {
            bun++;
            print("oi");
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("steak"))
        {
            steak++;
            print("oi");
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("cheese"))
        {
            cheese++;
            print("oi");
            Destroy(collision.gameObject);
        }
        
        if (bun > 0 && cheese > 0 && steak > 0)
        {
            
            GameObject burgerIn = Instantiate(burger, transform.position, Quaternion.identity);
            Destroy(burgerIn, 1);

            bun--;
            cheese--;
            steak--;
        }
        
        if (!collision.gameObject.CompareTag("bomba"))
        {
            return;
        }
        
            
        Animator anim =  collision.gameObject.GetComponent<Animator>();

        anim.enabled = true;
        
    }

    void OnExit(InputValue value)
    {
        print("Saindo");
        Application.Quit();
    }
    
}
