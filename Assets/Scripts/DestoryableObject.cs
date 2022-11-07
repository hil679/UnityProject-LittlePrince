using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryableObject : MonoBehaviour
{
    //행성 랜덤 생성 범위 x: +-15 / y: 13~15 / z: 1~15
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. 랜덤 시간마다 랜덤 위치로 별 생성하기

        //2. 생성된 별 떨어지기
    }

    private void MoveStars(){
        Debug.Log("MoveStars");

    }

    private void StarDestoryed(){
        Debug.Log("StarDestoryed");

    }

    private void StarOnTheGround(){
        Debug.Log("StarOnTheGround");

    }

    private void StarOnTheGround_Effect(){
        Debug.Log("StarOnTheGround_Effect");

    }

    private void StarGennerate(){
        Debug.Log("Star's generated at: ");
    }

    private void StarGennerate_Effect(){
        Debug.Log("StarGennerate_Effect");
    }

    private void OnCollisionEnter(Collision other) {
        //총알과 부딪힌 경우, 땅과 부딪힌 경우
    }
}
