using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {
    //private Vector3 pos;
    private Vector3 gapr = new Vector3(0, 0.3f, 0);
    //private Vector3 gapl = new Vector3(-3, 2.0f, 0);
    public Player player;
    public GameObject enemy;
    public bool dragged = false;
    public int dmg = 20;
    

    void Start()
    {
       
        //pos = GameObject.Find("Player").transform.position;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = gameObject.GetComponentInParent<Player>();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            dragged = true;
            //col.SendMessageUpwards("Damage", dmg);
            
        }
    }
    
    void Update()
    {
        if (dragged)
        {
            enemy.transform.parent = player.transform;
            enemy.transform.position = player.transform.position+gapr;
        }
        /* if (dragged && (Input.GetAxis("Horizontal") < -0.1f))
         {
           enemy.transform.root.position = Vector3.MoveTowards(transform.position + gapl, pos, 1f);
         }
         if (dragged && (Input.GetAxis("Horizontal") > 0.1f))
         {
             enemy.transform.root.position = Vector3.MoveTowards(transform.position + gapr, pos, 1f);
         } */
        if (Input.GetKeyDown("g"))
        {
            dragged = false;
        }
    }
        

}
