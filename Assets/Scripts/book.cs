using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    public static int index = 0;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;
    [SerializeField] GameObject Marcador1;
    bool canPress = true;

    IEnumerator desabilitaBotao(){
        canPress = false;
        yield return new WaitForSeconds(1);
        canPress = true;
    }


    private void Start()
    {
        InitialState();
        
    }

    public void InitialState()
    {
        for (int i=0; i<pages.Count; i++)
        {
            pages[i].transform.rotation=Quaternion.identity;
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false); 
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //Torna o botão ativo
        }
    }

    public void RotateForward()
    {
        index++;
        if(!canPress){return;}
        StartCoroutine(desabilitaBotao());
        Debug.Log(index);
        //if (rotate == true) { return; }
        float angle = 180; //rotaciona em 180 para mostrar a próxima página
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        //StartCoroutine(Rotate(angle, true));

    }

    public void ForwardButtonActions()
    {
        backButton.SetActive(true); //Torna o botão ativo
        
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false); //Torna o botão de avançar inativo na última página
        }
    }

    public void RotateBack()
    {
        index--;
        if(!canPress){return;}
        StartCoroutine(desabilitaBotao());
        Debug.Log(index);
        ///if (rotate == true) { return; }
        float angle = 0; //reseta o angulo para a página ficar no lugar certo
        pages[index].SetAsLastSibling();
        BackButtonActions();
        //StartCoroutine(Rotate(angle, false));

    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //Torna o botão ativo
        }
        if (index == 0)
        {
            backButton.SetActive(false); //Torna o botão de voltar inativo na primeira página
        }
    }

    public void MarcadorMonstros()
    {        
        InitialState();

        if (index == 0)
        {
            backButton.SetActive(false); //Torna o botão de voltar inativo na primeira página
        }
        Debug.Log(index);
        index = 0;
    }

    public void MarcadorQuests()
        { 
        Debug.Log(index);
        if(index < 12){
            for(int i=0; i<(12-index); i++){
                RotateForward();
            }
        } else if (index > 12){
            for(int i=0; i<(index-12); i++){
                RotateBack();
            }
        }
            backButton.SetActive(true);
            forwardButton.SetActive(true);
        }

     public void MarcadorCombate()
    {   
        Debug.Log(index);
        if(index < 13){
            for(int i=0; i<(13-index); i++){
                RotateForward();
            }
        } else if (index > 13){
            for(int i=0; i<(index-13); i++){
                RotateBack();
            }
        }
        backButton.SetActive(true);
        forwardButton.SetActive(true);
    }

    public void MarcadorLoja()
    {   
        Debug.Log(index);
        if(index < 14){
            for(int i=0; i<(14-index); i++){
                RotateForward();
            }
        } else if (index > 14){
            for(int i=0; i<(index-14); i++){
                RotateBack();
            }
        }

        backButton.SetActive(true);
        forwardButton.SetActive(true);
    }

    public void MarcadorConfigs()
    {        
        Debug.Log(index);
        if(index < 6){
            for(int i=0; i<(6-index); i++){
                RotateForward();
            }
        } else if (index > 6){
            for(int i=0; i<(index-6); i++){
                RotateBack();
            }
        }
        backButton.SetActive(true);
        forwardButton.SetActive(false);
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value); //Movimento de folha
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation); //proporção para realizar o movimento 
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    //index--;
                }
                rotate = false;
                break;

            }
            yield return null;

        }
    }



}
