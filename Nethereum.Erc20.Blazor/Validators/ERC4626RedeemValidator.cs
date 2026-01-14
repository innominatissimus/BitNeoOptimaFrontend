using FluentValidation;
using Nethereum.UI.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Erc20.Blazor.Models;

namespace Nethereum.Erc20.Blazor.Validators
{
	public class ERC4626RedeemValidator : AbstractValidator<ERC4626RedeemModel>
	{
		public ERC4626RedeemValidator()
		{
			RuleFor(t => t.Receiver).IsEthereumAddress();
			RuleFor(t => t.Shares).GreaterThan(0).WithMessage("Amount must be greater than 0");
			RuleFor(t => t.ContractModel).SetValidator(new ERC4626ContractValidator());
			// TODO: Add rule to check that Shares is less than user's balance of vault shares.
		}
	}
}
