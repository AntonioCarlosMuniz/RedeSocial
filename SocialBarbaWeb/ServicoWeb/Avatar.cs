using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.ServicoWeb
{
    public class Avatar
    {
        public static string GetAvatar()
        {
            var segundo = DateTime.Now.Second;

            if (segundo < 20)
            {
                return "https://raw.githubusercontent.com/antoniocarlos/avatar3.png";
            }
            else
            {
                if (segundo >= 20 && segundo < 40)
                    return "https://raw.githubusercontent.com/antoniocarlos/avatar2.png";
            }
            return "https://raw.githubusercontent.com/antoniocarlos/RedeSocial/avatar1.png";
        }
    }
}