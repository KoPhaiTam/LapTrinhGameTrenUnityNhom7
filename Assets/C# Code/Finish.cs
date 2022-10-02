using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Chest")
        {
            Invoke("CompleteLevel", 5f);
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene("ContinueScene");
    }
}
