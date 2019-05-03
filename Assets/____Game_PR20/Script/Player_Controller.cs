using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Player_Controller : MonoBehaviour
{
    CharacterController controller;
    Animator anima;
    public float speed = 100.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 2.0F;
    public float rotateSpeed = 90.0F;
    private Vector3 moveDirection = Vector3.zero;
    private bool isrunning = false;

    public GameObject deathmenuUi;
    public GameObject scoremenuUi;
    public GameObject deathtimer;
    public GameObject pausemenu;

    public AudioSource feetaudiosource;
    public AudioSource lightaudiosource;

    public TextMeshProUGUI scoretextfield;
    public TextMeshProUGUI cointextfield;

    public TextMeshProUGUI scoreondead;
    public TextMeshProUGUI coinondead;
    public TextMeshProUGUI totalscore;
    public TextMeshProUGUI coinscore;
    public TextMeshProUGUI timer_text;

    public TextMeshProUGUI highscoreondead;
    public TextMeshProUGUI highcoinondead;
    public TextMeshProUGUI hightotalscore;
    public TextMeshProUGUI highcoinscore;

    long score=0;

    public float noOfcoin = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anima = GetComponent<Animator>();
        feetaudiosource.loop = true;
        lightaudiosource.loop = true;
      
    }
    public Canvas can;
    

    // Update is called once per frame
    void Update()
    {
       

        if (controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                anima.SetBool("run_bool", true);
                if(!feetaudiosource.isPlaying)
                {
                    feetaudiosource.Play();
                }
                isrunning = true;
                

            }
           /* else if(Input.GetKey(KeyCode.DownArrow))
            {
                anima.SetBool("run_bool", true);
                if (!feetaudiosource.isPlaying)
                {
                    feetaudiosource.Play();
                }

            }*/
            else
            {
                anima.SetBool("run_bool", false);
                isrunning = false;
                feetaudiosource.Pause();
            }
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);
            float test = getIncSpeed();
            //Debug.Log(test);
            moveDirection *= speed+test;
            /*if (Input.GetButton("Jump")&&anima.GetBool("run_bool"))
            {

                //moveDirection.y = jumpSpeed;
                anima.Play("127_26");


            }*/

            if (!lightaudiosource.isPlaying)
                lightaudiosource.Play();
           



        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);       
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(Rotate(Vector3.up, 90, 0.5f));
            //transform.Rotate(0, 90F, 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Rotate(Vector3.up, -90, 0.5f));
           // transform.Rotate(0,-90F, 0);
        }

        
         if (isrunning==false && deathmenuUi.activeSelf==false&&pausemenu.activeSelf==false)
        {
            startDeathTimer(true);
        }
        else
        {
            startDeathTimer(false);
        }



    }
    public float maxtimetodieifidel=6;
    private float storetime = 0;
    private bool store = true;
    private float currenttime=0;
    private void startDeathTimer(bool active)
    {
       
            switch (active)
            {
                case true:
                    {
                        deathtimer.active = true;
                        if (store)
                        {
                            storetime = Time.realtimeSinceStartup;
                            currenttime = Time.realtimeSinceStartup;
                            store = false;
                        }
                        else
                        {
                            currenttime = Time.realtimeSinceStartup;
                        }
                        int remtime = (int)(maxtimetodieifidel - (currenttime - storetime));
                        timer_text.SetText(remtime + " sec");
                        if (remtime == 0)
                        {
                            isrunning = false;
                            feetaudiosource.Pause();
                            feetaudiosource.enabled = false;
                            lightaudiosource.Pause();
                            lightaudiosource.enabled = false;
                            deathmenuUi.SetActive(true);
                            setdeathMenu();
                            scoremenuUi.SetActive(false);
                            Time.timeScale = 0f;
                        }
                        //Debug.Log(currenttime - storetime);
                        break;
                    }
                case false:
                    {
                        storetime = 0;
                        currenttime = 0;
                        // Debug.Log("reset");
                        deathtimer.active = false;
                        store = true;
                        break;
                    }
            }
        
    }

    private float getIncSpeed()
    {
        float timesinceload = Time.timeSinceLevelLoad;
        float retval = timesinceload / 2;
        if (retval < 200f)
            return retval;
        else
            return 200f;
    }

    private void FixedUpdate()
    {
        updatescore((long)moveDirection.magnitude);
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
        if(hit.gameObject.name.Contains("Car"))
        {
            isrunning = false;
            feetaudiosource.Pause();
            feetaudiosource.enabled = false;
            lightaudiosource.Pause();
            lightaudiosource.enabled = false;
            deathmenuUi.SetActive(true);
            setdeathMenu();
            scoremenuUi.SetActive(false);
            Time.timeScale = 0f;
        }


    }

    void setdeathMenu()
    {
        scoreondead.text = score.ToString();
        float scoretemp = score;
        coinondead.text = noOfcoin.ToString();
        float coinscoretemp = (noOfcoin * 100);
        coinscore.text = coinscoretemp.ToString();
        float totalscoretemp = (score + (noOfcoin * 100));
        totalscore.text = totalscoretemp.ToString();

        float temp = PlayerPrefs.GetFloat("total_score", 0);

        if (temp < totalscoretemp)
        {
            highscoreondead.text = score.ToString();
            highcoinondead.text = noOfcoin.ToString();
            highcoinscore.text = (noOfcoin * 100).ToString();
            hightotalscore.text = (score + (noOfcoin * 100)).ToString();

            PlayerPrefs.SetFloat("score", scoretemp);
            PlayerPrefs.SetFloat("coin", noOfcoin);
            PlayerPrefs.SetFloat("coin_score", coinscoretemp);
            PlayerPrefs.SetFloat("total_score", totalscoretemp);
            PlayerPrefs.Save();
        }
        else
        {
            scoretemp = PlayerPrefs.GetFloat("score", 0);
            float noofcointemp = PlayerPrefs.GetFloat("coin", 0);
            coinscoretemp = PlayerPrefs.GetFloat("coin_score", 0);
            totalscoretemp = PlayerPrefs.GetFloat("total_score", 0);

            highscoreondead.text = scoretemp.ToString();
            highcoinondead.text = noofcointemp.ToString();
            highcoinscore.text = coinscoretemp.ToString();
            hightotalscore.text = totalscoretemp.ToString(); 
        }

    }

    void updatescore(long x)
    {
        score = score + (int)x/10;
        scoretextfield.text = score.ToString();
        cointextfield.text = noOfcoin.ToString();
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }

    /*void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(gameObject.name + "mhgjhj" + other.gameObject.name);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }*/
}
