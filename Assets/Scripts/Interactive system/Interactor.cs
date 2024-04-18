using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Interactor : MonoSingletongeneric<Interactor>
{
       
    public float moveSpeed, RotationSpeed = 0.1f;
    bool isSelected = false;
    public GameObject selectedobj = null;
    GameObject SelectedObjectReference = null;
    Vector3 previouspos;
    public PlayerModelController playermodelcontroller;
    
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    { 
        GameObject selectedobj =  SelectAnObject();
        if (selectedobj != null) {
            previouspos = selectedobj.transform.position;
        }
        

        //Deselect on right click and reset the rotation
        if (Input.GetMouseButtonDown(1))
        {            
            DeselectObject(selectedobj);
        }

        ShakeyShakeyLabUtensils(selectedobj);


        if (selectedobj != null && isSelected ==true)
        {
            // getting mouse input coordinates then converting it into unity cordinates
            Vector3 Mousepos = Input.mousePosition;
            Mousepos.z = 5;
            Vector3 ScreentoWorld = Camera.main.ScreenToWorldPoint(Mousepos);

           
            Vector3 target = new Vector3(0, ScreentoWorld.y, ScreentoWorld.z);
            selectedobj.transform.position = target;

            // rotate the selected gmo 
            Rigidbody rgbd = selectedobj.GetComponent<Rigidbody>();
            if (rgbd != null ) {
                rgbd.constraints = RigidbodyConstraints.None;
                RotateSelectedObjectwithScrollWheel(selectedobj);
                rgbd.constraints = RigidbodyConstraints.FreezeRotation;
            }
            
            //selectedobj.transform.position = Vector3.MoveTowards(selectedobj.transform.position, target, moveSpeed * Time.deltaTime);
        }
        
        
    }


    public GameObject SelectAnObject()
    {
        if (Input.GetMouseButtonDown(0) && isSelected == false)
        {
            isSelected = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);           
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                SelectedObjectReference = raycastHit.collider.gameObject;    
                  
            }

        }
        return SelectedObjectReference;
    }

    public void DeselectObject(GameObject selectedGameobject)
    {  
        if (selectedGameobject != null)
        {
            //Debug.Log("deselectionworking");
            isSelected = false;
            selectedGameobject.transform.rotation = Quaternion.identity;
            selectedGameobject.transform.position = previouspos;
            selectedGameobject = null;
            previouspos = Vector3.zero;
        }

    }

    private void ShakeyShakeyLabUtensils(GameObject selectedGameobject)
    {
        if (Input.GetMouseButtonDown(2))
        {
            // middle click makes it shake 
            Animator CameraAnimator = Camera.main.GetComponent<Animator>();
            CameraAnimator.SetTrigger("IsShake");
            
            
            LabUtensilMaterialManager MaterialManager = selectedGameobject.GetComponent<LabUtensils>()?.FillFlaskChildObject.GetComponent<LabUtensilMaterialManager>();
            if (MaterialManager.GetFillamt() >= .25f)
            {
                MaterialManager.SetColor();
                playermodelcontroller.OnPlayerExcited();
            }
            else
            {
                MaterialManager.SetColor(Color.green);

                playermodelcontroller?.OnPlayerIrritated();
            }
            
            
            
        }
    }
    private float DetectScrollWheelInput()
    {
        float ScrollWheelDelta = Input.GetAxis("Mouse ScrollWheel");
        return ScrollWheelDelta;
    }

    public void RotateSelectedObjectwithScrollWheel(GameObject selected)
    {
        float scrollwheel = DetectScrollWheelInput();
        if (scrollwheel > 0)
        {
            selected.gameObject.transform.RotateAroundLocal(new Vector3(1, 0, 0), Mathf.Clamp((scrollwheel * RotationSpeed*Time.deltaTime),0,100));
        }
        else if (scrollwheel < 0)
        {
            selected.gameObject.transform.RotateAroundLocal(new Vector3(1, 0, 0), Mathf.Clamp((scrollwheel * RotationSpeed*Time.deltaTime), -100,0));

        }
    }


   
}
