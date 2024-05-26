using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    
    [SerializeField]  private BaseCounter baseCounter;
    [SerializeField] private GameObject [] visualgameobjectArry;
    // Start is called before the first frame update
  void Start(){
       NewPlayer.Instance.OnSlectedCounterChanged += NewPlayer_OnSlectedCounterChanged; 
    }
     private void NewPlayer_OnSlectedCounterChanged(object sender, NewPlayer.OnSlectedCounterChangedEventArgs e){
        if(e.selectedClearCounter == baseCounter){
            Show();
        }else{
            Hide();
        }   
            
         
     }

    
    
     private void Show(){
        foreach(GameObject visualgameobject in visualgameobjectArry){
         visualgameobject.SetActive(true);
     }
     }
      private void Hide(){
        foreach(GameObject visualgameobject in visualgameobjectArry){
         visualgameobject.SetActive(false);
        }
      }
}
