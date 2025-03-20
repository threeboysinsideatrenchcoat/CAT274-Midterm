using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayMain", 2f);
    }

    public void DelayMain()
    {
        SceneManager.LoadScene("Main Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
