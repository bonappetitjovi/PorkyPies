using UnityEngine;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using ChainSafe.Gaming.UnityPackage;
using Scripts.EVM.Token;
//using ChainSafe.Gaming.UnityPackage.Ethereum.Eip;
using ChainSafe.Gaming;
using ChainSafe.Gaming.UnityPackage.Model;


public class deactivate1155 : MonoBehaviour
{   
    public GameObject ObjToDeActivate;
    public int tokenId=0;
    async void Start()
    {
       string[] contract= {  "0x113c73fb7b04362ca21fba9964624ffd0d90c143","0x113c73fb7b04362ca21fba9964624ffd0d90c143" };
        string account =await Web3Accessor.Web3.Signer.GetAddress();
        Debug.Log(account);
        for (int i=1; i<2; i++)
        {
      BigInteger balance = await Erc1155.BalanceOf(Web3Accessor.Web3,contract[i], account,tokenId);
      print(balance);
        if (balance>0)
        {
          ObjToDeActivate.SetActive(false);
        }
        }
    }
}
