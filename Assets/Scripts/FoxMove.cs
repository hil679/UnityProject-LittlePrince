using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoxMove : MonoBehaviour
{
    [SerializeField] Animator moveAni;
    [SerializeField] Transform[] TargetPos;
    [SerializeField] Transform RotationPos;
    [SerializeField] float speed = 1f;
    [SerializeField] float RotateSpeed = 1f;
    int TargetNum = 0;
    public bool isMoving = false;

    private bool isFoxRotationSame = false;
    private Vector3 NewTargetPos;
    void Start()
    {
       // transform.position = TargetPos[TargetNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MovePath();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("A pressed");
            moveAni.SetTrigger("Moving");
            isMoving = true;
            //moveAni.
        }
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    moveAni.SetTrigger("Stopped");
        //}
    }

    public void SnakeMovingBtn()
    {
        isMoving = true;
    }

    private void MovePath()
    {
        NewTargetPos = new Vector3(TargetPos[TargetNum].transform.position.x, transform.position.y, TargetPos[TargetNum].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, NewTargetPos, speed * Time.deltaTime);
        //transform.LookAt(TargetPos[TargetNum]);

        Vector3 dir = TargetPos[TargetNum].transform.position - this.transform.position;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * RotateSpeed);

        if (transform.position == NewTargetPos && isMoving == true)
        {
            
            if (TargetNum == TargetPos.Length-1)
            {
                isMoving = false;
                moveAni.SetTrigger("Stopped");
                Debug.Log("Stopped");

                this.transform.rotation = Quaternion.Euler(0, 134.1f, 0);
                //while (!isFoxRotationSame)
                //{
                //    Vector3 dir2 = RotationPos.transform.position - this.transform.position;
                //    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir2), Time.deltaTime * RotateSpeed);
                //    if (this.transform.rotation.eulerAngles ==(dir2))
                //    {
                //        isFoxRotationSame = true;
                //    }
                //}
                //StartCoroutine("rotationFox");
            }
            else
            {
                TargetNum++;
            }
        }
    }
    IEnumerator rotationFox()
    {
        while (isFoxRotationSame)
        {
             Vector3 dir2 = RotationPos.transform.position - this.transform.position;
             this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir2), Time.deltaTime * RotateSpeed);
        
        }
        
        yield return null;
    }
}
