using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using Acoross.TestRpc.Nested;
using System;

public class MySocket : MonoBehaviour
{
    class RpcClient : Acoross.TestRpc.Nested.RpcClientSync
    {
        // NotiChat() is called in Client.Update -> HandleNotis()
        public override void NotiChat(ChatMsg message)
        {
            Debug.Log(string.Format("{0} {1}, {2}", message.type, message.talker, message.msg));
        }
    }

    private RpcClient rpcclient;
    bool login = false;

    public string ipaddress = "127.0.0.1";
    public const int port = 7777;

    void Awake()
    {
        Debug.Log("Client Awake()");

        rpcclient = new RpcClient();
        rpcclient.Connect(IPAddress.Parse(ipaddress), port);

        Debug.Log("Client connected");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!rpcclient.Running)
        {
            try
            {
                rpcclient.HandleNoties();
                rpcclient.Dispose();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }

            try
            {
                Debug.Log("update rpcconnect");
                rpcclient = new RpcClient();
                rpcclient.Connect(IPAddress.Parse(ipaddress), port);
                Debug.Log("update rpcconnect done");
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
        else
        {
            try
            {
                rpcclient.HandleNoties();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
    }

    public bool Login(string id, string pwd)
    {
        if (login)
            return true;

        login = rpcclient.Login(new LoginReq
        {
            id = id,
            pwd = pwd
        });

        return login;
    }

    public void Chat(string name, string msg)
    {
        if (!login)
            return;

        rpcclient.Chat(new ChatMsg
        {
            type = ChatType.Local,
            talker = name,
            msg = msg
        });
    }

    void OnApplicationQuit()
    {
        if (rpcclient != null)
        {
            rpcclient.Dispose();
        }
    }
}