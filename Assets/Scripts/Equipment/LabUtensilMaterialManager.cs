using UnityEngine;


public class LabUtensilMaterialManager : MonoBehaviour
{
    public Material material1;
    public Color SetReactionColor;
    public Color DefaultColor;
    // Start is called before the first frame update

    private void Awake()
    {
        if (material1 == null )
        {
            Debug.LogError("Material Linking Missing");
        }
        else
        {
            material1.SetColor("_Tint", DefaultColor);
            SetFillAmount(.25f);
        }
    }

    public void SetFillAmount(float fillAmt)
    {
        material1.SetFloat("_FillAmount", fillAmt);
    }
    public void SetColor()
    {
        material1.SetColor("_Tint", SetReactionColor);
    }

    public void SetColor(Color customColor)
    {
        material1.SetColor("_Tint", customColor);

    }

    public void ChangeWobblex(float wobbbleVal)
    {
        material1.SetFloat("WobbleX", wobbbleVal);
    }

    public float GetFillamt()
    {
        return material1.GetFloat("_FillAmount");
    }
}
