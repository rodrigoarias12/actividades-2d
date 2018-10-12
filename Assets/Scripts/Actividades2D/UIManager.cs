using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager m_Singleton;

    public static UIManager Singleton
    {
        get
        {
            return m_Singleton;
        }
    }

    [SerializeField]
    private UIScreen[] m_Screens;
    private UIScreen m_ActiveScreen;
    private UIWindow m_ActiveWindow;
    [SerializeField]
    private Texture2D m_CursorDefaultTexture;
    [SerializeField]
    private Texture2D m_CursorClickTexture;
    [SerializeField]
    private float m_CursorHideDelay = 1f;
    [SerializeField]
    private UIScreen m_PauseScreen;
    [SerializeField]
    private int m_actividad;

    private static bool created = false;

    public List<Vector3> lista;

    void Awake()
    {
        if (m_Singleton != null)
        {
            Destroy(gameObject);
            return;
        }
       
        m_Singleton = this;
        Cursor.SetCursor(m_CursorDefaultTexture, Vector2.zero, CursorMode.Auto);
        if (!created)
        {
            #region actividad 2
            if (m_actividad == 2)
            {
                
            lista = new List<Vector3>();
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Vector3 posicion1 = GameObject.Find("InventoryTile1").transform.position;
            Vector3 posicion2 = GameObject.Find("InventoryTile2").transform.position;
            Vector3 posicion3 = GameObject.Find("InventoryTile3").transform.position;
            Vector3 posicion4 = GameObject.Find("InventoryTile4").transform.position;

            lista.Add(posicion1);
            lista.Add(posicion2);
            lista.Add(posicion3);
            lista.Add(posicion4);

            int[] deck = new int[4] { 0, 1, 2, 3 };
            for (int i = 0; i < deck.Length; i++)
            {
                int temp = deck[i];
                int randomIndex = UnityEngine.Random.Range(0, deck.Length);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
            for (int i = 0; i < lista.Count; i++)
            {
                GameObject.Find("InventoryTile" + (i + 1).ToString()).transform.position = lista[deck[i]];
                Debug.Log(GameObject.Find("InventoryTile" + (i + 1).ToString()).name);
            }
            Debug.Log("Awake: " + this.gameObject);
            }
            #endregion

        }
    }

    void Start()
    {
        OpenScreen(m_Screens[0]);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenScreen(m_PauseScreen);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(m_CursorClickTexture, Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(m_CursorDefaultTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OpenWindow(UIWindow window)
    {
        window.Open();
        m_ActiveWindow = window;
    }

    public void CloseWindow(UIWindow window)
    {
        if (m_ActiveWindow == window)
        {
            m_ActiveWindow = null;
        }
        window.Close();
    }

    public void CloseActiveWindow()
    {
        if (m_ActiveWindow != null)
        {
            CloseWindow(m_ActiveWindow);
        }
    }

    public void OpenScreen(int index)
    {
        OpenScreen(m_Screens[index]);
    }

    public void OpenScreen(UIScreen screen)
    {
        CloseAllScreens();
        if (m_ActiveScreen == null)
        {
            m_ActiveScreen = screen;
            m_ActiveScreen.Open();
            return;
        }
        m_ActiveScreen.OnClosed += screen.Open;
        m_ActiveScreen.Close();
        m_ActiveScreen = screen;
    }

    public void CloseScreen(int index)
    {
        CloseScreen(m_Screens[index]);
    }

    public void CloseScreen(UIScreen screen)
    {
        if (m_ActiveScreen == screen)
        {
            m_ActiveScreen = null;
        }
        screen.Close();
    }

    public void CloseAllScreens()
    {
        CloseAllScreens(m_ActiveScreen);
    }

    public void CloseAllScreens(UIScreen except)
    {
        for (int i = 0; i < m_Screens.Length; i++)
        {
            if (except == null || m_Screens[i] != except)
            {
                CloseScreen(m_Screens[i]);
            }
        }
    }

}
