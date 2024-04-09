using ChainSafe.Gaming.Evm.Transactions;
using ChainSafe.Gaming.UnityPackage;
using Nethereum.Hex.HexTypes;
using Scripts.EVM.Token;
using UnityEngine;
using System.IO;

public class MintBuy : MonoBehaviour
{
    // Variables
    private string filePath;
    string abi ;

    void Start()
    {
        // Specify the full path to your text file
        filePath = @"Assets/Resources/AAA/marketplaceabi.txt";

        // Read the entire contents of the file into a string
        string abi = Resources.Load<TextAsset>(filePath).text;

        // Now you can use 'longText' in your Unity script
        Debug.Log(abi);
    }
    // ABI of the marketplace contract
    private string contractAddress = "0xfd4b657c97410b62f41316e48744fa2ad7ba0636";    // address of the marketplace contract
    private string method = "purchaseItem";
    private HexBigInteger value = new HexBigInteger(6900000000000000);     // price of the NFT

   public async void ContractSend(int _itemId)
    {
        string abi = Resources.Load<TextAsset>(filePath).text;
        object[] args =
        {
            _itemId
        };
        var data = await Evm.ContractSend(Web3Accessor.Web3, method, abi, contractAddress, args, value);
        var response = SampleOutputUtil.BuildOutputValue(data);
        Debug.Log($"TX: {response}");
    }
}
