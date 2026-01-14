using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.UI.Validation;
using Microsoft.AspNetCore.Components;
using Nethereum.Erc20.Blazor.Models;

namespace Nethereum.Erc20.Blazor
{
	public class ERC4626DepositValidator : AbstractValidator<ERC4626DepositModel>
	{
		public ERC4626DepositValidator()
		{
			RuleFor(t => t.Receiver).IsEthereumAddress();
			RuleFor(t => t.Assets).GreaterThan(0).WithMessage("Amount must be greater than 0");
			RuleFor(t => t.ContractModel).SetValidator(new ERC4626ContractValidator());
			// TODO: Add rule to check that Assets is less than user's balance of underlying asset.
		}
	}
}
