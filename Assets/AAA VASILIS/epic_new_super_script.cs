using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SyncRotation : MonoBehaviour
{
    public Transform rotatingObject;  // Object A (the one being rotated)
    public Transform followerObject;  // Object B (the one that follows)
    public float rotationMultiplier = 1f; // Adjust if needed

    private  Quaternion originalRotation;
    
    private void Start()
    {
        if (followerObject != null)
        {
            // Save the original position and rotation
            originalRotation = rotatingObject.rotation;


        }
    }
    private void Update()
    {
        if (rotatingObject != null && followerObject != null)
        {
            // Apply rotation from Object A to Object B
            //in the of  rotatingObject.eulerAngles.x * rotationMultiplier ONLY
            followerObject.rotation = Quaternion.Euler(
                followerObject.eulerAngles.x + ((originalRotation.x - rotatingObject.eulerAngles.x) * rotationMultiplier),
                followerObject.eulerAngles.y + ((originalRotation.y - rotatingObject.eulerAngles.y) * rotationMultiplier),
                followerObject.eulerAngles.z + ((originalRotation.z - rotatingObject.eulerAngles.z) * rotationMultiplier)
            );
        }
    }
}