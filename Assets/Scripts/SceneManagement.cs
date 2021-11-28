using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneManagement : MonoBehaviour
{
    [SerializeField] Text pauseplay;
    [SerializeField] Text planehealth;
    [SerializeField] Text enemyplanehealth;

    private void Update()
    {
        BadEndScene();
        NextScene();
        GoodEndScene();
        
    }
   public void LoadScene(string scene)
   {
       SceneManager.LoadScene(scene);
   }

   public void PausePlayGame()
   {   
       if(pauseplay.text == "Pause")
       {
        Time.timeScale = 0;
        pauseplay.text = "Play";
       }
       else if(pauseplay.text == "Play")
       {
        Time.timeScale = 1;
        pauseplay.text = "Pause";
       }
       
   }

   public void BadEndScene()
   {
       if (planehealth.text == "Health: 0")
       {
           SceneManager.LoadScene("BadEnd");
       }
   }

   public void NextScene()
   {
       if (enemyplanehealth.text == "Health: 0" && 
       SceneManager.GetActiveScene().name != "Level3")
       {
        // load the nextlevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }
   }

   public void GoodEndScene()
   {
       if (SceneManager.GetActiveScene().name == "Level3" &&
       enemyplanehealth.text == "Health: 0")
       {  
        SceneManager.LoadScene("GoodEnd");
       }
   }
    
}
