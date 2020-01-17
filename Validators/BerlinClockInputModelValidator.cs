using BerlinClock.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Validators
{
	class BerlinClockInputModelValidator : AbstractValidator<BerlinClockInputModel>
	{
		public BerlinClockInputModelValidator()
		{
			RuleFor(x => x.second).InclusiveBetween(0, 59);
			RuleFor(x => x.minute).InclusiveBetween(0, 59);
			RuleFor(x => x.hour).InclusiveBetween(0, 24);
		}
	}
}
