using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Use this for initialization
    public float maxSpeed = 3;
    public float speed = 60f;
    public float jumpPower = 250f;

    public bool grounded;

    public int curHealth;
    public int maxHealth = 5;

    private Rigidbody2D rb2d;
    private Animator anim;
  
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));


        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 1);
        }
        if (Input.GetButtonDown("Jump")&& grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth<1) {
            Death();
        }

    }

    void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * h);
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Death()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        curHealth -=  dmg;
        //gameObject.GetComponent<Animation>().Play("Player_damage");
        anim.Play("Player_damage", -1, 0f);
    }

    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while(knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockPwr, transform.position.z));
        }
        yield return 0;
    }
}
