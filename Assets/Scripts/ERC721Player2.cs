using UnityEngine;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using ChainSafe.Gaming.UnityPackage;
using ChainSafe.Gaming.UnityPackage.Model;
using Scripts.EVM.Token;


public class ERC721Player2 : MonoBehaviour
{   

 
    //public string tokenId = "45";
  //  public string[] contract = {"0x3Eff964d46C62be703D9A01EF720ba0479e79c3C", "0x7289A31832C137358c42df8E36FE32F8Aabe7162"};
  

    public GameObject ObjToActive;
    async void Start()
    {
      //  string[] tokenId= {"45","188"};
        string[] contract= {  "0x0eedEdDb62DB4f4063C5243D0D921427a890d0Fe","0x3Eff964d46C62be703D9A01EF720ba0479e79c3C" };
        string account = PlayerPrefs.GetString("Account");

        for (int i=0; i<2; i++)
        {
      //  for (int f=0; f<2; f++)
      //  {
      //  string ownerOf = await ERC721.OwnerOf(contract[i],tokenId[f]);
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
