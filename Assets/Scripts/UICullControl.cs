using UnityEngine;
using UnityEngine.UI;

public class UICullControl : MonoBehaviour
{
    public bool cullBack = true; // Pode ser configurado no Inspector

    private void Start()
    {
        // Encontre o componente de imagem (ou outro componente de UI) neste objeto.
        Image image = GetComponent<Image>();

        if (image != null)
        {
            // Defina o culling de acordo com a variável cullBack.
            image.material.SetFloat("_Cull", cullBack ? 0 : 2);
        }
    }
}
