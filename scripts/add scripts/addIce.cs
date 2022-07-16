using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addIce : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject gObj;

    void OnMouseUp()
    {
        gObj.GetComponent<GiveOrder>().addIngredient("Ice");
    }
}
