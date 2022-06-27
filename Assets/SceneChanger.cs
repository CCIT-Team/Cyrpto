using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Animator animator;

    public void Start()
    {
        animator.GetComponent<Animator>();
    }

    public void Update()
    {
        GotoMainScene();
        GotoGameScene();
    }
    public void GotoMainScene()
    {
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            animator.SetTrigger("fadeout");
        }
    }

    public void GotoGameScene()
    {
        if (SceneManager.GetActiveScene().name == "Game_Scene")
        {
            animator.SetTrigger("fadeout");
        }
    }
}
