using UnityEngine;
using System.Collections;

public class ArtifactTouch : MonoBehaviour {
    
    GameObject[] cena;
    Animator screenFade;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0f);
            cena = GameObject.FindGameObjectsWithTag("Cena");
            Debug.Log(cena);
            for (int i = 0; i < cena.Length; i++)
            {
                Animator animator = cena[i].GetComponent<Animator>();
                animator.SetTrigger("Found");
                cena[i].GetComponent<AudioSource>().Play();
            }

            screenFade = GameObject.Find("Fader").GetComponent<Animator>();
            screenFade.SetTrigger("Fade Start");

        }
    }
}
