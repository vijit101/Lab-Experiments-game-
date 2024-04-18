using UnityEngine;

public class LabEquipment : MonoBehaviour,IInteractable
{
    [Header("Lab Equipment Properties")]
    public bool isMoveOnSelection = false;
    public bool hasUIOptions = false;
    public bool isFilledUp = false;

    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }
}
