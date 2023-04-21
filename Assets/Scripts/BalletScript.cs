using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    void Start()
    {
        Rigidbody2D= GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity= Direction * Speed;
    }
    public void SetDirection(Vector3 direction){
        Direction= direction;
    }
    public void DestroyBullet(){
        Destroy(gameObject);
    }
    // Update is called once per frame
    private void onTriggerEnter2D(Collider2D collision){
     GruntScript Grunt = collision.GetComponent<GruntScript>(); 
       JhonMov jhon = collision.GetComponent<JhonMov>();
      
       //vida 
        if(Grunt!=null){
         Grunt.Hit();
        }
        if(jhon!=null){
        jhon.Hit();
        }
       DestroyBullet();

    }
    /*private void OnCollisionEnter2D(Collision2D collision){

    }*/

/*    void Update()
    {
        
    }*/
}