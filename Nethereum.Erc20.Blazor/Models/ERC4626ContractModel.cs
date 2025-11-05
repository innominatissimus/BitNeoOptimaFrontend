using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethereum.Erc20.Blazor.Models
{
	public class ERC4626ContractModel
	{
		public String Address { get; set; }

		public String Name { get; set; }

		public Byte Decimals { get; set; }

		public ERC4626ContractModel(String address)
		{
			Address = address;
		}
	}

	[Function("decimals", "uint8")]
	public class DecimalsFunction : FunctionMessage;
}
