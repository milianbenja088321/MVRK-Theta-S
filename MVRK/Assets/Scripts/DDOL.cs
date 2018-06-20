using UnityEngine;
//using Vuforia;

public class DDOL : MonoBehaviour 
{

    private static DDOL instance = null;
    public static DDOL Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DDOL>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "DDOL";
                    instance = go.AddComponent<DDOL>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    } // end static instance

    public bool isVR;
    public bool isAr;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Accessors and Mutators
    public bool GetVRComp() { return isVR; }
    public void SetVRComp(bool _is) { isVR = _is; }
}
