using UnityEngine;

public class burger : MonoBehaviour
{
    private Rigidbody2D rb;
    
    
    [SerializeField] float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void FixedUpdate()
    {
        rb.linearVelocityY = speed * Time.fixedDeltaTime;
    }
}
