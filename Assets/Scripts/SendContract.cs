using ChainSafe.Gaming.Evm.Transactions;
using ChainSafe.Gaming.UnityPackage;
using Nethereum.Hex.HexTypes;
using Scripts.EVM.Token;
using UnityEngine;

public class SendContract : MonoBehaviour
{
    // Variables
    private string abi = "" ;                                                                                      // ABI of the marketplace contract
    private string contractAddress = "";                                                                 // address of the marketplace contract
    private string method = "purchaseItem";
    private HexBigInteger value = new HexBigInteger(6900000000000000);     // price of the NFT

   public async void ContractSend(int _itemId)
    {
        object[] args =
        {
            _itemId
        };
        var data = await Evm.ContractSend(Web3Accessor.Web3, method, abi, contractAddress, args, value);
        var response = SampleOutputUtil.BuildOutputValue(data);
        Debug.Log($"TX: {response}");
    }
}
