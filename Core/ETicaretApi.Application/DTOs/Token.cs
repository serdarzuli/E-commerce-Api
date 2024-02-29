using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.DTOs
{
    public class Token
    {
        //Dto nedir, servislerden servislere veri aktarmaya denir. 
        //Application katmanindan presentation katmanina veri aktarmada kullanilir.
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
