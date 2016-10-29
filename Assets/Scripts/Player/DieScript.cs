using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour
{
    void OnTirggerEnter2D(Collider2D collider)
    {
        Debug.Log("11");
        if (collider.tag == "Enemy")
            SceneManager.LoadScene(01);
    }

}
