using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    private Main maincode;

    private Rigidbody2D eggRB;
    private Animator myanimator;
    private bool isPressed;

    private GameObject TopPosition;
    private GameObject LeftPosition;
    private GameObject RightPosition;
    private GameObject BottomPosition;

    private float thisPosX;
    private float thisPosY;
    private Vector2 MousePosition;
    private Vector2 objPosition;

    public bool isBlueNode;
    public bool isGreenNode;
    public bool isMirror;
    public GameObject left;
    public GameObject right;


    private float diffy;
    public GameObject Lasernode;

    public GameObject shinylight;
    public GameObject electricityeffect;
    public GameObject zoomyelec;

    public float leftcorrection;
    public float rightcorrection;
    public float topcorrection;
    public float bottomcorrection;

    void Start() {


        maincode = GameObject.Find("UICanvasNonChange").GetComponent<Main>();
        TopPosition = GameObject.Find("TopPosition");
        LeftPosition = GameObject.Find("LeftPosition");
        RightPosition = GameObject.Find("RightPosition");
        BottomPosition = GameObject.Find("BottomPosition");
        myanimator = GetComponent<Animator>();
        //////
        isPressed = false;
        diffy = 0;
        
    }


    void Update() {

        if (maincode.endinglevel == false) {

            float diff = this.transform.position.x - left.transform.position.x;

            if (left.transform.position.y > right.transform.position.y) {
                diffy = this.transform.position.y - left.transform.position.y;
            }
            else if (left.transform.position.y < right.transform.position.y) {
                diffy = this.transform.position.y - right.transform.position.y;
            }

            if (isPressed && MyStaticClass.paused == false) {
                MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
                transform.position = new Vector3(objPosition.x + thisPosX, objPosition.y + thisPosY, this.transform.position.z);
            }


            if (this.transform.position.y >= TopPosition.transform.position.y + diffy + topcorrection) {
                this.transform.position = new Vector3(this.transform.position.x, TopPosition.transform.position.y + diffy + topcorrection, this.transform.position.z);
            }

            if (this.transform.position.y <= BottomPosition.transform.position.y - diffy + bottomcorrection) {
                this.transform.position = new Vector3(this.transform.position.x, BottomPosition.transform.position.y - diffy + bottomcorrection, this.transform.position.z);
            }
            if (this.transform.position.x <= LeftPosition.transform.position.x + diff+leftcorrection) {
                this.transform.position = new Vector3(LeftPosition.transform.position.x + diff + leftcorrection, this.transform.position.y, this.transform.position.z);
            }
            if (this.transform.position.x >= RightPosition.transform.position.x - diff + rightcorrection) {
                this.transform.position = new Vector3(RightPosition.transform.position.x - diff + rightcorrection, this.transform.position.y, this.transform.position.z);
            }
            


        }


        if (maincode.endinglevel == true && !isMirror) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            isPressed = false;
            //shinylight.SetActive(true);
            electricityeffect.SetActive(true);
            zoomyelec.SetActive(true);

        }
    }

    void OnMouseDown() {

        //Debug.Log(GetComponent<Collider>().GetType());
        //if (GetComponent<Collider2D>().GetType() == typeof(CircleCollider2D)) {

            if (!isBlueNode && MyStaticClass.paused == false) {
                MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
                thisPosX = transform.position.x - objPosition.x;
                thisPosY = transform.position.y - objPosition.y;
                ////////////////
                isPressed = true;

                GetComponent<SpriteRenderer>().color = new Color(30, 0, 0, 1f);

                if (isGreenNode) {
                    GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1f);
                }

            }
        
    }

    void OnMouseUp() {
        if (!isBlueNode) {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                isPressed = false;
        }
    }

        private void OnMouseOver() {
        if (MyStaticClass.paused == false) {
            //SelectionArrows.SetActive(true);
        }
    }

    private void OnMouseExit() {
        //SelectionArrows.SetActive(false);
    }

    

   
}