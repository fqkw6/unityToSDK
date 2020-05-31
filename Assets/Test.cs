using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public Text[] TT;
    void Start()
    {
        // 直接调用java的静态方法， 我比较喜欢这种，简单明了
        AndroidJavaClass klass = new AndroidJavaClass("com.ZhuoYue.unityToSDK.MainActivity");// 这是包名,加你要调的类名
        string str = klass.CallStatic<string>("PrintName");//带有返回值，无参数
        TT[0].text = str;
        TT[1].text = "带引";

        TT[2].text = klass.CallStatic<int>("PrintName2", 11111122).ToString();//脚本挂的物体名  //带有返回值，有参数
        klass.CallStatic("Invokep", "Canvas", "JavaCallUnity");//脚本挂的物体名
        TT[4].text = klass.CallStatic<int>("Invokepp", "Canvas", "JavaCallUnity3").ToString();

    }


    public void JavaCallUnity(string str)
    {
        TT[5].text = "java jianjie diao" + str;
    }
    public void JavaCallUnity2(string str)
    {
        TT[6].text = "java :" + str;
    }
    public void JavaCallUnity3(string str)
    {
        TT[7].text = "java int fanhui :" + str;
    }


}
