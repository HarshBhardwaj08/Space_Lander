using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacle : MonoBehaviour
{
    [SerializeField] float scencechangetime;
    [SerializeField] AudioClip start;
    [SerializeField] AudioClip end;
    [SerializeField] ParticleSystem crash;
    [SerializeField]ParticleSystem win;
    ParticleSystem vfx;
    bool isplay = false;

    AudioSource audios;
    void Start()
    {
        vfx = GetComponent<ParticleSystem>();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {   if (isplay )
        {
            return;
        }
       

            switch (collision.gameObject.tag)
            {
                case "Obstruct":
                    startsquence();
                    break;
                case "Start":
                    Debug.Log("Here we go");
                    break;
                case "End":
                    endsquence();
                    break;


            }
        

    }

    void startsquence() {
        crash.Play();
        isplay = true;
        audios.Stop();
        audios.PlayOneShot(end);
        GetComponent<Movement>().enabled = false;
        Invoke("reloadscene", scencechangetime);
    }
    void endsquence() {
        win.Play();
        isplay = true;

        audios.Stop();
        audios.PlayOneShot(start);
        GetComponent<Movement>().enabled = false;
        Invoke("nextlevel", scencechangetime);

    }

    void nextlevel() {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        int nextlevelscene = currentscene + 1;
        if (nextlevelscene == SceneManager.sceneCountInBuildSettings) 
        {
            nextlevelscene = 0;
        }
        SceneManager.LoadScene(nextlevelscene);
    }
    


    void reloadscene() {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentscene);
        SceneManager.LoadScene(currentscene);

    }
}
