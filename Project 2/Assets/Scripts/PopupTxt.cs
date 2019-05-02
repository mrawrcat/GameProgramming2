using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTxt : MonoBehaviour
{
    public GameObject floatingTxt, canvas;
    public Text fadeText;
    private HoverUIListener UIListener;
    private Text fadeTxtco;
    private int poolSize;
    public int currentPool;
    private Vector2 objectPoolPosition = new Vector2(-100, -100);
    public List<Text> Textpool;
    private void Start()
    {
        UIListener = FindObjectOfType<HoverUIListener>();
        poolSize = 5;
        currentPool = 0;
        
        Textpool = new List<Text>();
        for (int i = 0; i < poolSize; i++)
        {
            fadeTxtco = (Text)Instantiate(fadeText, objectPoolPosition, Quaternion.identity);
            fadeTxtco.rectTransform.localScale = new Vector3(.01f, .01f, 1);
            fadeTxtco.transform.SetParent(canvas.transform, true);
            Textpool.Add(fadeTxtco);
            
        }
    }
    private void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                if (UIListener.isUIOverride)
                {
                    Debug.Log("Cancelled OnMouseDown! A UI element has override this object!");
                }
                else
                {
                    Debug.Log(hit.collider.name);
                    if(hit.collider.name == "Gain Trash")
                    {
                        Textpool[currentPool].text = "Gain Trash";
                        Textpool[currentPool].transform.position = worldPoint;
                        Textpool[currentPool].CrossFadeAlpha(1, 0.01f, false);
                        Textpool[currentPool].CrossFadeAlpha(0, 0.5f, false);
                        currentPool += 1;
                    }
                    if (hit.collider.name == "Gain Plastic")
                    {
                        Textpool[currentPool].text = "Gain Plastic";
                        Textpool[currentPool].transform.position = worldPoint;
                        Textpool[currentPool].CrossFadeAlpha(1, 0.01f, false);
                        Textpool[currentPool].CrossFadeAlpha(0, 0.5f, false);
                        currentPool += 1;
                    }
                    if (hit.collider.name == "Gain Metal")
                    {
                        Textpool[currentPool].text = "Gain Metal";
                        Textpool[currentPool].transform.position = worldPoint;
                        Textpool[currentPool].CrossFadeAlpha(1, 0.01f, false);
                        Textpool[currentPool].CrossFadeAlpha(0, 0.5f, false);
                        currentPool += 1;
                    }
                    //Textpool[currentPool].text = "Gain Plastic";
                    //Textpool[currentPool].transform.position = worldPoint;
                    //Textpool[currentPool].CrossFadeAlpha(1, 0.01f, false);
                    //Textpool[currentPool].CrossFadeAlpha(0, 0.5f, false);
                    //currentPool += 1;
                    //Textpool[currentPool].transform.position = objectPoolPosition;





                    //Instantiate(floatingTxt, worldPoint, Quaternion.identity);
                    //fadeTxtco = Instantiate(fadeText, worldPoint, Quaternion.identity);
                    //fadeTxtco.rectTransform.localScale = new Vector3(.01f, .01f, 1);
                    //fadeTxtco.transform.SetParent(canvas.transform, true);
                    //TxtPool[currentPool].transform.position = new Vector3(1,1,1);
                }
                
               
            }
        }

        if (currentPool >= poolSize)
        {
            currentPool = 0;
        }

    }
    
   
}
