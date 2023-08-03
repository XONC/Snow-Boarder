using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayLoad = 1f;
    [SerializeField] ParticleSystem particleSystem;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            particleSystem.Play();
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Invoke("LoadScene",delayLoad);
        }
    }

    private void LoadScene() {
        SceneManager.LoadScene(0);
    }
}
