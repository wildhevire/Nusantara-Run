using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    //score stamina powerup powerdown 

    public int score = 0;
    public float stamina = 10;
   

    Rigidbody2D rb;
    Animator animator;
    [SerializeField ]AnimationClip runAnim;

    [SerializeField] bool isGrounded = true;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] float sprintSpeed = 2;
    [SerializeField] float mundurSpeed = 2;

    [SerializeField] [Range(1, 2)] float sprintAnimSpeed = 1.5f;
    [SerializeField] [Range(1, 2)] float mundurAnimSpeed = .5f;



    [SerializeField] GameObject staminaBar;
    [SerializeField] GameObject staminaBarGO;
    Slider slider;
    Image img;



    public float energy = 10;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        slider = staminaBar.GetComponent<Slider>();
        img = staminaBarGO.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = stamina / 100;

        if (slider.value <= .5f)
        {
            img.color = Color.yellow;
        }
        if (slider.value <= .25f)
        {
            img.color = Color.red;
        }
        stamina -= Time.deltaTime * 5;
        if (isGrounded)
        {


            
            if (stamina <= .5f)
            {
                //slider.colors.
            }

            if (Input.GetButtonDown("Jump"))
            {
                
                rb.velocity += Vector2.up * jumpSpeed;
                isGrounded = false;
                //animator.Play("MidAir");
                animator.SetBool("isGround", false);
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                float t = .1f * Time.deltaTime;
                animator.speed = Mathf.Lerp(sprintAnimSpeed, 1, t);
                
                //runAnim.SampleAnimation(gameObject, 120);
                //rb.velocity += Vector2.right * sprintSpeed;
                transform.Translate(Vector3.right * sprintSpeed * Time.deltaTime);

            }
            


            if (Input.GetKeyUp(KeyCode.RightArrow))
            {

                stamina -= Time.deltaTime * 10;
                float t = -.1f * Time.deltaTime;
                animator.speed = Mathf.Lerp(1, sprintAnimSpeed, t);
            }







            if (Input.GetKey(KeyCode.LeftArrow))
            {
                float t = .1f * Time.deltaTime;
                animator.speed = Mathf.Lerp(mundurAnimSpeed, 1, t);

                //runAnim.SampleAnimation(gameObject, 120);
                //rb.velocity += Vector2.right * sprintSpeed;
                transform.Translate(Vector3.left * mundurSpeed * Time.deltaTime);

            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                float t = -.1f * Time.deltaTime;
                animator.speed = Mathf.Lerp(1, mundurAnimSpeed, t);
            }
        }
        //if (!isGrounded)
        //{
        //    animator.SetBool("Landing", true);

        


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //animator.Play("Run");
            animator.SetBool("isGround", true);
           // animator.SetBool("Landing", false);
            isGrounded = true;
            animator.SetBool("Landing", false);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Landing" && rb.velocity.y < 0)
        {
            Debug.Log("Landing");
            animator.SetBool("Landing", true);
        }
        if (collision.tag == "Landing")
        {

        }
        if (collision.tag == "Energy")
        {

            Destroy(collision.gameObject);
            stamina += energy;
        }
    }
}
        