using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ImpaleSound : MonoBehaviour
{
    private Rigidbody2D rigidbodyImpale;
    private BoxCollider2D boxCollider2D;
    private AudioSource impaleAudio;
    public AudioClip impaleSound;



    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbodyImpale = GetComponent<Rigidbody2D>();
        impaleAudio = gameObject.AddComponent<AudioSource>();
        impaleAudio.playOnAwake = false;
        impaleAudio.clip = impaleSound;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zwerg"))
        {
            impaleAudio.Play();
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => impaleAudio.isPlaying);
        Destroy(gameObject);
    }
}
