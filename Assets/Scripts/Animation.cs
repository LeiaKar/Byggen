using UnityEngine;
using UnityEngine.InputSystem;


public class NewInputSystem : MonoBehaviour
{
   SpriteRenderer _spriteRotation;
   Animator animator;


   void Start()
   {
       _spriteRotation = GetComponent<SpriteRenderer>();
       animator = GetComponent<Animator>();
   }


   void Update()
   {
       animator.SetBool("run", false);
      
       if (Keyboard.current[Key.D].IsPressed())
       {
           Debug.Log("D Is Pressed");
           _spriteRotation.flipX = true;
           animator.SetBool("run", true);
       }
       if (Keyboard.current[Key.A].IsPressed())
       {
           Debug.Log("A Is Pressed");
           _spriteRotation.flipX = false;
           animator.SetBool("run", true);
       }
   }
}
