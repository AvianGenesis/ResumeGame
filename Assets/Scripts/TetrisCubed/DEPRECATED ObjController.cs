using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ObjController : MonoBehaviour
{
    public GameObject[] blocks;
    private GameObject curBlock;
    private GameObject nextBlock;
    private Transform trans;

    //float fall = 0;
    public float fallSpeed = 1;

    private void Start() {
        trans = GetComponent<Transform>();
        //curBlock = Instantiate(blocks[Random.Range(0, 7)], new Vector3(0.5f, 20, 0.5f), Quaternion.identity);  //instantiate random block from block 1-8
    }

    /*
    private void Update() {
        if (curBlock.transform.position.y == 1.0) {
            NewBlock();
        }
        if (Time.time - fall >= fallSpeed) {
            curBlock.transform.Translate(Vector3.down, Space.World);
            fall = Time.time;
        }
        // if block is above limit game over
        if(curBlock.transform.position.y == 21.0) { GameOver(); }
    }
    */

    public void NewBlock() {
        curBlock = Instantiate(nextBlock, new Vector3(0.5f, 20, 0.5f), Quaternion.identity);
        nextBlock = blocks[Random.Range(0, 7)];
    }

    /*public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnRestart()
    {
        RestartLevel();
    }*/

    private Vector3 discreteCamDir(char dir) {
        Vector3 v;
        if (dir == 'f') {v = trans.forward;}
        else if (dir == 'r') {v = trans.right;}
        else {v = trans.up;}
        if (Mathf.Abs(v.x) > Mathf.Abs(v.y) && Mathf.Abs(v.x) > Mathf.Abs(v.z)) {
            if (v.x > 0) {return new Vector3(1,0,0);}
            else return new Vector3(-1,0,0);
        }
        else if (Mathf.Abs(v.z) > Mathf.Abs(v.x) && Mathf.Abs(v.z) > Mathf.Abs(v.y)) {
            if (v.z > 0) {return new Vector3(0,0,1);}
            else return new Vector3(0,0,-1);
        }
        else {
            if (v.y > 0) {return new Vector3(0,1,0);}
            else return new Vector3(0,-1,0);
        }
    }
    private Vector3 discreteCamDir2D(char dir) {
        Vector3 v;
        if (dir == 'f') {v = trans.forward;}
        else {return discreteCamDir('r');}
        if (Mathf.Abs(v.x) > Mathf.Abs(v.z)) {
            if (v.x > 0) {return new Vector3(1,0,0);}
            else return new Vector3(-1,0,0);
        }
        else {
            if (v.z > 0) {return new Vector3(0,0,1);}
            else return new Vector3(0,0,-1);
        }
    }

    /*
    void OnRotateUp() {
        curBlock.transform.Rotate(discreteCamDir('r') * 90.0f, Space.World);
    }

    void OnRotateDown() {
        curBlock.transform.Rotate(discreteCamDir('r') * -90.0f, Space.World);
    }

    void OnRotateLeft() {
        curBlock.transform.Rotate(discreteCamDir('u') * 90.0f, Space.World);
    }

    void OnRotateRight() {
        curBlock.transform.Rotate(discreteCamDir('u') * -90.0f, Space.World);
    }

    void OnTiltLeft() {
        curBlock.transform.Rotate(discreteCamDir('f') * 90.0f, Space.World);
    }

    void OnTiltRight() {
        curBlock.transform.Rotate(discreteCamDir('f') * -90.0f, Space.World);
    }

    void OnMoveUp() {
        curBlock.transform.Translate(discreteCamDir2D('f'), Space.World);
    }

    void OnMoveDown() {
        curBlock.transform.Translate(-discreteCamDir2D('f'), Space.World);
    }

    void OnMoveLeft() {
        curBlock.transform.Translate(-discreteCamDir2D('r'), Space.World);
    }

    void OnMoveRight() {
        curBlock.transform.Translate(discreteCamDir2D('r'), Space.World);
    }
    */

}
