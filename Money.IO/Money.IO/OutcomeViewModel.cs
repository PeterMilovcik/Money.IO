using System;
using Xamarin.Forms;

namespace Money.IO
{
    public class OutcomeViewModel : ValueViewModel
    {
        public OutcomeViewModel(INavigation navigation, Repository repository)
            : base(navigation, repository)
        {
        }

        protected override Record CreateRecord() =>
            new Record(DateTime.Now, -1 * Value);
    }
}