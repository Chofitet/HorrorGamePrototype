using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutBlackScreen : MonoBehaviour
{
    Image BlackScreen;
    public float speed;
    [SerializeField] bool FadeOut;
    float fade;
    // Start is called before the first frame update
    void Start()
    {
        
        BlackScreen = GetComponent<Image>();
        
        if (FadeOut)
        {
            fade = 0;
        }
        else
        {
            fade = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FadeOut)
        {
            
            fade += speed * Time.deltaTime;
            //vas al negro //apagado
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, fade);
        }
        else
        {
            fade -= speed * Time.deltaTime;
            //vas al negro //apagado
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, fade);
        }
        Mathf.Clamp(fade, 0, 1);
    }
}
