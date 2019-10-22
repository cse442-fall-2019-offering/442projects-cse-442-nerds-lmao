using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaleLevel : MonoBehaviour {

  void Start () {

  transform.localScale=new Vector3(1,1,1);

  float width=1920;
  float height=1080;


  float worldScreenHeight=Camera.main.orthographicSize*2f;
  float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;

  Vector3 xWidth = transform.localScale;
  xWidth.x=worldScreenWidth / width;
  transform.localScale=xWidth;
  //transform.localScale.x = worldScreenWidth / width;
  Vector3 yHeight = transform.localScale;
  yHeight.y=worldScreenHeight / height;
  transform.localScale=yHeight;
  //transform.localScale.y = worldScreenHeight / height;


    }
  }
