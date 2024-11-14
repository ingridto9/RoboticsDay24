using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
//[ExecuteAlways]

public class ChessBoard : MonoBehaviour
{
    public GameObject CuboIniziale;
    public GameObject WallE;
    public GameObject Armadio1;
    public GameObject Armadio2;
    public GameObject Armadio3;
    public GameObject CArm;
    public GameObject paziente;
    public GameObject DottZivago;
    public GameObject Inf1;
    public GameObject Inf2;
    public GameObject Inf3;
    public GameObject seggiolino;
    public GameObject scrivania;
    public GameObject tavolo;
    public GameObject ECG;
    public GameObject Ecografo;
    public GameObject separe;
    public GameObject carrellino1;
    public GameObject pinze;
    public GameObject flebo;
    public GameObject bisturi;

    public Material Radialmat;

    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); // Dizionario per i colori originali


    // Start is called before the first frame update
    void Start()
    {
        initializeChessBoard();
        initializeObjects();
        CuboIniziale.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f);
        for (int i = 0; i < 183; i++)
        {
            GameObject cube = GameObject.Find("Cube" + i);
            if (cube != null)
            {
                originalColors[cube] = cube.GetComponent<Renderer>().material.color;
            }
        }
    }

    void initializeChessBoard()
    {
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 15; i++)
            {
                int k = i + 15 * j;
                //Debug.Log("valore k: " + k);
                GameObject.Find("Cube" + k).transform.localPosition = new Vector3(-2 + i, 0, 15 + j);
            }
        }

        for (int i = 0; i < 18; i++)
        {
            int k = 45 + i;
            GameObject.Find("Cube" + k).transform.localPosition = new Vector3(-2 + i, 0, 18);
        }

        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                int k = 63 + j * 6 + i;
                GameObject.Find("Cube" + k).transform.localPosition = new Vector3(-2 + i, 0, 19 + j);
               // Debug.Log("valore k: " + k);
            }
        }

        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                int k = 93 + j * 10 + i;

                GameObject.Find("Cube" + k).transform.localPosition = new Vector3(6 + i, 0, 19 + j);
            }
        }
    }

    void initializeObjects()
    {
        //stanza 1
        Armadio1.transform.localPosition = new Vector3(0,1.5f,23);
        carrellino1.transform.localPosition = new Vector3(0.9f, 0.5f, 20);

        //stanza 2
        Armadio2.transform.localPosition = new Vector3(15,1.5f,26);
        Armadio3.transform.localPosition = new Vector3(15,1.5f,22);
        tavolo.transform.localPosition = new Vector3(9, 0.5f, 27);
        CArm.transform.localPosition = new Vector3(6.5f, 1.5f, 23);
        DottZivago.transform.localPosition = new Vector3(10.75f, 0.5f, 25.25f);
        paziente.transform.localPosition = new Vector3(14.3f, 0.5f, 18.8f);
        separe.transform.localPosition = new Vector3(10.5f, 1.65f, 22);
        Inf1.transform.localPosition = new Vector3(9, 1.35f, 19);
        Ecografo.transform.localPosition = new Vector3(9, 0.5f, 18);
        scrivania.transform.localPosition = new Vector3(10.6f, 0.5f, 18);
        seggiolino.transform.localPosition = new Vector3(11, 0.8f, 19);
        ECG.transform.localPosition = new Vector3(10, 1.25f, 18);
        Inf2.transform.localPosition = new Vector3(5, 1.3f, 16);
        Inf3.transform.localPosition = new Vector3(6.3f, 0.5f, 16.2f);
        pinze.transform.localPosition = new Vector3(10.753f, 1.507f, 14.986f);
        flebo.transform.localPosition = new Vector3(-0.004f, 0.563f, 20.005f);
        bisturi.transform.localPosition = new Vector3(15.05f, -0.35f, 10.72f);

        //corridoio
        WallE.transform.localPosition = new Vector3(-2, 1, 15);

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 posWallE = WallE.transform.localPosition;

        for (int i =0; i < 183; i++)
        {
            if (GameObject.Find("Cube"+i).transform.localPosition.x == posWallE.x && GameObject.Find("Cube" + i).transform.localPosition.z == posWallE.z)
            {
                GameObject.Find("Cube" + i).GetComponent<Renderer>().material.color = Color.white;
            }
            else if (originalColors.ContainsKey(GameObject.Find("Cube"+i)))
            {
                GameObject.Find("Cube" + i).GetComponent<Renderer>().material.color = originalColors[GameObject.Find("Cube" + i)];
            }
        }
    }
}
