using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayLoad = 0.5f;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] AudioClip crashSFX;

    bool hasCrash = false;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Ground" && !hasCrash) {
            hasCrash = true;
            FindObjectOfType<PlayerControll>().DestroyControll();
            particleSystem.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("LoadScene",delayLoad);
        }
    }

    void LoadScene() {
        SceneManager.LoadScene(0);
    }
}
