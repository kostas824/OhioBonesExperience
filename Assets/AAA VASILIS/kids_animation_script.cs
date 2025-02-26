using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class kids_animation_script : MonoBehaviour
{ 
    [SerializeField] public Animator animator;
void Start()
   {

}
void Update()
    {
    if (Input.GetKeyDown(KeyCode.X))
{
    animator.SetBool("isplaying", true);
}
if (Input.GetKeyDown(KeyCode.Z))
{
    animator.SetBool("isplaying", false);
}
}
}