using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Vector3 pos;
    public bool KeyBoardMode = false;

    [SerializeField]
    public float kHeroSpeed;

    [SerializeField]
    public float kHeroRotateSpeed;

    public Transform eggSpawnPoint;
    public GameObject eggPrefab;

    [SerializeField]
    public float fire_rate;
    private float next_fire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!KeyBoardMode)
        {
            MouseSettings();
        }
        else
        {
            KeyBoardSettings();
        }
    }

    private void MouseSettings()
    {
        //plane follows cursor
            pos = Input.mousePosition;
            pos.z = 1f;
            transform.position = Camera.main.ScreenToWorldPoint(pos);

            //AD rotate
            kHeroRotateSpeed = 45f; 
            float rotateInput = Input.GetAxis("Horizontal");
            float angle = (-1f * rotateInput) * (kHeroRotateSpeed * Time.smoothDeltaTime);

            transform.Rotate(transform.forward, angle);

            //spacebar and has fire rate
            if(Input.GetKey(KeyCode.Space) && Time.time > next_fire)
            {
                EggSpawn();
            }
        
        //switch from mousemode to keyboard mode
        if(Input.GetKeyDown("m"))
        {
                KeyBoardMode = true;
                Debug.Log("Switching to Keyboard Mode");
                //GlobalBehavior.sTheGlobalBehavior.UpdateToKeyboardUI();
                return;
        }
    }

    private void KeyBoardSettings()
    {
        //sprite continues moving up with the speed
        transform.position += transform.up * (kHeroSpeed * Time.smoothDeltaTime);

        //adjust the speed using W and S
        if(Input.GetKey(KeyCode.W))
        {
            kHeroSpeed += 1f;
        }

        if(Input.GetKey(KeyCode.S))
        {
            kHeroSpeed -= 1f;
        }

        //rotate left or right using A and D or left and right arrows
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));

        //shoot an egg
        if((Input.GetKey(KeyCode.Space)) && Time.time > next_fire)
        {
            EggSpawn();
        }

        //swicth from keyboard mode to mouse mode
        if(Input.GetKeyDown("m"))
        {
            KeyBoardMode = false;
            Debug.Log("Switching to mouse mode");
            //GlobalBehavior.sTheGlobalBehavior.UpdateToMouseUI();
            return;
        }
    }

    public void EggSpawn()
    {

    }
}
