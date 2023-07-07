using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ReflectRays : MonoBehaviour {

    public Node nodecode;

    const int Infinity = 999;

    int maxReflections = 31;
    int currentReflections = 0;

    [SerializeField]
    Vector2 startPoint, direction;
    List<Vector3> Points;
    int defaultRayDistance = 50;
    LineRenderer lr;

    public GameObject greenlaser;
    public LayerMask mylayermask;
    public LayerMask mylayermask2;
    private RaycastHit2D[] hitData3;

    public Vector3[] arrayholder;

    public int mydirx;
    public int mydiry;


    void Start() {
        Points = new List<Vector3>();
        lr = transform.GetComponent<LineRenderer>();

    }



    private void Update() {


        direction.y = greenlaser.transform.position.y + mydiry;
        direction.x = greenlaser.transform.position.x + mydirx;
        startPoint.x = greenlaser.transform.position.x;
        startPoint.y = greenlaser.transform.position.y;

        var hitData = Physics2D.Raycast(startPoint, (direction - startPoint).normalized, defaultRayDistance, mylayermask);


        currentReflections = 0;
        Points.Clear();
        Points.Add(startPoint);



        if (hitData) {
            ReflectFurther(startPoint, hitData);
        }
        else {
            Points.Add(startPoint + (direction - startPoint).normalized * Infinity);

            if (lr.positionCount == 2) {
                //Debug.DrawLine(startPoint, new Vector2(greenlaser.transform.position.x + 100, greenlaser.transform.position.y));

                var zerohitter = Physics2D.LinecastAll(startPoint, new Vector2(greenlaser.transform.position.x + mydirx, greenlaser.transform.position.y+mydiry), mylayermask2);
                

                if (zerohitter.Length > 0) {

                    for (int i = 0; i < zerohitter.Length; i++) {

                        if (zerohitter[i].transform.gameObject.tag == "Node") {
                            nodecode = zerohitter[i].transform.gameObject.GetComponent<Node>();
                            nodecode.active = true;
                            //Debug.Log(hitData.transform.gameObject.tag);
                        }
                    }
                }
            }
        }



        //////////////////////////////
        //////////////////////////////

        lr.positionCount = Points.Count;
        arrayholder = Points.ToArray();

        lr.SetPositions(Points.ToArray());



        


        if (lr.positionCount >= 3 && lr.positionCount <= 30) {
            for (int c = 2; c < lr.positionCount+1; c++) {

                var looprayhitter1 = Physics2D.LinecastAll(new Vector2(lr.GetPosition(c - 2).x, lr.GetPosition(c - 2).y), new Vector2(lr.GetPosition(c - 1).x, lr.GetPosition(c - 1).y), mylayermask2);

                //Debug.DrawLine(new Vector2(lr.GetPosition(c-2).x, lr.GetPosition(c-2).y), new Vector2(lr.GetPosition(c-1).x, lr.GetPosition(c-1).y));

                for (int i = 0; i < looprayhitter1.Length; i++) {

                    if (looprayhitter1[i].transform.gameObject.tag == "Node") {
                        nodecode = looprayhitter1[i].transform.gameObject.GetComponent<Node>();
                        nodecode.active = true;
                    }
                }
            }
        }


    }


    private void ReflectFurther(Vector2 origin, RaycastHit2D hitData) {
        if (currentReflections > maxReflections) return;


        Points.Add(hitData.point);
        currentReflections++;

        Vector2 inDirection = (hitData.point - origin).normalized;
        Vector2 newDirection = Vector2.Reflect(inDirection, hitData.normal);

        var newHitData = Physics2D.Raycast(hitData.point + (newDirection * 0.0001f), newDirection * 100, defaultRayDistance, mylayermask);


        if (newHitData) {
            ReflectFurther(hitData.point, newHitData);
        }
        else {
            Points.Add(hitData.point + newDirection * defaultRayDistance);
        }

        

    }




}