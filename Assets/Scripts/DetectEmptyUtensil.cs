using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEmptyUtensil : MonoBehaviour
{
    // Add this script to the particle effects to make sure the collision is detected
    private void OnTriggerEnter(Collider other)
    {
        LabUtensils labUtensils = null;
        labUtensils = other.GetComponent<LabUtensils>();
        
        if (labUtensils != null && labUtensils.isFilledUp == false)
        {
            labUtensils.FillFlaskChildObject.SetActive(true);
            labUtensils.isFilledUp = true;
            //labUtensils.FillFlaskChildObject.GetComponent<Renderer>().material.SetFloat("_FillAmount", 0.5f); 
        }
        else if(labUtensils != null && labUtensils.isFilledUp == true)
        {
            labUtensils.FillFlaskChildObject.GetComponent<LabUtensilMaterialManager>().SetFillAmount(0.15f);
        }
    }
}
