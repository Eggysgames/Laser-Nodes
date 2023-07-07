using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CapsuleFader : MonoBehaviour {

    private Animator capsulefade;
    public int levelchange;
    public int levelnumber;

    public AudioClip soundeffect;

    void Start() {
        levelchange = 1;
        capsulefade = GetComponent<Animator>();

    }

    public void startfirstlevel() {
        if (levelchange == 1) {
            SceneManager.LoadScene("1");
        }
        if (levelchange == 2) {
            SceneManager.LoadScene("-0Main Menu");
            MyStaticClass.paused = false;
        }
        if (levelchange == 3) {
            SceneManager.LoadScene("-1LevelSelect");
        }
        if (levelchange == 4) {
            SceneManager.LoadScene("-2Credits");
        }
        if (levelchange == 5) {
            //MyStaticClass.endlevel = false;
            //MyStaticClass.paused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (levelchange == 6) {
            SceneManager.LoadScene(levelnumber.ToString());
        }
    }

   

    public void StartFadeIn() {
        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);
        capsulefade.SetTrigger("change");
    }


}
