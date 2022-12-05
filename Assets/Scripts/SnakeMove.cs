using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField] Animator moveAni;
    [SerializeField] Transform[] TargetPos;
    [SerializeField] float speed = 5f;
    int TargetNum = 0;
    bool isMoving = true;
    void Start()
    {
       // transform.position = TargetPos[TargetNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePath();
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveAni.SetTrigger("Moving");
            //moveAni.
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveAni.SetTrigger("Stopped");
        }
    }

        
    private void MovePath()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos[TargetNum].transform.position, speed * Time.deltaTime);

        if (transform.position == TargetPos[TargetNum].transform.position && isMoving == true)
        {
            TargetNum++;
            //new Vector3 TargetV = Quaternion.Euler(TargetPos[TargetNum].rotation);
            this.transform.rotation = Quaternion.Euler(TargetPos[TargetNum].rotation.eulerAngles - this.transform.rotation.eulerAngles);
            if (TargetNum == TargetPos.Length)
            {
                isMoving = false;
            }
        }
    }
}
