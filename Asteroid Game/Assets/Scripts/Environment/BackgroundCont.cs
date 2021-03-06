﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCont : MonoBehaviour {

    public Sprite bg1;
    public Sprite bg2;

    public Animator anim;
    int randomBg;

    // Use this for initialization
    void Start () {
     anim = GetComponent<Animator>();

       randomBg = Random.Range(0, 2);

        
        if (randomBg == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bg1;
            StartCoroutine(playAnim());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bg2;
            StartCoroutine(playAnim());
        }
	}
    private IEnumerator repeatCoroutine(int Max_seconds, int Min_seconds)
    {
        yield return new WaitForSeconds(Random.Range(Min_seconds, Max_seconds));
        StartCoroutine(playAnim());
        Debug.Log("Animation started");
    }
    private IEnumerator playAnim()
    {
        if (randomBg == 0)
        {
            anim.SetBool("PlayPlanet", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("PlayPlanet", false);
            StartCoroutine(repeatCoroutine(15, 30));
            Debug.Log("Animation stopped");
        }
        else
        {
            anim.SetBool("PlayNebula", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("PlayNebula", false);
            StartCoroutine(repeatCoroutine(15, 30));
            Debug.Log("Animation stopped");
        }
    }

}
