using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    //score stamina powerup powerdown 

    public int score = 0;
    public float stamina = 10;
   

    Rigidbody2D rb;
    public Animator animator;
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


    [SerializeField] Button btnSprint;
    [SerializeField] Button btnJump;

    public UnityEvent longClick;

    public float energy = 10;

    public bool isSprint;

    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        slider = staminaBar.GetComponent<Slider>();
        img = staminaBarGO.GetComponent<Image>();


        btnJump = GameObject.Find("Jump").GetComponent<Button>();
        btnSprint = GameObject.Find("Sprint").GetComponent<Button>();


        btnJump.onClick.AddListener(Jump);
        
        //btnSprint.onClick.AddListener(Sprint);
        
    }

    // Update is called once per frame
    void Update()
    {

        Unsprint();
        
        slider.value = stamina / 100;

        if (slider.value <= .5f)
        {
            img.color = Color.yellow;
        }
        if (slider.value <= .25f)
        {
            img.color = Color.red;
        }
        //stamina -= Time.deltaTime * 5;


        if (stamina <= .5f)
        {
            //slider.colors.
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Sprint();
        }



        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Unsprint();

        }
        if (isGrounded)
        {


            

            







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
    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
            isGrounded = false;
            //animator.Play("MidAir");
            animator.SetBool("isGround", false);
        }
        
    }
    public void Sprint()
    {
        if (isGrounded)
        {
            stamina -= Time.deltaTime * 10;
            float t = .1f * Time.deltaTime;
            animator.speed = Mathf.Lerp(sprintAnimSpeed, 1, t);

            //runAnim.SampleAnimation(gameObject, 120);
            //rb.velocity += Vector2.right * sprintSpeed;
            transform.Translate(Vector3.right * sprintSpeed * Time.deltaTime);
        }
    }

    public void Unsprint()
    {
        if (isGrounded)
        {
            stamina -= Time.deltaTime * 5;
            float t = -.1f * Time.deltaTime;
            animator.speed = Mathf.Lerp(1, sprintAnimSpeed, t);
        }
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
        