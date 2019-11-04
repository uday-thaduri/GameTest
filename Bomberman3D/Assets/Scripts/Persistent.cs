using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    static Persistent instance = null;
    public static Persistent Instance
    {
        get { return instance; }

    }
    private void Awake()
    {
        if(instance!=null && instance!=this )
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
