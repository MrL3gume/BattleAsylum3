using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public PlayerController p1;
    public PlayerController p2;

    public Text P1win;
    public Text P2win;

    Animator anim;
    private bool begin = true;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        //Players obviously start with disabled controls.
        //The simplest way I found was to simply disable both PlayerController scripts.
        p1.enabled = false;
        p2.enabled = false;
        //This flag tells the game manager wether or not it has to play the countdown animation.
        begin = true;

        P1win.text = "";
        P2win.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            anim.Play("CountDown");
            //waits for 3 seconds then calls the enableControls() function.
            Invoke("enableControls", 3);
            begin = false;
        }
        //This checks every frame if a player is dead.
        if (p1.isDead() || p2.isDead())
        {
            p1.enabled = false;
            p2.enabled = false;

            if (p1.isDead())
            {
                P2win.text = "Le joueur 2 a remporté ce combat !";
            }
            else if( p2.isDead())
            {
                P1win.text = "Le joueur 1 a remporté ce combat !";
            }
            StartCoroutine(reloadCoroutine2());
           
        }
    }
    
    IEnumerator reloadCoroutine()
    {                 
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);   
    }

    IEnumerator reloadCoroutine2()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(Random.Range(1, 6));
    }

    void enableControls()
    {
        p1.enabled = true;
        p2.enabled = true;
    }

}
