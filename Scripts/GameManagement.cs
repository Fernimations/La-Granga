using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instancia;
    int ContadorHuevo;

    void Awake(){
        if(instancia == null){
            instancia = this;
        }else {
            Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            }
            public void SumerHuevo(){
                ContadorHuevo++;
                Debug.Log(ContadorHuevo);

          }
}
