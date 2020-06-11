using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    // Start with some position objects and switch between them
    // Start is called before the first frame update
    public GameObject[] walls;
    public Text projectionLabel;
    Transform trans;
    Transform parentTrans;
    Transform[] staticRot;
    Quaternion anchorFrom;
    Quaternion anchorTo;
    Vector3 camFrom;
    Vector3 camTo;
    Vector3 camPosUp;
    Vector3 camPosDown;
    RaycastHit hit;
    Camera cam;
    int currentPos = 1;
    float timeCount = 0f;
    void Start() {
        Screen.fullScreen = true;
        trans = GetComponent<Transform>();
        parentTrans = trans.parent.transform;
        createPos();
        anchorFrom = staticRot[0].rotation;
        anchorTo = staticRot[0].rotation;
        camFrom = camPosUp;
        camTo = camPosUp;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (parentTrans.rotation != anchorTo || trans.localPosition != camTo) {
            parentTrans.rotation = Quaternion.Slerp(anchorFrom,anchorTo,timeCount);
            trans.localPosition = Vector3.Lerp(camFrom,camTo,timeCount);
            timeCount = timeCount + Time.deltaTime;
            if (timeCount >= 1f) { //Finished rotating
                timeCount = 1f;
                ActivateWalls();
            }
        }
        if(Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            if (hit.collider.gameObject.tag.Equals("Wall"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    /*******************/
    /* Camera Movement */
    /*******************/
    public void OnCycleRight() {
        timeCount = 0f;
        anchorFrom = parentTrans.rotation;
        camFrom = trans.localPosition;
        if (currentPos <= 4) {
            if (currentPos == 4) {
                currentPos = 1;
            }
            else {
                currentPos += 1;
            }
        }
        else if (currentPos <= 8) {
            if (currentPos == 8) {
                currentPos = 5;
            }
            else {
                currentPos += 1;
            }
        }
        else if (currentPos <= 12) {
            if (currentPos == 12) {
                currentPos = 9;
            }
            else {
                currentPos += 1;
            }
        }
        anchorTo = staticRot[currentPos-1].rotation;
    }
    public void OnCycleLeft() {
        timeCount = 0f;
        anchorFrom = parentTrans.rotation;
        camFrom = trans.localPosition;
        if (currentPos <= 4) {
            if (currentPos == 1) {
                currentPos = 4;
            }
            else {
                currentPos -= 1;
            }
        }
        else if (currentPos <= 8) {
            if (currentPos == 5) {
                currentPos = 8;
            }
            else {
                currentPos -= 1;
            }
        }
        else if (currentPos <= 12) {
            if (currentPos == 9) {
                currentPos = 12;
            }
            else {
                currentPos -= 1;
            }
        }
        anchorTo = staticRot[currentPos-1].rotation;
    }
    public void OnCycleUp() {
        if (currentPos <= 4) {
            timeCount = 0f;
            camFrom = trans.localPosition;
            anchorFrom = parentTrans.rotation;
            currentPos += 4;
            anchorTo = staticRot[currentPos-1].rotation;
        }
        else if (currentPos > 8 && currentPos <= 12) {
            timeCount = 0f;
            camFrom = trans.localPosition;
            anchorFrom = parentTrans.rotation;
            //camFrom = camPosDown;
            currentPos -= 8;
            anchorTo = staticRot[currentPos-1].rotation;
            camTo = camPosUp;
        }
    }
    public void OnCycleDown() {
        if (currentPos >= 5 && currentPos <= 8) {
            timeCount = 0f;
            camFrom = trans.localPosition;
            anchorFrom = parentTrans.rotation;
            currentPos -= 4;
            anchorTo = staticRot[currentPos-1].rotation;
        }
        else if (currentPos <= 4) {
            timeCount = 0f;
            camFrom = trans.localPosition;
            anchorFrom = parentTrans.rotation;
            //camFrom = camPosUp;
            currentPos += 8;
            anchorTo = staticRot[currentPos-1].rotation;
            camTo = camPosDown;
        }
    }
    void createPos() {
        camPosUp = new Vector3(0,0,23);
        camPosDown = new Vector3(0,-5,16);
        staticRot = new Transform[12];
        for(int i = 0; i<12; i++) {
            staticRot[i] = new GameObject("anchorPos " + i).GetComponent<Transform>();
            staticRot[i].position = new Vector3(0,11.5f,0);
        }
        staticRot[0].Rotate(-30,180,0);//Looking at -Z
        staticRot[1].Rotate(-30,90,0);//Looking at -X
        staticRot[2].Rotate(-30,0,0);//Looking at +Z
        staticRot[3].Rotate(-30,-90,0);//Looking at +X
        //Looking down
        staticRot[4].Rotate(-80,180,0);//Up points toward -Z
        staticRot[5].Rotate(-80,90,0);//Up points toward -X
        staticRot[6].Rotate(-80,0,0);//Up points toward +Z
        staticRot[7].Rotate(-80,-90,0);//Up points toward +X
        //Looking at base
        staticRot[8].Rotate(0,180,0);
        staticRot[9].Rotate(0,90,0);
        staticRot[10].Rotate(0,0,0);
        staticRot[11].Rotate(0,-90,0);
    }

    /********/
    /* Misc */
    /********/
    void ActivateWalls()
    {
        foreach(GameObject wall in walls)
        {
            wall.SetActive(true);
        }
    }

    public void ToggleFullScreen(bool fsBool)
    {
        Screen.fullScreen = fsBool;
    }

    public void OnToggleCamProjection()
    {
        cam.orthographic = !cam.orthographic;
        if (cam.orthographic)
        {
            projectionLabel.text = "Orthographic";
        }
        else
        {
            projectionLabel.text = "Perspective";
        }
    }
}
