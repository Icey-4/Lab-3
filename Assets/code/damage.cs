using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    //Animator animator;
    public int health = 100;
    public int EbulletSpeed;

    public float delay = 1;
    float timer;

    public GameObject Ebullet;
    private GameObject EbulletSpawn;

    public Transform Ebulletpos;
    private Transform PlayPos;

    private void Start()
    {
        //animator = GetComponent<Animator>();

    }

    void Update()
    {
        PlayPos = GameObject.Find("Player").transform;
        transform.LookAt(PlayPos);

        timer += Time.deltaTime;
        if (timer > delay) 
        {
            Attack();
            timer -= delay;
        }

        if (health <= 0)
        {
           // die();
            Destroy(gameObject);

           // if animations use Destroy(gameObject, 1f);
        }

    }

    //void die()
    //{
    // animator.SetBool("die sprite", true);
    // }

    public void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "fire")
       {
            health = health - 20;
       }
        
        //animator.SetTrigger("hit sprite");
    }

    void Attack()
    {
        GameObject EbulletSpawn = Instantiate(Ebullet, Ebulletpos.position, Ebullet.transform.rotation);
        EbulletSpawn.GetComponent<Rigidbody>().velocity = PlayPos.TransformPoint(0, -1, EbulletSpeed);

    }

}
