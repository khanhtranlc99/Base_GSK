using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BaseHex : MonoBehaviour
{

    public BaseHex getHex;
    public BaseHex pushHex;

    public List<BaseHex> lsBaseMerge;

    public BaseHexAnim hexAnim;

    private Vector3 currentPost
    {
        get
        {
            return this.transform.position;
        }
    }

    public void HandleSpawnHex()
    {
        hexAnim = SimplePool2.Spawn(GamePlayController.Instance.playerContain.hexAnim);
        hexAnim.transform.parent = this.transform;
        hexAnim.transform.localPosition = new Vector3(0, -0.25f, 0);
        hexAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
        Debug.LogError("tex");

        hexAnim.transform.localScale = Vector3.zero;
        hexAnim.transform.DOScale(new Vector3(1, 1, 1), 1).OnComplete(delegate {
        });
    }


    public void HandleSetUp()
    {
        if(hexAnim == null)
        {
            if(getHex != null)
            {
                if (getHex.hexAnim != null)
                {
                    getHex.hexAnim.transform.DOMoveY(this.transform.position.y, 0.35f).SetEase(Ease.OutBounce).OnComplete(delegate {

                       
                      hexAnim = getHex.hexAnim;
                        getHex.hexAnim = null;
                        getHex.HandleSetUp();
                        if (pushHex != null)
                        {
                            pushHex.HandleSetUp();
                        }
                    });
                }
                else
                {
                    getHex.HandleSetUp();
                }
              
            }
            else
            {

                hexAnim = SimplePool2.Spawn( GamePlayController.Instance.playerContain.hexAnim );
                hexAnim.transform.parent = this.transform;
                hexAnim.transform.localPosition = new Vector3(0, -0.25f, 0);
                hexAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
                 
                hexAnim.transform.localScale = Vector3.zero;
                hexAnim.transform.DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.OutBack).OnComplete(delegate {
                
                
                if(pushHex != null)
                    {
                        pushHex.HandleSetUp();
                    }
                
                }) ;
      
            }
        }
    }

    private void OnMouseDown()
    {
       
        if(hexAnim != null)
        {
            Destroy(hexAnim.gameObject);
            hexAnim = null;
            HandleSetUp();
        }
     
    }

}
