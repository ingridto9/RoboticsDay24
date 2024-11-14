using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingObj : MonoBehaviour
{

    public GameObject WallE;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "flebo")
        {
            GameObject.Find("flebo").transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, WallE.transform.localPosition.z + 0.2f);
        } else if (collision.gameObject.name == "pinze")
        {

        } else if (collision.gameObject.name == "bisturi")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
