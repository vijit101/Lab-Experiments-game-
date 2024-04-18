using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShader1 : MonoBehaviour
{
    public Material material1 ;
    public Color SetReactionColor;
    // Start is called before the first frame update
    void Start()
    {
        material1.SetFloat("_FillAmount", .25f);
        material1.SetColor("_Tint", SetReactionColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
