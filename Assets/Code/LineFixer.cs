using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFixer : MonoBehaviour {

    public ReflectRays reflectrayscode;

    public LineRenderer lr1orig;
    public LineRenderer lr2;


    public Vector3[] holder;
    public int thepos;

    void Start() {
        
        lr2 = transform.GetComponent<LineRenderer>();

    }

    
    void Update() {

        lr2.positionCount = lr1orig.positionCount;

        //Get old Position Length
        Vector3[] newPos = new Vector3[lr1orig.positionCount];
        //Get old Positions
        lr1orig.GetPositions(newPos);

        holder = reflectrayscode.arrayholder;

        System.Array.Reverse(holder);

        //Copy Old postion to the new LineRenderer
        lr2.GetComponent<LineRenderer>().SetPositions(holder);

        

        


    }
}
