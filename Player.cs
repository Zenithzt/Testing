using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] float moveSpeed = 10f;
    public float jumpForce = 10f; 
    private Rigidbody rb;

    public int maxJumps = 2;
    private int jumps;
    

    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        
    }

   // Update per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) 
        {
            this.Jump ();
        }
    
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
   
        if(Input.GetKeyDown(KeyCode.Space)) {
            // Player is able to jump when grounded
            if(isGrounded == true) {
               
                    if(rb.velocity.z == 0F) {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
                    isGrounded = false;
                    //Player is unable to jump while not grounded.
                    }
            }
                        
        }
    }
    private void Jump() 
    {
            if (jumps > 0)
            {
                gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpForce), ForceMode.Impulse);
                isGrounded = false;
                jumps = jumps - 1;
            }
            if (jumps == 0)
            {
                return;
            }
    }
                            // Counting jumps for double jump
    void OnCollisionEnter(Collision collision) {
        isGrounded = true;

        jumps = maxJumps;
        isGrounded = true;
        moveSpeed = 10f;

            Debug.Log("Grounded");
    }


        
}