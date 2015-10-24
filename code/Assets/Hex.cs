using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {

    public Vector2 HexPosition;
    public HexModel HexModel { get; set; }

    public void InitializeModel()
    {
        var hex = new GameObject();
        hex.name = "Dupa";
        hex.AddComponent<HexModel>();
        HexModel = hex.GetComponent<HexModel>();
        hex.transform.parent = transform;
        hex.transform.localPosition = new Vector3(0, 0, 0);
        int hexHeight;
        switch (Random.Range(1, 4)) {
            case 3:
                hexHeight = 4;
                break;
            case 2:
                hexHeight = 3;
                break;
            default:
                hexHeight = 1;
                break;
        }


        hex.transform.position = new Vector3(hex.transform.position.x, hexHeight, hex.transform.position.z);
        hex.transform.localScale = new Vector3(hex.transform.localScale.x, hexHeight, hex.transform.localScale.z);
        hex.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        hex.GetComponent<Renderer>().material.mainTexture = Resources.Load("textures/hex") as Texture2D;
    }

	void Start () 
    {
	
	}

	void Update () 
    {
	
	}
}
