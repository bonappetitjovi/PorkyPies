using UnityEngine;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using ChainSafe.Gaming.UnityPackage;
using Scripts.EVM.Token;
//using ChainSafe.Gaming.UnityPackage.Ethereum.Eip;
using ChainSafe.Gaming;
using ChainSafe.Gaming.UnityPackage.Model;


public class activate1155 : MonoBehaviour
{   
    public GameObject ObjToActive;
    public int tokenId=0;
    async void Start()
    {
      //  string[] tokenId= {"45","188"};
       // string[] contract= {  "0x0eedEdDb62DB4f4063C5243D0D921427a890d0Fe","0x3Eff964d46C62be703D9A01EF720ba0479e79c3C" };
       string[] contract= {  "0x113c73fb7b04362ca21fba9964624ffd0d90c143","0x113c73fb7b04362ca21fba9964624ffd0d90c143" };
        string account =await Web3Accessor.Web3.Signer.GetAddress();
       // string account="0x23142D7858aD692E2c51EAf90d2Da1F954637091";
        Debug.Log(account);
        
       // var account = "0x23142D7858aD692E2c51EAf90d2Da1F954637091";

 //       var contract = "0x9123541E259125657F03D7AD2A7D1a8Ec79375BA";
//var account = "0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2";
//var balance = await ERC721.BalanceOf(contract, account);


        for (int i=1; i<2; i++)
        {
      BigInteger balance = await Erc1155.BalanceOf(Web3Accessor.Web3,contract[i], account,tokenId);
      print(balance);
        if (balance>0)
        {
          ObjToActive.SetActive(true);
        }
        }
    }
}
