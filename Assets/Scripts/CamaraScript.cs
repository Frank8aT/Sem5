using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jhon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x= jhon.transform.position.x;
        transform.position= position;
    }
}
