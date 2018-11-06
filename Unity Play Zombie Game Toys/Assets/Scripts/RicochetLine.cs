using UnityEngine;
using System.Collections;

public class RicochetLine : MonoBehaviour {
    Ray shot;
    RaycastHit hit;
    [SerializeField]
    int NumOfRicochets;
    [SerializeField]
    float range;
    [SerializeField]
    LayerMask shootable;
    [SerializeField]
    LineRenderer line;

    // Use this for initialization
    void Start () {
        line.enabled = true;
        line.SetVertexCount (NumOfRicochets + 1);
    }

    // Update is called once per frame
    void Update () {
        line.SetPosition (0, transform.position);
        shot.origin = transform.position;
        shot.direction = transform.forward;
        for (int i = 1; i <= NumOfRicochets && Physics.Raycast (shot, out hit, range, shootable); i++) {
            line.SetPosition (i, hit.point);
            shot.origin = hit.point;
            shot.direction = Vector3.Reflect (shot.direction, hit.normal);
        }
    }
}
