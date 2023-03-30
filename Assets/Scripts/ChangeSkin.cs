using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public MeshRenderer[] mesh = new MeshRenderer[9];
    public Material[] defaultSkin;
    public Material[] transparentSkin;
    public int skinNum;
    // Start is called before the first frame update

    public void Start()
    {
        skinNum = SaveSystem.LoadData("skin");
        SkinChange();
    }

    public void SkinChange()
    {
        switch (skinNum)
        {
            case 0:
                mesh[0].material = defaultSkin[1];
                mesh[1].material = defaultSkin[4];
                mesh[2].material = defaultSkin[2];
                mesh[3].material = defaultSkin[2];
                mesh[4].material = defaultSkin[3];
                mesh[5].material = defaultSkin[2];
                mesh[6].material = defaultSkin[2];
                mesh[7].material = defaultSkin[1];
                mesh[8].material = defaultSkin[0];
                break;
            case 1:
                mesh[0].material = transparentSkin[1];
                mesh[1].material = transparentSkin[4];
                mesh[2].material = transparentSkin[2];
                mesh[3].material = transparentSkin[2];
                mesh[4].material = transparentSkin[3];
                mesh[5].material = transparentSkin[2];
                mesh[6].material = transparentSkin[2];
                mesh[7].material = transparentSkin[1];
                mesh[8].material = transparentSkin[0];
                break;
        }
    }
}
