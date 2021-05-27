using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Filters
{
    public interface IFilter
    {
        string Apply(string input);
    }
}