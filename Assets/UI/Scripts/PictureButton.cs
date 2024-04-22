using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureButton : MonoBehaviour
{
    private Texture2D _picture;

    private void Start()
    {
        _picture = GetComponent<Image>().sprite.texture;
    }

    public void SendPicture()
    {
        IntersceneData.SetPicture(_picture);
    }
}
