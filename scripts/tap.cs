using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class tap : MonoBehaviour
{
    public float rotZ;
    public float rotationSpeed = 0;
    public Text scoreText;
    public int score = 0;
    private Renderer rend;
    public double debugfasz = 255;
      private Renderer renderer;
    float timeLeft;
    Color targetColor;
    // Start is called before the first frame update
    void Start()
    {
        // rend = GetComponent<Renderer>();
        renderer = GetComponent<Renderer>();
        targetColor = new Color(255,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0)){
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if(Physics.Raycast(ray, out hit)){
        //         Debug.Log(hit.transform.name);
        //     }
        //     // Debug.Log("click");
        // }
        rotZ += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            renderer.material.color = targetColor;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);
        
            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }

    void OnMouseDown(){
        Debug.Log("Sprite Clicked");
        score++;
        scoreText.text = score.ToString();
        // StartCoroutine(FadeIn());
        
    }
    


    void OnMouseUp(){
        StartCoroutine(FadeOut());
    }



    IEnumerator FadeOut()
    {
        for (float i = 0; i <= 255; i += Time.deltaTime/1000)
            {
                //255 255 255 255 bol kell 255 0 0 255
                // set color with i as alpha
                rend.material.color = new Color(255, i, i, 255);
            }
                yield return null;
    }

    IEnumerator FadeIn()
    {
        for (double i = 255; i >= 0; i -= Time.deltaTime)
            {
                Debug.Log(Math.Floor(i));
                //255 255 255 255 bol kell 255 0 0 255
                // set color with i as alpha
                // debugfasz -= Math.Floor(i/100);
                rend.material.color = new Color(255, Convert.ToInt32(Math.Floor(i)), Convert.ToInt32(Math.Floor(i)), 255);
                yield return null;
            }
    }
}
