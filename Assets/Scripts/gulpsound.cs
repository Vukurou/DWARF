using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GulpSound : MonoBehaviour
{
    private Rigidbody2D rigidbodyImpale;
    private BoxCollider2D boxCollider2D;
    private AudioSource gulpAudio;
    public AudioClip gulpSound;



    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbodyImpale = GetComponent<Rigidbody2D>();
        gulpAudio = gameObject.AddComponent<AudioSource>();
        gulpAudio.playOnAwake = false;
        gulpAudio.clip = gulpSound;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zwerg"))
        {
            gulpAudio.Play();
        }
    }

}
