using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Main maincode;

    public Sprite[] nodesactive;

    public bool active;
    private int myholder;

    public GameObject electricityeffect;
    public GameObject zoomyelec;

    private string thisname;
    private bool playonce;

    public AudioClip soundeffect;

    void Start() {

        maincode = GameObject.Find("UICanvasNonChange").GetComponent<Main>();
        active = false;

        //gameObject.layer = 5;
        //Debug.Log(gameObject.layer);

        thisname = transform.gameObject.name;
        //Debug.Log(thisname);

    }

    // Update is called once per frame
    void LateUpdate() {

        if (active) {
            if (!playonce) {
                AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.45f);
                playonce = true;
            }
            GetComponent<SpriteRenderer>().sprite = nodesactive[1];
            electricityeffect.SetActive(true);
        }

        if (!active) {
            playonce = false;
            GetComponent<SpriteRenderer>().sprite = nodesactive[0];
            electricityeffect.SetActive(false);
        }

        if (maincode.endinglevel == true) {
            zoomyelec.SetActive(true);
        }



    }


}
