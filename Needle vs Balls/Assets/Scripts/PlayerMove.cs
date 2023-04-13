using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class PlayerMove : MonoBehaviour
{
    [Header("Скорость персонажа")]
    public float _speed = 6f;
    public float _accelerationSpeed = 2f;
    [Header("Штуки персонажа")]
    private Rigidbody _rg;
    public Joystick joystick;

    [SerializeField] private Text _Scorer;
    public float horizontal;
    private Vector2 directionVector;

    [Header("Всякие Эффекты")]
    public GameObject hitEffector;

    [Header("Сохранялка")]
    public int SceneNice;
    [SerializeField] private Text _SceneNiceTXT;

    private Animator anim;

    public int SceneNumber;

    public bool ObuchComplete = false;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void Start()
    {
        MySave();
        if (YG.YandexGame.EnvironmentData.isMobile == true)
        {
            PaneMobiklMenu();
        }
        _rg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (SceneNumber == 1)
        {
            if (Score >= 3)
            {
                WinPanel.SetActive(true);
                Destroy(gameObject);
                YandexGame.FullscreenShow();
            }
        }
        MySave();

        if (SceneNumber == 2)
        {
            if (Score >= 5)
            {
                WinPanel.SetActive(true);
                Destroy(gameObject);
                YandexGame.FullscreenShow();
            }
        }
        MySave();
        if (SceneNumber == 3)
        {
            if (Score >= 7)
            {
                WinPanel.SetActive(true);
                Destroy(gameObject);
                YandexGame.FullscreenShow();
            }
        }
        MySave();
        if (SceneNumber == 4)
        {
            if (Score >= 11)
            {
                WinPanel.SetActive(true);
                Destroy(gameObject);
                YandexGame.FullscreenShow();
            }
        }
        MySave();
        if (SceneNumber == 5)
        {
            if (Score >= 15)
            {
                LosePanel.SetActive(true);
                Destroy(gameObject);
                YandexGame.FullscreenShow();
            }
        }
        MySave();
        SceneNice = SceneNumber;
        if (SceneNumber == 1)
        {
            if (ObuchComplete == true)
            {
                if (YG.YandexGame.EnvironmentData.isDesktop == true)
                {
                    horizontal = Input.GetAxis("Horizontal");
                    directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                    _rg.velocity = directionVector * _speed;
                }

                if (YG.YandexGame.EnvironmentData.isMobile == true)
                {
                    horizontal = joystick.Horizontal;
                    directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                    _rg.velocity = directionVector * _speed;
                }
                else
                {
                    horizontal = Input.GetAxis("Horizontal");
                    directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                    _rg.velocity = directionVector * _speed;
                }

            }
        }
        else
        {
            if (YG.YandexGame.EnvironmentData.isDesktop == true)
            {
                horizontal = Input.GetAxis("Horizontal");
                directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                _rg.velocity = directionVector * _speed;
            }

            if (YG.YandexGame.EnvironmentData.isMobile == true)
            {
                horizontal = joystick.Horizontal;
                directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                _rg.velocity = directionVector * _speed;
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
                directionVector = new Vector3(horizontal * _accelerationSpeed, 0, 0);
                _rg.velocity = directionVector * _speed;
            }
        }
        
    }

    public int Score = 0;

    public int DopDamage = 0;
    [SerializeField] private Text _DopDamage;
    [Header("Панельки")]
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject MobilePanelMenu;
    [SerializeField] public GameObject WinPanel;
    private void PaneMobiklMenu()
    {
        MobilePanelMenu.SetActive(!MobilePanelMenu.activeInHierarchy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            if (DopDamage >= 1)
            {
                Score += 1;
                _Scorer.text = Score.ToString();
                DopDamage--;
                _DopDamage.text = DopDamage.ToString();
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(hitEffector, transform.position, Quaternion.identity);
            Destroy(effect,3f);
            Destroy(gameObject);
            YandexGame.FullscreenShow();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LosePanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Dop"))
        {

            DopDamage++;
            _DopDamage.text = DopDamage.ToString();

            if (DopDamage < 0)
            {
                DopDamage = 0;
            }
        }
        

        
    }
    
    public void GetLoad()
    {
        _SceneNiceTXT.text = YandexGame.savesData.SceneScoreNice.ToString();
    }

    public void MySave()
    {
        YandexGame.savesData.SceneScoreNice = SceneNice;
        YandexGame.SaveProgress();
    }
    public GameObject Obuchenie;
    public void ObuchenieComplete()
    {
        ObuchComplete = true;
        Obuchenie.SetActive(false);
    }
}
