using System.Collections;
using UnityEngine;

public class LabUtensils : LabEquipment
{
    [Header("Lab Utensil Properties")]
    public ParticleSystem PouringParticle;
    public Transform PouringParticleInstantPoint;
    public EquipmentEnum EquipmentType;
    public GameObject FillFlaskChildObject;
    float pouringAngle = .6f;
    ParticleSystem Instantiatedparticle = null;
    public Material ColorChangeMaterial;
    // Start is called before the first frame update


    

    private void Update()
    {
        //Debug.Log(transform.rotation.x + "pouring" + pouringAngle);
        if ((transform.rotation.x > pouringAngle ||transform.rotation.x < -pouringAngle)&&isFilledUp ==true)
        {
            if (Instantiatedparticle ==null)
            {
                Instantiatedparticle = Instantiate(PouringParticle, PouringParticleInstantPoint.transform.position, PouringParticle.transform.rotation, this.transform);
                StartCoroutine(EmptyLabEquipment(this));
                
            }
        }


       
    }

    IEnumerator EmptyLabEquipment(LabUtensils utensil)
    {
        yield return new WaitForSeconds(4);
        utensil.isFilledUp = false;
        utensil.FillFlaskChildObject.SetActive(false);
        Destroy(Instantiatedparticle);
        

    }
}
