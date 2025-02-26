using UnityEngine;
using UnityEngine.UI;

public class SetObjectTransform : MonoBehaviour
{
    [System.Serializable]
    public class ObjectTransform
    {
        public GameObject obj;
        public Vector3 position;
        public Vector3 rotation;
    }

    public ObjectTransform[] objects;
    public Button setTransformButton;

    void Start()
    {
        if (setTransformButton != null)
        {
            setTransformButton.onClick.AddListener(SetTransforms);
        }
    }

    public void SetTransforms()
    {
        foreach (var item in objects)
        {
            if (item.obj != null)
            {
                Debug.Log($"Setting {item.obj.name} to Position: {item.position} | Rotation: {item.rotation}");

                item.obj.transform.localPosition = item.position;
                item.obj.transform.rotation = Quaternion.Euler(item.rotation);
            }
        }
    }
}