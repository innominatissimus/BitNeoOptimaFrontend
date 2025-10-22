using FluentValidation;
using Nethereum.Erc20.Blazor.Models;
using Nethereum.UI.Validation;
using System;

namespace Nethereum.Erc20.Blazor
{
	public class ERC4626ContractValidator : AbstractValidator<ERC4626ContractModel>
	{
		public ERC4626ContractValidator()
		{
			RuleFor(t => t.Address).IsEthereumAddress();
			RuleFor(t => t.Decimals).GreaterThan((Byte)0).WithMessage("Decimals must be greater than 0");
		}
	}
}
