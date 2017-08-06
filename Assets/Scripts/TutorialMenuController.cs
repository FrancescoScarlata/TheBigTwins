using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialMenuController : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true;

    }

   public void  ChooseTutorial(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ComeBack()
    {
        SceneManager.LoadScene("SplashScreen");
    }

}
