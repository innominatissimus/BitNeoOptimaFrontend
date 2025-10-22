using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.UI;
using System;
using System.Numerics;
using Nethereum.Erc20.Blazor.Models;

namespace Nethereum.Erc20.Blazor
{
	public class ERC4626RedeemModel
	{
		public ERC4626RedeemModel(String address)
		{
			ContractModel = new ERC4626ContractModel(address);
		}

		public ERC4626ContractModel ContractModel { get; set; }
		public Decimal Shares { get; set; }
		public String Receiver { get; set; }
		public String Owner { get; set; }

		/// <summary>
		/// Return function object, which represents redeem(uint256 shares, address receiver, address owner).
		/// </summary>
		public RedeemFunction GetRedeemFunction()
		{
			return new RedeemFunction()
			{
				Shares = Web3.Web3.Convert.ToWei(Shares, ContractModel.Decimals),
				Receiver = Receiver,
				Owner = Owner
			};
		}
	}

	// Redeem function definition for ERC4626
	[Function("redeem", "uint256")]
	public class RedeemFunction : FunctionMessage
	{
		[Parameter("uint256", "shares", 1)]
		public BigInteger Shares { get; set; }

		[Parameter("address", "receiver", 2)]
		public String Receiver { get; set; }

		[Parameter("address", "owner", 3)]
		public String Owner { get; set; }
	}
}