using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
    private Player player;
    public float knockbackPowerInEditor;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);

            // StartCoroutine(player.Knockback(0.2f, -1, player.transform.position));
            StartCoroutine(player.Knockback(0.02f, knockbackPowerInEditor, player.transform.position));
        }       
	}
}
