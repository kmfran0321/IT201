using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] float enemySpeed, dis;
    Vector3 StartPos;
    public bool stop;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartPos = transform.position;
    }


    void Update()
    {
        dis = Vector3.Distance(transform.position, player.position);

        if (dis <= 8f)
        {
            //chase
            chase();
        }
        if (dis > 8f)
        {
            //go back home
            goHome();
        }
    }

    void chase()
    {
        transform.LookAt(player);
        transform.Translate(0, 0, enemySpeed * Time.deltaTime);
    }

    void goHome()
    {
        transform.LookAt(StartPos);
        transform.position = Vector3.Lerp(transform.position, StartPos, 0.002f);
    }
}
