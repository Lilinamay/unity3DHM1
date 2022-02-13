using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField] LayerMask aimColliderMask = new LayerMask();

    [SerializeField] Transform pfSnow;
    [SerializeField] Transform spawnSnowPos;

    //[SerializeField] Transform DebugTransform;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 myCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(myCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            //DebugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.shoot)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnSnowPos.position).normalized;
            Instantiate(pfSnow, spawnSnowPos.position, Quaternion.LookRotation(aimDir, Vector3.forward));
            starterAssetsInputs.shoot = false;
        }
    }
}
