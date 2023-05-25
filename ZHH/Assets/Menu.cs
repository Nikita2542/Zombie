using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class Menu : MonoBehaviour
{
    private Image main;
    public GameObject options;
    private Button[] btn;
    private bool menu;
    private TextMeshProUGUI textOp;
    private Image imageOp;


    void Start()
    {
        options.gameObject.SetActive(false);
        #region Btn
        main = gameObject.transform.GetChild(0).GetComponent<Image>();
        btn = new Button[5];
        btn[0] = main.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Button>();//Play
        btn[0].onClick.AddListener(Play);

        btn[1] = main.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>();//Options
        btn[1].onClick.AddListener(Options);

        textOp = main.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        imageOp = main.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>();
        textOp.gameObject.SetActive(true);
        imageOp.gameObject.SetActive(false);
        
        btn[2] = main.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Button>();//Exite
        btn[2].onClick.AddListener(Exit);

        btn[3] = main.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Button>();//Lab
        btn[3].onClick.AddListener(Lab);

        btn[4] = main.transform.GetChild(0).GetChild(4).gameObject.GetComponent<Button>();//Garage
        btn[4].onClick.AddListener(Garage);
        #endregion
        main.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            menu = !menu;
            if(menu == true)
            {
                main.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                main.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
           
        }
    }
    bool option;
    public void Play()
    {
        if (option)
        {
            Options();
        }

        main.gameObject.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        menu = false;
    }

    
    public void Options()
    {
        option = !option;
        if(option)
        {
            options.gameObject.SetActive(true);
            textOp.gameObject.SetActive(false);
            imageOp.gameObject.SetActive(true);
            main.enabled = false;
        }
        else
        {
            options.gameObject.SetActive(false);
            textOp.gameObject.SetActive(true);
            imageOp.gameObject.SetActive(false) ;
            main.enabled = true;
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Lab()
    {
        SceneManager.LoadScene(2);
    }
    public void Garage()
    {
        SceneManager.LoadScene(1);
    }


}
