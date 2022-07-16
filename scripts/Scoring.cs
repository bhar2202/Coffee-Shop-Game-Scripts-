using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [Header("Default Starting Cash")]
    public static int cash;

    // Start is called before the first frame update
    void Start()
    {
        cash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "$" + cash.ToString();
    }
}
