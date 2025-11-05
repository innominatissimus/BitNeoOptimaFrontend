using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.UI;
using System;
using System.Numerics;
using Nethereum.Erc20.Blazor.Models;

namespace Nethereum.Erc20.Blazor
{
	public class ERC4626DepositModel
	{
		public ERC4626DepositModel(String address)
		{
			ContractModel = new ERC4626ContractModel(address);
		}

		public ERC4626ContractModel ContractModel { get; set; }
		public Decimal Assets { get; set; }
		public String Receiver { get; set; }

		/// <summary>
		/// Return function object, which represents deposit(uint256 assets, address receiver).
		/// </summary>
		public DepositFunction GetDepositFunction()
		{
			return new DepositFunction()
			{
				Assets = Web3.Web3.Convert.ToWei(Assets, ContractModel.Decimals),
				Receiver = Receiver
			};
		}

		public ApproveFunction GetApproveFunction()
		{
			return new ApproveFunction()
			{
				Spender = ContractModel.Address,
				Value = UInt128.MaxValue
			};
		}
	}

	// Deposit function definition for ERC4626
	[Function("deposit", "uint256")]
	public class DepositFunction : FunctionMessage
	{
		[Parameter("uint256", "assets", 1)]
		public BigInteger Assets { get; set; }

		[Parameter("address", "receiver", 2)]
		public String Receiver { get; set; }
	}

	[Function("approve", "bool")]
	public class ApproveFunction : FunctionMessage
	{
		[Parameter("address", "_spender", 1)]
		public String Spender { get; set; }
		[Parameter("uint256", "_value", 2)]
		public BigInteger Value { get; set; }
	}
}
