using UnityEngine;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using ChainSafe.Gaming.UnityPackage;
using Scripts.EVM.Token;
//using ChainSafe.Gaming.UnityPackage.Ethereum.Eip;
using ChainSafe.Gaming;
using ChainSafe.Gaming.UnityPackage.Model;


public class deactivate721 : MonoBehaviour
{   
    public GameObject ObjToDeActivate;
    async void Start()
    {
       string[] contract= {  "0x3Eff964d46C62be703D9A01EF720ba0479e79c3C","0x3Eff964d46C62be703D9A01EF720ba0479e79c3C" };
        string account =await Web3Accessor.Web3.Signer.GetAddress();
        Debug.Log(account);
        for (int i=1; i<2; i++)
        {
      BigInteger balance = await Erc721.BalanceOf(Web3Accessor.Web3,contract[i], account);
      print(balance);
        if (balance==0)
        {
          ObjToDeActivate.SetActive(false);
        }
        }
    }
}
