using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntersceneData
{
    private static Texture2D s_picture;

    public static void SetPicture(Texture2D picture)
    {
        s_picture = picture;
    }

    public static Texture2D GetPicture()
    {
       return s_picture;
    }
}
