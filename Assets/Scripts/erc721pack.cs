using UnityEngine;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
//using Web3Unity.Scripts.Library.ETHEREUEM.EIP;
using Scripts.EVM.Token;
//using ChainSafe.Gaming.UnityPackage.Ethereum.Eip;
using ChainSafe.Gaming;
using ChainSafe.Gaming.UnityPackage.Model;
using ChainSafe.Gaming.UnityPackage;

public class erc721pack : MonoBehaviour
{   
    public GameObject ObjToActive;
    async void Start()
    {
      //  string[] tokenId= {"45","188"};
        string[] contract= {  "0x3Eff964d46C62be703D9A01EF720ba0479e79c3C","0x3Eff964d46C62be703D9A01EF720ba0479e79c3C" };
       // string account = PlayerPrefs.GetString("Account");
       string account="0x23142D7858aD692E2c51EAf90d2Da1F954637091";
     //   Debug.Log(account);

        for (int i=0; i<2; i++)
        {
      //  for (int f=0; f<2; f++)
      //  {
      //  string ownerOf = await ERC721.OwnerOf(contract[i],tokenId[f]);
    //  BigInteger balance = await ERC721.BalanceOf(contract[i], account);
    BigInteger balance = await Erc721.BalanceOf(Web3Accessor.Web3,contract[i], account);
      print(balance);
      //  print(ownerOf);
      //   if (ownerOf.Contains(account))
      //  {
      //      ObjToActive.SetActive(true);
      //  }
        if (balance>0)
        {
          ObjToActive.SetActive(true);
        }
      //  }
        }
    }
}
