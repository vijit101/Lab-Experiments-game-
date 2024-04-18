using System.Collections.Generic;
using UnityEngine;

public class PlayerModelController : MonoBehaviour
{
    Animator playerAnimator = null;
   
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
   public void OnPlayerExcited()
   {
        playerAnimator.SetTrigger("isExcited");
   }

   public void OnPlayerIrritated() 
   {
        playerAnimator.SetTrigger("IsIrritated");
    }


}
