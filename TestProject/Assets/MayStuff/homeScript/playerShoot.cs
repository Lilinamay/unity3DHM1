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
    [SerializeField] GameObject gameManager;
    public GameObject testObject;
    snowManager snowManager;
    Vector3 originalPos;
    public float maxTime =5.0f; // Time taken to lerp

    public float curTime = 100f;



    //[SerializeField] Transform DebugTransform;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        snowManager = gameManager.GetComponent<snowManager>();
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

        if (starterAssetsInputs.dash)
        {
            moveToEnemy();
            starterAssetsInputs.dash = false;
        }

        moveFunction();

    }

    void moveToEnemy()
    {
        if (snowManager.hitEnemy)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                if (!snowManager.go)
                {

                    originalPos = transform.position;
                    curTime = 0;
                    snowManager.go = true;
                }

            //}
        }
    }

    void moveFunction()
    {
        if (snowManager.enemy != null && curTime < maxTime) {
            //Debug.Log("dash");
            Vector3 space = (snowManager.enemy.transform.position - originalPos).normalized;
            curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, maxTime);
            testObject.transform.position = Vector3.Lerp(originalPos, snowManager.enemy.transform.position-space, curTime / maxTime);
            //testObject.transform.position = Vector3.Lerp(snowManager.enemy.transform.position , originalPos + space, curTime / maxTime);
            //testObject.transform.position = Vector3.Lerp(originalPos, transform.position, curTime / maxTime);
            //Debug.Log(snowManager.enemy.transform.position);

        }
        if (snowManager.enemy != null && curTime >= maxTime)
        {
            snowManager.go = false;
        }



    }
}
