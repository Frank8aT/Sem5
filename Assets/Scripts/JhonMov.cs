using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMov : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    //vida 
    private int health=5;
    void Start()
    {
        Rigidbody2D= GetComponent<Rigidbody2D>();
        Animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         Horizontal= Input.GetAxisRaw("Horizontal");
         if(Horizontal<0.0f)transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
         else if(Horizontal>0.0f)transform.localScale= new Vector3(1.0f,1.0f,1.0f);
         Animator.SetBool("running",Horizontal!=0.0f);
         Debug.DrawRay(transform.position, Vector3.down*0.1f, Color.blue);
         if(Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
            Grounded= true;
         }
         else Grounded= false;
         if(Input.GetKeyDown(KeyCode.W)&& Grounded){
            Jump();
         }
         if(Input.GetKey(KeyCode.Space)&& Time.time>LastShoot+0.25f){
            Shoot();
            LastShoot= Time.time;
         }
    }
    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up* JumpForce);
    }
    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f)direction= Vector3.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BalletScript>().SetDirection(direction);
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity= new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    public void Hit(){
        health= health-1;
        if(health==0) Destroy(gameObject);
    }
}
