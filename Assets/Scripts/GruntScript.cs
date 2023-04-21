using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject jhon;
    private float LastShoot;
    private int health=2;
    //vida 
    private void Update(){
        Vector3 direction= jhon.transform.position-transform.position;
        if(direction.x>=0.0f)transform.localScale= new Vector3(1.0f,1.0f,1.0f);
        else transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
        //PARA QUE EL MOUNSTRO PEGUE 
        float distance= Mathf.Abs(jhon.transform.position.x-transform.position.x);
        if(distance<1.0f&& Time.time>LastShoot+0.25f){
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f)direction= Vector3.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BalletScript>().SetDirection(direction);
    }
     public void Hit(){
        health= health-1;
        if(health==0) Destroy(gameObject);
    }
}
