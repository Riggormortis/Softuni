using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Interfaces
{
    //this can be implemented by smartphone, tablet, laptop, PC....
    public interface IBrowsable
    {
        string BrowseURL(string url);
    }
}
