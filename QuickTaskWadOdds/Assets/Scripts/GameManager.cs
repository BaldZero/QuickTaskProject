using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public RawImage start;
    public RawImage end;
    public RawImage pause;
    // Start is called before the first frame update
    void Start()
    {
        start.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartGame()
    {
        start.gameObject.SetActive (false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D (Collision2D collision) 
    {
        end.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.gameObject.SetActive(false);
    }

}
