using System;
using Xamarin.Forms;

namespace Money.IO
{
    public class IncomeViewModel : ValueViewModel
    {
        public IncomeViewModel(INavigation navigation, Repository repository)
         : base(navigation, repository)
        {
        }

        protected override Record CreateRecord() => 
            new Record(DateTime.Now, Value);
    }
}