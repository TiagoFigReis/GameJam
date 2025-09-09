using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    private Rigidbody2D rb;
    
    
    [SerializeField] float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void FixedUpdate()
    {
        rb.linearVelocityX = speed * Time.fixedDeltaTime;
    }
}
