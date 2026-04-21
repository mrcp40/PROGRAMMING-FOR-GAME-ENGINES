using UnityEngine;

public class TransparencingScript : MonoBehaviour
{
    [SerializeField]
    private float alphaValue = 0.0f; 

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;
        Color color = mat.color;
        color.a = alphaValue; 
        mat.color = color;
    }
}
