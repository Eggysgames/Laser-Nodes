using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class Main : MonoBehaviour {

    public StarsImage starscode;
    private Node nodecode;
    private CapsuleFader capsulefadercode;

    public GameObject lasernode1;
    public GameObject lasernode2;
    public GameObject lasernode3;
    public GameObject lasernode4;
    public GameObject lasernode5;
    public GameObject EndLevelScreen;
    public GameObject fireworks;
    public GameObject lasernodegreen;


    private LineRenderer laserLine;
    private LineRenderer laserLine2;
    private Vector3 offset;
    private string scenename;
    private float endleveltimer;
    private int holder1;
    private int holder2;
    private int holder3;
    private int holder4;
    private int holder5;
    private int holder6;
    private int holder7;
    private int holder8;
    private string nameholder;
    private float gametimer;
    private int conhold;

    public LayerMask mylayermask;
    public LayerMask mylayermask2;
    public RaycastHit2D hit;
    public int nodesactive;
    public bool endinglevel;
    public int levellasers;
    public bool greenlaserlevelyes;
    public TextMeshProUGUI gamecompletetext;
    public Button ContinueGameButton;
    public TextMeshProUGUI ContinueGameText;
    public GameObject hintobject;

    public RaycastHit2D[] hitResult;
    public RaycastHit2D[] hitmirror;
    public RaycastHit2D[] hitnode;
    
    public GameObject[] allnodes;

    private Volume volumeholder;
    private Bloom bloomholder;
    private Color mycolour;
    private bool playonce;
    public AudioClip soundeffect;
    public AudioClip soundeffect2;


    void Start() {

        MyStaticClass.paused = false;
        playonce = false;
        capsulefadercode = GameObject.Find("CapsuleFade").GetComponent<CapsuleFader>();
        scenename = SceneManager.GetActiveScene().name;
        laserLine = GameObject.Find("UICanvasNonChange").GetComponent<LineRenderer>();

        laserLine.positionCount = levellasers + 1;
        laserLine.enabled = true;

        if (greenlaserlevelyes) {
            laserLine2 = GameObject.Find("GreenLineRenderer").GetComponent<LineRenderer>();
            laserLine2.enabled = true;
            laserLine2.SetPosition(2, new Vector2(100, 0));
            laserLine2.SetPosition(3, new Vector2(100, 0));
        }

        if (!greenlaserlevelyes) {
            GameObject.Find("GreenLineRenderer").SetActive(false);
        }

        offset = transform.right;

        nodesactive = 0;
        holder1 = 0;
        holder2 = 0;
        holder3 = 0;
        holder4 = 0;
        endinglevel = false;

        conhold = PlayerPrefs.GetInt("Levelsunlocked");

        if (conhold <= 1 && scenename == "-0Main Menu") {
            ContinueGameText.color = new Color(1, 1, 1, 0.2f);
            ContinueGameButton.GetComponent<Button>().enabled = false;
        }

        if (MyStaticClass.togglestyle == false) {
            laserLine.textureMode = LineTextureMode.Stretch;
            if (greenlaserlevelyes) {
                laserLine2.textureMode = LineTextureMode.Stretch;
            }
        }

        if (MyStaticClass.togglestyle == true) {
            laserLine.textureMode = LineTextureMode.Tile;
            if (greenlaserlevelyes) {
                laserLine2.textureMode = LineTextureMode.Tile;
            }
        }



    }


    void Update() {

        if (MyStaticClass.endlevel == false) {
            gametimer += 1 * Time.deltaTime;
            //Debug.Log(gametimer);
        }



        for (int i = 0; i < allnodes.Length; i++) {
            nodecode = allnodes[i].transform.gameObject.GetComponent<Node>();
            nodecode.active = false;
            nodesactive = 0;
        }

        if (levellasers > 0) {

            laserLine.SetPosition(0, lasernode1.transform.position);
            laserLine.SetPosition(1, lasernode2.transform.position);

            hitResult = Physics2D.LinecastAll(lasernode1.transform.position, lasernode2.transform.position, mylayermask);


            for (int i = 0; i < hitResult.Length; i++) {
                if (hitResult[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;

                }

            }

            holder1 = hitResult.Length;
        }
        if (levellasers >= 2) {
            laserLine.SetPosition(2, lasernode3.transform.position);
            RaycastHit2D[] hitResult2 = Physics2D.LinecastAll(lasernode2.transform.position, lasernode3.transform.position, mylayermask);
            for (int i = 0; i < hitResult2.Length; i++) {
                if (hitResult2[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult2[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder2 = hitResult2.Length;

        }

        if (levellasers >= 3) {
            laserLine.SetPosition(3, lasernode4.transform.position);
            RaycastHit2D[] hitResult3 = Physics2D.LinecastAll(lasernode3.transform.position, lasernode4.transform.position, mylayermask);
            for (int i = 0; i < hitResult3.Length; i++) {
                if (hitResult3[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult3[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder3 = hitResult3.Length;
        }

        if (levellasers >= 4) {
            laserLine.SetPosition(4, lasernode1.transform.position);
            RaycastHit2D[] hitResult4 = Physics2D.LinecastAll(lasernode1.transform.position, lasernode4.transform.position, mylayermask);
            for (int i = 0; i < hitResult4.Length; i++) {
                if (hitResult4[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult4[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder4 = hitResult4.Length;
        }

        if (levellasers >= 5) {
            laserLine.SetPosition(5, lasernode3.transform.position);
            RaycastHit2D[] hitResult5 = Physics2D.LinecastAll(lasernode1.transform.position, lasernode3.transform.position, mylayermask);
            for (int i = 0; i < hitResult5.Length; i++) {
                if (hitResult5[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult5[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder5 = hitResult5.Length;
        }

        if (levellasers >= 6) {
            laserLine.SetPosition(6, lasernode5.transform.position);
            RaycastHit2D[] hitResult6 = Physics2D.LinecastAll(lasernode3.transform.position, lasernode5.transform.position, mylayermask);
            for (int i = 0; i < hitResult6.Length; i++) {
                if (hitResult6[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult6[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder6 = hitResult6.Length;
        }

        if (levellasers >= 7) {
            laserLine.SetPosition(7, lasernode4.transform.position);
            RaycastHit2D[] hitResult7 = Physics2D.LinecastAll(lasernode5.transform.position, lasernode4.transform.position, mylayermask);
            for (int i = 0; i < hitResult7.Length; i++) {
                if (hitResult7[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult7[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder7 = hitResult7.Length;
        }

        if (levellasers >= 8) {
            laserLine.SetPosition(8, lasernode2.transform.position);
            RaycastHit2D[] hitResult8 = Physics2D.LinecastAll(lasernode4.transform.position, lasernode2.transform.position, mylayermask);
            for (int i = 0; i < hitResult8.Length; i++) {
                if (hitResult8[i].transform.gameObject.tag == "Node") {
                    nodecode = hitResult8[i].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }

            }

            holder8 = hitResult8.Length;
        }

        //End level effects/screen
        if (endinglevel == true) {
            endleveltimer += 1 * Time.deltaTime;
            gored();
            if (!playonce) {
                AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.45f);
                playonce = true;
            }
        }

        if (endleveltimer > 1 && endleveltimer < 2) {
            gamecompletetext.text = "Level Completed in " + Mathf.Round(gametimer) + " Seconds";
            int intholder = int.Parse(scenename);
            intholder += 1;

            int checkholder = PlayerPrefs.GetInt("Levelsunlocked");

            if (intholder > checkholder) {
                PlayerPrefs.SetInt("Levelsunlocked", intholder);
            }

            if (gametimer >= 0 && gametimer <= 30) {
                starscode.star3();
                PlayerPrefs.SetInt(scenename + "stars", 3);
            }
            if (gametimer > 30 && gametimer <= 60) {
                starscode.star2();
                PlayerPrefs.SetInt(scenename + "stars", 2);
            }
            if (gametimer >= 60 && gametimer <= 120) {
                starscode.star1();
                PlayerPrefs.SetInt(scenename + "stars", 1);
            }
            if (gametimer >= 121) {
                starscode.star0();
                PlayerPrefs.SetInt(scenename + "stars", 0);
            }
            fireworks.SetActive(true);
        }

        if (endleveltimer > 2) {
            goblue();
            EndLevelScreen.SetActive(true);
            /////////////////////

        }

    }

    public void LateUpdate() {
        for (int i = 0; i < allnodes.Length; i++) {
            nodecode = allnodes[i].transform.gameObject.GetComponent<Node>();
            if (nodecode.active == true) {
                nodesactive += 1;
            }
            if (nodecode.active == false) {
                nodesactive -= 1;
            }
        }

        if (scenename == "1" && nodesactive == 3) {
            endinglevel = true;
        }
        if (scenename == "2" && nodesactive == 2) {
            endinglevel = true;
        }
        if (scenename == "3" && nodesactive == 4) {
            endinglevel = true;
        }
        if (scenename == "4" && nodesactive == 4) {
            endinglevel = true;
        }
        if (scenename == "5" && nodesactive == 5) {
            endinglevel = true;
        }
        if (scenename == "6" && nodesactive == 6) {
            endinglevel = true;
        }
        if (scenename == "7" && nodesactive == 6) {
            endinglevel = true;
        }
        if (scenename == "8" && nodesactive == 6) {
            endinglevel = true;
        }
        if (scenename == "9" && nodesactive == 6) {
            endinglevel = true;
        }
        if (scenename == "10" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "11" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "12" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "13" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "14" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "15" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "16" && nodesactive == 7) {
            endinglevel = true;
        }
        if (scenename == "17" && nodesactive == 8) {
            endinglevel = true;
        }
        if (scenename == "18" && nodesactive == 8) {
            endinglevel = true;
        }
        if (scenename == "18" && nodesactive == 8) {
            endinglevel = true;
        }
        if (scenename == "19" && nodesactive == 11) {
            endinglevel = true;
        }
        if (scenename == "20" && nodesactive == 11) {
            endinglevel = true;
        }
        if (scenename == "21" && nodesactive == 8) {
            endinglevel = true;
        }
        if (scenename == "22" && nodesactive == 8) {
            endinglevel = true;
        }
        if (scenename == "23" && nodesactive == 11) {
            endinglevel = true;
        }
        if (scenename == "23" && nodesactive == 13) {
            endinglevel = true;
        }
        if (scenename == "24" && nodesactive == 13) {
            endinglevel = true;
        }
        if (scenename == "25" && nodesactive == 13) {
            endinglevel = true;
        }
        if (scenename == "26" && nodesactive == 14) {
            endinglevel = true;
        }
        if (scenename == "27" && nodesactive == 14) {
            endinglevel = true;
        }
        if (scenename == "28" && nodesactive == 14) {
            endinglevel = true;
        }
        if (scenename == "29" && nodesactive == 14) {
            endinglevel = true;
        }
        if (scenename == "30" && nodesactive == 14) {
            endinglevel = true;
        }
        if (scenename == "31" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "32" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "33" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "34" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "35" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "36" && nodesactive == 9) {
            endinglevel = true;
        }
        if (scenename == "37" && nodesactive == 10) {
            endinglevel = true;
        }
        if (scenename == "38" && nodesactive == 10) {
            endinglevel = true;
        }
        if (scenename == "39" && nodesactive == 10) {
            endinglevel = true;
        }
        if (scenename == "40" && nodesactive == 14) {
            endinglevel = true;
        }
        if (endinglevel == true) {
            MyStaticClass.paused = true;
        }
    }
    public void hitnodecheck() {
        for (int z = 0; z < hitnode.Length; z++) {
            if (hitnode[z].transform.gameObject.tag == "Node") {
                if (hitnode[z].transform.gameObject.tag == "Node") {
                    nodecode = hitnode[z].transform.gameObject.GetComponent<Node>();
                    nodecode.active = true;
                }
            }
        }
    }

   
    public void gored() {
        mycolour = new Color(255, 1, 1);

        volumeholder = GetComponent<Volume>();
        volumeholder.profile.TryGet(out bloomholder);

        bloomholder.intensity.value = 1.1f;
        bloomholder.tint.value = mycolour;
    }

    public void goblue() {
        mycolour = new Color(255, 255, 255);

        volumeholder = GetComponent<Volume>();
        volumeholder.profile.TryGet(out bloomholder);

        bloomholder.intensity.value = 0.93f;
        bloomholder.tint.value = mycolour;
    }

    public void PlayGame() {
        capsulefadercode.levelchange = 1;
        capsulefadercode.StartFadeIn();
        //Debug.Log("Next Level");
    }

    public void BacktoMenuButton() {
        capsulefadercode.levelchange = 2;
        capsulefadercode.StartFadeIn();
        //Debug.Log("Next Level");
    }
    public void LevelSelectButton() {
        capsulefadercode.levelchange = 3;
        capsulefadercode.StartFadeIn();
        //Debug.Log("Next Level");
    }
    public void CreditsButton() {
        capsulefadercode.levelchange = 4;
        capsulefadercode.StartFadeIn();
        //Debug.Log("Next Level");
    }

    public void NextLevelButton() {
        capsulefadercode.levelchange = 5;
        capsulefadercode.StartFadeIn();
        //Debug.Log("Next Level");
    }
    public void ContinueGame() {
        capsulefadercode.levelchange = 6;
        capsulefadercode.levelnumber = conhold;
        capsulefadercode.StartFadeIn();
    }

    public void ShowHint() {
        hintobject.SetActive(true);
    }

    public void PlaySelectSound() {
        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.25f);
    }

}
