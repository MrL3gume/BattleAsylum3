using UnityEngine;
using System.Collections;


public class CarteAléatoire : MonoBehaviour {

    public void LoadScene()
    {
        Application.LoadLevel(Random.Range(1, 6));
    }

}
