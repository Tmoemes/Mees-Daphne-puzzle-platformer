using System.Collections;
using System.Collections.Generic;
//using RPG.Attributes;
//using RPG.Control;
using UnityEngine;
using Invector.vCharacterController;

namespace Dialogue
{
    public class AIConversant : MonoBehaviour //IRaycastable
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;
        PlayerConversant playerConversant;

        private void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
        }

        //public CursorType GetCursorType()
        //{
        //    return CursorType.Dialogue;
        //}

        //public bool HandleRaycast(PlayerController callingController)
        //{
        //    if (dialogue == null)
        //    {
        //        return false;
        //    }

        //    Health health = GetComponent<Health>();
        //    if (health && health.IsDead()) return false;

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        callingController.GetComponent<PlayerConversant>().StartDialogue(this, dialogue);
        //    }
        //    return true;
        //}

        public void OnCollisionStay(Collision other)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E");
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("Collision");
                    playerConversant.StartDialogue(this, dialogue);
                    //HandleInteraction();
                }
                
            }
            
        }

        public bool HandleInteraction()
        {
            //vThirdPersonController player = new vThirdPersonController();
            if (dialogue == null) 
            {
                return false;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E");
                playerConversant.StartDialogue(this,dialogue);
            }
            return true;
        }

        public string GetName()
        {
            return conversantName;
        }
    }
}