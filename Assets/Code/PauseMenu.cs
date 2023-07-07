using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    
    private CapsuleFader capsulefadercode;
    private Main maincode;

    public GameObject fadeobject;
    

    public TextMeshProUGUI soundtext;
    private bool soundeffectsonoroff;
    public TextMeshProUGUI trailtext;
    private bool trailonoroff;
    public TextMeshProUGUI styletext;
    private bool styleonoroff;
    public bool paused;
    public GameObject settingsbutton;

    private LineRenderer laserline1;
    private LineRenderer laserline2;

    void Start() {

        

        maincode = GameObject.Find("UICanvasNonChange").GetComponent<Main>();
        capsulefadercode = GameObject.Find("CapsuleFade").GetComponent<CapsuleFader>();
        laserline1 = GameObject.Find("UICanvasNonChange").GetComponent<LineRenderer>();

        if (maincode.greenlaserlevelyes) {
            laserline2 = GameObject.Find("GreenLineRenderer").GetComponent<LineRenderer>();
        }

        //////////////////////////
        soundeffectsonoroff = true;
        styleonoroff = false;
        trailonoroff = false;
        paused = false;

        if (MyStaticClass.soundholder == false) {
            soundtext.text = "Sound - Off";
            MyStaticClass.soundholdervolume = 0;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            soundeffectsonoroff = false;
            
        }
        if (MyStaticClass.soundholder == true) {
            soundtext.text = "Sound - On";
            MyStaticClass.soundholdervolume = 1;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            soundeffectsonoroff = true;
        }

        if (MyStaticClass.togglestyle == false) {
            styletext.text = "Laser Style - Constant";
            styleonoroff = false;
            laserline1.textureMode = LineTextureMode.Stretch;
            if (maincode.greenlaserlevelyes) {
                laserline2.textureMode = LineTextureMode.Stretch;
            }

            

        }
        if (MyStaticClass.togglestyle == true) {
            styletext.text = "Laser Style - Moving";
            styleonoroff = true;
            laserline1.textureMode = LineTextureMode.Tile;
            if (maincode.greenlaserlevelyes) {
                laserline2.textureMode = LineTextureMode.Tile;
            }
           
        }

        

    }



    public void ShowPauseMenu() {
        if (MyStaticClass.paused == false) {
            settingsbutton.GetComponent<Button>().interactable = false;
            fadeobject.SetActive(true);
            Time.timeScale = 0;
            MyStaticClass.paused = true;
        }
    }
    public void HidePauseMenu() {
        settingsbutton.GetComponent<Button>().interactable = true;
        fadeobject.SetActive(false);
        Time.timeScale = 1;
        MyStaticClass.paused = false;
    }
    public void SoundToggle() {
        soundeffectsonoroff = !soundeffectsonoroff;
        if (soundeffectsonoroff == false) {
            soundtext.text = "Sound - Off";
            MyStaticClass.soundholdervolume = 0;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            MyStaticClass.soundholder = false;
        }
        if (soundeffectsonoroff == true) {
            soundtext.text = "Sound - On";
            MyStaticClass.soundholdervolume = 1;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            MyStaticClass.soundholder = true;
        }
    }
    public void TrailToggle() {
        trailonoroff = !trailonoroff;
        if (trailonoroff == false) {
            trailtext.text = "Trail - Off";
            MyStaticClass.toggletrail = false;
            //eggcode.TurnoffTrail();
        }
        if (trailonoroff == true) {
            trailtext.text = "Trail - On";
            MyStaticClass.toggletrail = true;
            //eggcode.TurnonTrail();
        }
    }
    public void StyleToggle() {
        styleonoroff = !styleonoroff;
        if (styleonoroff == false) {
            styletext.text = "Laser Style - Constant";
            MyStaticClass.togglestyle = false;
            laserline1.textureMode = LineTextureMode.Stretch;
            if (maincode.greenlaserlevelyes) {
                laserline2.textureMode = LineTextureMode.Stretch;
            }
        }
        if (styleonoroff == true) {
            styletext.text = "Laser Style - Moving";
            MyStaticClass.togglestyle = true;
            laserline1.textureMode = LineTextureMode.Tile;
            if (maincode.greenlaserlevelyes) {
                laserline2.textureMode = LineTextureMode.Tile;
            }
        }
    }
    public void ReturnToMainMenu() {
        Time.timeScale = 1;
        capsulefadercode.levelchange = 2;
        capsulefadercode.StartFadeIn();
    }
    




}
