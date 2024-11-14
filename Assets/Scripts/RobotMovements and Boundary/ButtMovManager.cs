using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtMovManager : MonoBehaviour
{
    public GameObject WallE;

    private float x_axis;
    private float z_axis;

    public float duration = 0.25f;
    private bool canPress = true; // Variabile per gestire il cooldown
    public float cooldownTime = 0.3f; // Tempo di attesa prima di poter premere di nuovo

    private float[,] Matrice_fixed_OBJ = new float[,]
    {
        {-1f,23f}, //Armadio1
        {0f,23f},
        {1f,23f},
        {2f,23f},
        {3f,23f},

        {3f,20f},//Carrello

        {5f,16f},//Infermieri
        {6f,16f},

        {9f,18f},//Infermiere
        {10f,18f},//tavolo e ECHO
        {10f,18f},
        {9f,19f},

        {10f,22f}, //Separé
        {11f,22f},

        {6f,25f}, //CARM
        {6f,24f},
        {6f,23f},
        {6f,22f},
        {7f,25f},
        {7f,24f},
        {7f,23f},
        {7f,22f}

    };
    void Start()
    {

    }

    void Update()
    {
        x_axis = WallE.transform.localPosition.x;
        z_axis = WallE.transform.localPosition.z;
    }

    public void ButtonUp()
    {
        if (canPress)
        {
            StartCoroutine(HandleButtonPress(CheckBoundaryUp));
            CheckObj();
        }
    }

    public void ButtonRight()
    {
        if (canPress)
        {
            StartCoroutine(HandleButtonPress(CheckBoundaryRight));
            CheckObj();
        }
    }

    public void ButtonDown()
    {
        if (canPress)
        {
            StartCoroutine(HandleButtonPress(CheckBoundaryDown));
            CheckObj();
        }
    }

    public void ButtonLeft()
    {
        if (canPress)
        {
            StartCoroutine(HandleButtonPress(CheckBoundaryLeft));
            CheckObj();
        }
    }

    private IEnumerator HandleButtonPress(System.Action checkBoundary)
    {
        canPress = false; // Disabilita i pulsanti
        checkBoundary.Invoke(); // Esegui il controllo del confine
        yield return new WaitForSeconds(cooldownTime); // Aspetta il tempo di cooldown
        canPress = true; // Riabilita i pulsanti
    }

    void CheckBoundaryUp()
    {
        if (z_axis >= 23 && x_axis <= 3 && x_axis >= -2)
        {
            WallE.transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, 23);
        }
        else if (z_axis >= 18 && x_axis <= 5 && x_axis >= 4)
        {
            WallE.transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, 18);
        }
        else if (z_axis >= 27)
        {
            WallE.transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, 27);
        }
        else
        {
            StartCoroutine(Move_Up());
        }
    }

    void CheckBoundaryRight()
    {
        if (x_axis >= 3 && z_axis <= 23 && z_axis >= 19 && x_axis<=5)
        {
            WallE.transform.localPosition = new Vector3(3, WallE.transform.localPosition.y, WallE.transform.localPosition.z);
        }
        else if (x_axis >= 12 && z_axis <= 17 && z_axis >= 15)
        {
            WallE.transform.localPosition = new Vector3(12, WallE.transform.localPosition.y, WallE.transform.localPosition.z);
        }
        else if (x_axis >= 15)
        {
            WallE.transform.localPosition = new Vector3(15, WallE.transform.localPosition.y, WallE.transform.localPosition.z);
        }
        else
        {
            StartCoroutine(Move_Right());
        }
    }

    void CheckBoundaryDown()
    {
        if (z_axis <= 15)
        {
            WallE.transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, 15);
        }
        else if (z_axis <= 18 && x_axis <= 15 && x_axis >= 13)
        {
            WallE.transform.localPosition = new Vector3(WallE.transform.localPosition.x, WallE.transform.localPosition.y, 18);
        }
        else
        {
            StartCoroutine(Move_Down());
        }
    }

    void CheckBoundaryLeft()
    {
        if (x_axis <= -2)
        {
            WallE.transform.localPosition = new Vector3(-2, WallE.transform.localPosition.y, WallE.transform.localPosition.z);
        }
        else if (x_axis <= 6 && z_axis >= 19 && x_axis>= 4)
        {
            WallE.transform.localPosition = new Vector3(6, WallE.transform.localPosition.y, WallE.transform.localPosition.z);
        }
        else
        {
            StartCoroutine(Move_Left());
        }
    }

    void CheckObj()
    {
        float pos_xp1 = WallE.transform.localPosition.x+1;
        float pos_xm1 = WallE.transform.localPosition.x-1;

        float pos_y = WallE.transform.localPosition.y;
        float pos_zp1 = WallE.transform.localPosition.z+1;
        float pos_zm1 = WallE.transform.localPosition.z-1;

    }

    private IEnumerator Move_Up()
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 startPosition = WallE.transform.localPosition;
        Vector3 targetPosition = startPosition + new Vector3(0, 0, 1); // Muovi lungo l'asse Z
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            WallE.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Aspetta un frame
        }

        WallE.transform.localPosition = targetPosition; // Assicurati che l'oggetto arrivi esattamente alla posizione finale
    }

    private IEnumerator Move_Right()
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 startPosition = WallE.transform.localPosition;
        Vector3 targetPosition = startPosition + new Vector3(1, 0, 0); // Muovi lungo l'asse X
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            WallE.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Aspetta un frame
        }

        WallE.transform.localPosition = targetPosition; // Assicurati che l'oggetto arrivi esattamente alla posizione finale
    }

    private IEnumerator Move_Down()
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 startPosition = WallE.transform.localPosition;
        Vector3 targetPosition = startPosition + new Vector3(0, 0, -1); // Muovi lungo l'asse Z
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            WallE.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Aspetta un frame
        }

        WallE.transform.localPosition = targetPosition; // Assicurati che l'oggetto arrivi esattamente alla posizione finale
    }

    private IEnumerator Move_Left()
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 startPosition = WallE.transform.localPosition;
        Vector3 targetPosition = startPosition + new Vector3(-1, 0, 0); // Muovi lungo l'asse X
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            WallE.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Aspetta un frame
        }

        WallE.transform.localPosition = targetPosition; // Assicurati che l'oggetto arrivi esattamente alla posizione finale
    }
}
